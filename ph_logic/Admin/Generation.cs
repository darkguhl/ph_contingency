using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ph_model;

namespace ph_logic.Admin
{
    public static class Generation
    {
        //public static async  Task<string> GenerateClusterAsync(string name, int starsToGenerate, int extentX, int extentY)
        //{
        //    using (var db = PhContext.CreateContext())
        //    {
        //        var cluster = db.ClusterSet.Create();
        //        cluster.Name = name;
        //        cluster.ExtentX = extentX;
        //        cluster.ExtentY = extentY;

        //        List<Star> stars = GenerateStars(db, cluster, starsToGenerate);
        //        stars.ForEach(s => GenerateSystem(db, s));
        //        db.CelestialBodySet.AddRange(stars);
        //        db.ClusterSet.Add(cluster);
        //        await db.SaveChangesAsync();
        //        var result = JsonConvert.SerializeObject(new { cluster = cluster }, Formatting.Indented, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        //        return result;
        //    }
        //}

        public static Guid StartBackgroundClusterGeneration(string name, int starsToGenerate, int extentX, int extentY)
        {
            var backgroundGenerator = new BackgroundGenerator();
            return backgroundGenerator.StartGeneration(name, starsToGenerate,extentX, extentX);
        }

        public static CelestialBody GeneratePlanet(PhContext db, int distance, Star mainStar)
        {
            var position = new Position();
            // Check for existing Objects that collide
            var collision = true;
            var radius = Utility.GetOrbitalRadius(distance);
            double angle = Utility.RandomNumber(0, 360);
            while (collision)
            {
                position = Utility.GetOrbitalObjectPosition(radius, angle, new Position() {X= 0, Y=0}, 1);
                collision = CheckforSystemCollision(position, mainStar);
            }

            Planet planet = db.CelestialBodySet.Create<Planet>();
            planet.Star = mainStar;
            planet.Type = GetPlanetType(distance);
            planet.Name = GetSystemBodyName(distance, mainStar.Name);
            planet.Dimension = GetBodyDimension();
            planet.Angle = angle;
            planet.Radius = radius;

            GenerateMoons(db, planet, 0, 3);

            return planet;
        }

        public static void GenerateMoons(PhContext db, Planet p, int minAmount, int maxAmount)
        {
            //Determine Number of Moons
            int Moons = Utility.RandomNumber(minAmount, maxAmount);

            for (int i = 0; i < Moons; i++)
            {
                Position pos = new Position();
                
                var dim = GetBodyDimension();
                double size = dim == Dimension.Large ? 25 : dim == Dimension.Small ? 15 : 20;
                double planetSize = p.Dimension ==  Dimension.Large ? 100 : p.Dimension == Dimension.Small ? 50 : 75;
                double radius = planetSize / 2 + 15 + size / 2;
                double moonangle = 0;
                int count = 0;
                // Check for existing Moons that collide
                bool collision = true;
                bool noMoreSpace = false;

                while (collision)
                {
                    // Recalculate angle and position
                    moonangle = Utility.RandomNumber(45, 315);
                    pos = Utility.GetMoonPosition(radius, moonangle, p.X, p.Y, 1);

                    collision = CheckforMoonCollision(pos, p);

                    // if after 100 tries, there is still a collision no moon will be added
                    count++;
                    if (count <= 100) continue;
                    noMoreSpace = true;
                    collision = false;
                }
                if (noMoreSpace) continue;
                //new moon
                var moon = db.CelestialBodySet.Create<Moon>();
                moon.Planet = p;
                moon.Angle = moonangle;
                moon.Radius = radius;
                moon.Dimension = GetBodyDimension();
                moon.Name = p.Name + " Moon " + i+1;
                moon.Type = GetMoonType();

                db.CelestialBodySet.Add(moon);
            }
        }

