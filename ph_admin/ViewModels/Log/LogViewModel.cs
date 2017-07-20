using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ph_model;

namespace ph_admin.ViewModels.Log
{
    public class LogViewModel
    {
        public IList<LogEntry> LogEntries { get; set; }
    }
}
