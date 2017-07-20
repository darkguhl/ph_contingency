using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ph_model
{
    public class Universe
    {
        public IEnumerable<Cluster> Clusters
        {
            get { return GetAllClusters(); }
        }

        private IEnumerable<Cluster> GetAllClusters()
        {
            using (var db = PhContext.CreateContext())
            {
                return db.ClusterSet.Include("Stars").ToList();
            }
        }
    }
}