        public static CelestialBody GenerateAsteroid(PhContext db, int distance, Star mainStar)
        {
            var position = new Position();
            // Check for existing Objects that collide
            var collision = true;
            var radius = Utility.GetOrbitalRadius(distance);
            double angle = Utility.RandomNumber(0, 360);
            while (collision)
            {
                position = Utility.GetOrbitalObjectPosition(radius, angle, new Position() { X = 0, Y = 0 }, 1);
                collision = CheckforSystemCollision(position, mainStar);
            }

            Asteroid asteroid = db.CelestialBodySet.Create<Asteroid>();
            asteroid.Star = mainStar;
            asteroid.Type = GetAsteroidType();
            asteroid.Name = GetSystemBodyName(distance, mainStar.Name);
            asteroid.Dimension = GetBodyDimension();
            asteroid.Angle = angle;
            asteroid.Radius = radius;

            return asteroid;
        }

        public static CelestialBody GenerateNebula(PhContext db, int distance, Star mainStar)
        {
            var position = new Position();
            // Check for existing Objects that collide
            var collision = true;
            var radius = Utility.GetOrbitalRadius(distance);
            double angle = Utility.RandomNumber(0, 360);
            while (collision)
            {
                position = Utility.GetOrbitalObjectPosition(radius, angle, new Position() { X = 0, Y = 0 }, 1);
                collision = CheckforSystemCollision(position, mainStar);
            }

            Nebula nebula = db.CelestialBodySet.Create<Nebula>();
            nebula.Star = mainStar;
            nebula.Type = GetNebulaType();
            nebula.Name = GetSystemBodyName(distance, mainStar.Name);
            nebula.Dimension = GetBodyDimension();
            nebula.Angle = angle;
            nebula.Radius = radius;

            return nebula;
        }

        private static bool CheckforSystemCollision(Position pos, Star parentSun)
        {
            bool col = true;

            col = parentSun.Planets.Any(x => x.X < pos.X + 140 && x.X > pos.X - 140 &&
                                             x.Y < pos.Y + 140 && x.Y > pos.Y - 140);

            col = parentSun.Planets.Any(x => x.X < pos.X + 140 && x.X > pos.X - 140 &&
                                             x.Y < pos.Y + 140 && x.Y > pos.Y - 140);

            col = parentSun.Nebulas.Any(x => x.X < pos.X + 140 && x.X > pos.X - 140 &&
                                             x.Y < pos.Y + 140 && x.Y > pos.Y - 140);

            return col;
        }

        private static bool CheckforMoonCollision(Position pos, Planet planet)
        {
            bool col = true;

            col = planet.Moons.Any(x => x.X < pos.X + 30 && x.X > pos.X - 30 &&
                                        x.Y < pos.Y + 30 && x.Y > pos.Y - 30);
            return col;
        }

        // Generate Planet Type based on Distance to Sun
        private static PlanetType GetPlanetType(int i)
        {
            PlanetType type = PlanetType.Lava;
            int random;
            switch (i)
            {
                case 0:
                    random = Utility.RandomNumber(0, 1);
                    switch (random)
                    {
                        case 0: type = PlanetType.Lava; break;
                        case 1: type = PlanetType.Gas; break;
                    }
                    break;
                case 1:
                    random = Utility.RandomNumber(0, 1);
                    switch (random)
                    {
                        case 0: type = PlanetType.Lava; break;
                        case 1: type = PlanetType.Terra; break;
                    }
                    break;
                case 2:
                    random = Utility.RandomNumber(0, 1);
                    switch (random)
                    {
                        case 0: type = PlanetType.Terra; break;
                        case 1: type = PlanetType.Gas; break;
                    }
                    break;
                case 3:
                    random = Utility.RandomNumber(0, 1);
                    switch (random)
                    {
                        case 0: type = PlanetType.Terra; break;
                        case 1: type = PlanetType.Gas; break;
                    }
                    break;
                case 4:
                    random = Utility.RandomNumber(0, 1);
                    switch (random)
                    {
                        case 0: type = PlanetType.Terra; break;
                        case 1: type = PlanetType.Ice; break;
                    }
                    break;
                case 5:
                    random = Utility.RandomNumber(0, 1);
                    switch (random)
                    {
                        case 0: type = PlanetType.Ice; break;
                        case 1: type = PlanetType.Gas; break;
                    }
                    break;
                case 6:
                    random = Utility.RandomNumber(0, 1);
                    switch (random)
                    {
                        case 0: type = PlanetType.Gas; break;
                        case 1: type = PlanetType.Ice; break;
                    }
                    break;

            }

            return type;
        }

