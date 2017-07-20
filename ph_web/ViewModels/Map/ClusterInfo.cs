using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ph_model;

namespace ph_web.ViewModels.Map
{
    public class ClusterInfo
    {
        public  string HomeSystemName { get; set; }
        public Position HomeSystemPosition { get; set; }
        public string ClusterName { get; set; }
    }
}
