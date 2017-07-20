using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ph_admin.ViewModels.Log;
using ph_model;

namespace ph_admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Log()
        {
            ph_model.Log.Instance.FlushLog();
            using (LogContext db = LogContext.CreateContext())
            {
                var entries = db.LogEntrySet.OrderBy(x => x.Time).ToList();
                var vm = new LogViewModel() {LogEntries = entries};
                return View(vm);
            }
        }
    }
}
