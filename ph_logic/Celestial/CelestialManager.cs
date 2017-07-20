using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ph_model;

namespace ph_logic.Celestial
{
    public static class CelestialManager
    {
        public static string GetVisibleStars(int top, int left, int bottom, int right, Position center)
        {
            using (PhContext db = PhContext.CreateContext())
            {
                var visibleStars = db.CelestialBodySet.OfType<Star>().Where(
                    x => x.X > left && x.Y > top && x.X < right && x.Y < bottom
                    ).Select(x => new { x.Name, X = x.X - center.X , Y = x.Y - center.Y, x.CssClass });
                var result = JsonConvert.SerializeObject(new { stars = visibleStars});
                return result;
            }
        }

        public static string GetHomeSystem()
        {
            using (PhContext db = PhContext.CreateContext())
            {
                //todo get homesystem based on user corp in cluster
                var homeSystem = db.CelestialBodySet.OfType<Star>().FirstOrDefault(
                    x => x.X > 1000 && x.Y > 1000 && x.X < 2000 && x.Y < 2000
                    );
                //var result = JsonConvert.SerializeObject(homeSystem, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                var result = JsonConvert.SerializeObject(new Star() {X = homeSystem.X, Y =  homeSystem.Y, Name = homeSystem.Name});
                return result;
            }
        }
    }
}
