using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ph_model;

namespace ph_logic.Admin
{
    public class BackgroundGenerator : BackgroundWorker
    {
        private GenerationArguments m_generationArguments;
        private Guid m_key = Guid.NewGuid();
        private int m_clusterId;

        public class GenerationArguments
        {
            public string Name { get; set; }
            public int Amount { get; set; }
            public int ExtentX { get; set; }
            public int ExtentY { get; set; }
        }

        public BackgroundGenerator()
        {
            this.DoWork += BackgroundGenerator_DoWork;
            this.RunWorkerCompleted += BackgroundGenerator_RunWorkerCompleted;
            this.WorkerReportsProgress = true;
            this.ProgressChanged += BackgroundGenerator_ProgressChanged;
        }

        private void BackgroundGenerator_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            using (var db = PhContext.CreateContext())
            {
                var job = db.JobStatusInfoSet.FirstOrDefault(x => x.Key == m_key);
                job.Progress = e.ProgressPercentage;
                job.Message = e.UserState.ToString();
                job.Succeded = false;
                db.SaveChanges();
            }
        }

        public Guid StartGeneration(string name, int starsToGenerate, int extentX, int extentY)
        {
            this.RunWorkerAsync(new GenerationArguments() { Name = name, Amount = starsToGenerate, ExtentX = extentX, ExtentY = extentY });
            return m_key;
        }

        private void BackgroundGenerator_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Save the Completion to the db, ajax call will query the completion
            using (var db = PhContext.CreateContext())
            {
                var job = db.JobStatusInfoSet.FirstOrDefault(x => x.Key == m_key);
                Cluster cluster = db.ClusterSet.FirstOrDefault(x => x.Id == m_clusterId);
                job.Progress = 100;
                job.Message = "Cluster " + m_clusterId + " generated. " + cluster.Stars.Count + " systems created.";
                job.Succeded = true;
                db.SaveChanges();
            }
        }

        private void BackgroundGenerator_DoWork(object sender, DoWorkEventArgs e)
        {
            
            m_generationArguments = e.Argument as GenerationArguments;
            if (m_generationArguments == null)
                return;

            Log.Info("Started Cluster Generation for Cluster " + m_generationArguments.Name);

            if (!GenerateJob())
                return;

            m_clusterId = CreateCluster();

            GenerateStars();

            GenerateSystems();

        }

        private bool GenerateJob()
        {
            using (var db = PhContext.CreateContext())
            {
                //check if a generation is in progress. if yes return
                bool unfinishedJobsExist = db.JobStatusInfoSet.Any(x => x.Progress != 100);
                if (unfinishedJobsExist)
                    return false;

                //create the new job
                var job = db.JobStatusInfoSet.Create();
                job.Progress = 0;
                job.Key = m_key;
                job.Message = "Cluster Generating";
                job.Succeded = false;
                db.JobStatusInfoSet.Add(job);
                db.SaveChanges();
            }
            return true;

        }

        private void GenerateSystems()
        {
            using (var db = PhContext.CreateContext())
            {
                this.ReportProgress(0, "Generating Systems");
                var cluster = db.ClusterSet.FirstOrDefault(x => x.Id == m_clusterId);
                int progressCount = 0;
                foreach (Star star in cluster.Stars)
                {
                    //Determine Number of orbital Celestial Objects
                    int count = Utility.RandomNumber(0, 5);

                    if (count == 0)
                        return;

                    //Generate Orbital celestial Objects
                    for (int i = 0; i < count; i++)
                    {
                        CelestialBody body = null;
                        //Determin Type: Planet 75%, Asteroid 20% or Nebula 5%
                        var systemObjectType = Generation.GetSystemObjectType();

                        if (systemObjectType == typeof(Planet))
                            body = Generation.GeneratePlanet(db, i, star);
                        if (systemObjectType == typeof(Asteroid))
                            body = Generation.GenerateAsteroid(db, i, star);
                        if (systemObjectType == typeof(Nebula))
                            body = Generation.GenerateNebula(db, i, star);

                        db.CelestialBodySet.Add(body);
                    }
                    progressCount++;
                    int progress = 100 / cluster.Stars.Count * progressCount;
                    this.ReportProgress(progress, "Generating Systems");
                }
            }
        }

        private void GenerateStars()
        {
            using (var db = PhContext.CreateContext())
            {
                this.ReportProgress(0, "Generating Stars");

                Cluster cluster = db.ClusterSet.FirstOrDefault(x => x.Id == m_clusterId);

                Position pos = new Position();
                List<Star> stars = new List<Star>();
                for (int i = 0; i < m_generationArguments.Amount; i++)
                {
                    string name = string.Empty;
                    bool starnameExists = true;
                    while (starnameExists)
                    {
                        name = Utility.RandomString(3) + "-" + Utility.RandomNumber(100, 999);
                        starnameExists = stars.Any(x => x.Name == name);
                    }
                    bool collision = true;
                    var tries = 0;
                    while (collision)
                    {
                        pos.X = Utility.RandomNumber(100, cluster.ExtentX - 100);
                        pos.Y = Utility.RandomNumber(100, cluster.ExtentY - 100);
                        collision = stars.Any(s => s.X < pos.X + 200 && s.X > pos.X - 200 && s.Y < pos.Y + 150 && s.Y > pos.Y - 150);
                        tries++;
                        if (tries > 1000)
                            break;
                    }
                    if (tries > 1000)
                    {
                        Log.Warning("Exceeded 1000 tries while finding a position for Star " + i + ". Aborting star generation.");
                        break;
                    }


                    Star star = db.CelestialBodySet.Create<Star>();
                    star.Name = name;
                    star.Type = Generation.GetStarType();
                    star.CssClass = Generation.GetStarCssType(star.Type);

                    star.X = pos.X;
                    star.Y = pos.Y;

                    star.Cluster = cluster;
                    stars.Add(star);
                    int progress = 100 / m_generationArguments.Amount * (i + 1);
                    this.ReportProgress(progress, "Generating Stars");
                }
                db.CelestialBodySet.AddRange(stars);
                db.SaveChanges();
            }
        }

        private int CreateCluster()
        {
            using (var db = PhContext.CreateContext())
            {
                this.ReportProgress(0, "Create Cluster");
                var cluster = db.ClusterSet.Create();
                cluster.Name = m_generationArguments.Name;
                cluster.ExtentX = m_generationArguments.ExtentX;
                cluster.ExtentY = m_generationArguments.ExtentY;
                db.ClusterSet.Add(cluster);
                db.SaveChanges();
                this.ReportProgress(100, "Create Cluster");
                return cluster.Id;
            }
        }
    }
}
