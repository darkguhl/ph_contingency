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
    
    public partial class Corporation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Corporation()
        {
            this.SkillAssignments = new HashSet<SkillAssignment>();
            this.FeatureAssignments = new HashSet<FeatureAssignment>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual User Users { get; set; }
        public virtual Cluster Cluster { get; set; }
        public virtual Class Class { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SkillAssignment> SkillAssignments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FeatureAssignment> FeatureAssignments { get; set; }
    }
}