        private static string GetSystemBodyName(int i, string starname)
        {
            string name = starname;
            switch (i)
            {
                case 0:
                    name = name + (" Alpha");
                    break;
                case 1:
                    name = name + (" Beta");
                    break;
                case 2:
                    name = name + (" Gamma");
                    break;
                case 3:
                    name = name + (" Delta");
                    break;
                case 4:
                    name = name + (" Epsilon");
                    break;
                case 5:
                    name = name + (" Phi");
                    break;
                case 6:
                    name = name + (" Omega");
                    break;

            }

            return name;


        }

        public static Type GetSystemObjectType()
        {
            int celstialObjectType = Utility.RandomNumber(1, 100);
            if (celstialObjectType < 76)
            {
                return typeof(Planet);
            }
            else if (celstialObjectType > 75)
            {
                if (celstialObjectType > 95)
                {
                    return typeof(Nebula);
                }

                return typeof(Asteroid);
            }
            return null;
        }

        public static StarType GetStarType()
        {
            StarType type = StarType.Typeg;
            int random = Utility.RandomNumber(0, 100);

            if (random > 98)
            {
                type = StarType.Supernova;
            }
            else if (random < 99 && random > 85)
            {
                type = StarType.Dualstar;
            }
            else if (random < 86 && random > 65)
            {
                type = StarType.Redgiant;
            }
            else if (random < 66 && random > 50)
            {
                type = StarType.Reddwarf;
            }
            else if (random < 51 && random > 35)
            {
                type = StarType.Whitedwarf;
            }
            return type;
        }

        private static AsteroidType GetAsteroidType()
        {
            AsteroidType type = AsteroidType.Stone;

            int t = Utility.RandomNumber(0, 2);
            switch (t)
            {
                case 0:
                    type = AsteroidType.Ice;
                    break;
                case 1:
                    type = AsteroidType.Metal;
                    break;
                case 2:
                    type = AsteroidType.Stone;
                    break;
            }
            return type;
        }

        private static NebulaType GetNebulaType()
        {
            NebulaType type = NebulaType.Argon;

            int t = Utility.RandomNumber(0, 2);
            switch (t)
            {
                case 0:
                    type = NebulaType.DiamondDust;
                    break;
                case 1:
                    type = NebulaType.Argon;
                    break;
                case 2:
                    type = NebulaType.Xenon;
                    break;
            }
            return type;
        }

        private static MoonType GetMoonType()
        {
            MoonType type = MoonType.Stone;
            int r = Utility.RandomNumber(0, 3);
            switch (r)
            {
                case 0:
                    type = MoonType.Ice;
                    break;
                case 1:
                    type = MoonType.Lava;
                    break;
                case 2:
                    type = MoonType.Terra;
                    break;
            }
            return type;
        }

        private static Dimension GetBodyDimension()
        {
            var random = Utility.RandomNumber(0, 2);
            var dim = Dimension.Medium;
            if (random == 0)
                dim = Dimension.Small;
            if (random == 2)
                dim = Dimension.Large;
            return dim;
        }

        #region Css

        public static string GetStarCssType(StarType type)
        {
            var cssclass = "typeg1";
            switch (type)
            {
                case StarType.Typeg:
                    cssclass = "typeg" + Utility.RandomNumber(1, 4);
                    break;
                case StarType.Dualstar:
                    cssclass = "dual" + Utility.RandomNumber(1, 2);
                    break;
                case StarType.Reddwarf:
                    cssclass = "dwarf" + Utility.RandomNumber(1, 2);
                    break;
                case StarType.Redgiant:
                    cssclass = "giant" + Utility.RandomNumber(1, 3);
                    break;
                case StarType.Supernova:
                    cssclass = "supernova" + Utility.RandomNumber(1, 2);
                    break;
            }

            return cssclass;
        }

        #endregion
    }
}
