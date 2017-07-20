using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Mvc;
using ph_model;


namespace ph_admin.Controllers
{
    public class GenerationController : Controller
    {
        // GET: Generation
        public ActionResult Index()
        {
            return View(new Universe());
        }

        public ActionResult AddCluster()
        {
            return View();
        }

        //[HttpPost]
        //public async Task<JsonResult> AddCluster(Cluster cluster)
        //{

        //    var result = await ph_logic.Admin.Generation.GenerateClusterAsync(cluster.Name, cluster.StarsToGenerate, cluster.ExtentX, cluster.ExtentY);
        //    //return RedirectToAction("Index", "Generation");
        //    return Json(result);
        //}


        [HttpPost]
        public JsonResult AddCluster(Cluster cluster)
        {

            var key = ph_logic.Admin.Generation.StartBackgroundClusterGeneration(cluster.Name, cluster.StarsToGenerate, cluster.ExtentX, cluster.ExtentY);
            var result =  new {Success = true, Key = key};
            return Json(result);
        }

    }
}
