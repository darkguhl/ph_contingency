//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ph_model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CelestialBody
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CelestialBody()
        {
            this.DestinationFleets = new HashSet<Fleet>();
        }
    
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public string Name { get; set; }
        public Dimension Dimension { get; set; }
        public Nullable<double> Angle { get; set; }
        public Nullable<double> Radius { get; set; }
        public string CssClass { get; set; }
    
        public virtual Station Station { get; set; }
        public virtual Fleet OriginFleet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Fleet> DestinationFleets { get; set; }
    }
}