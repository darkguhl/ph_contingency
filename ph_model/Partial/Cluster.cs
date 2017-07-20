using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ph_model
{

    public partial class Cluster
    {
        public int StarsToGenerate { get; set; }
    }

    [MetadataType(typeof(Cluster.Metadata))]
    public partial class Cluster
    {
        sealed class Metadata
        {
            
        }
    
    }
}
