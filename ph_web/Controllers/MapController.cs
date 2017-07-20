using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using ph_web.Models;
using ph_logic;
using ph_logic.Celestial;
using ph_model;
using ph_web.ViewModels.Map;

namespace ph_web.Controllers
{
    public class MapController : Controller
    {
        // GET: Map
        public ActionResult Index()
        {
            return RedirectToAction("StarMap", "Map");
        }

        public ActionResult StarMap()
        {
            var homeSystemjson = CelestialManager.GetHomeSystem();
            var star = JsonConvert.DeserializeObject<Star>(homeSystemjson);
            return View(new ClusterInfo() { HomeSystemPosition = new Position() {X = star.X, Y = star.Y}, ClusterName = "test", HomeSystemName = star.Name});
        }

        [HttpPost]
        public ActionResult StarMap(ClientData clientData)
        {
            var top = clientData.Top > 1000 ? clientData.Top - 1000 : 1;
            var left = clientData.Left > 1000 ? clientData.Left - 1000 : 1;
            var width = clientData.Width + 1000;
            var height = clientData.Height + 1000;
            var visibleStars = CelestialManager.GetVisibleStars(top, left, width, height, new Position() {X = clientData.Left, Y = clientData.Top});

            return Json(visibleStars);
        }
    }
}
