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
    
    public partial class SkillAssignment
    {
        public int Id { get; set; }
        public int SkillId { get; set; }
        public int CorporationId { get; set; }
    
        public virtual Skill Skill { get; set; }
        public virtual Corporation Corporation { get; set; }
    }
}