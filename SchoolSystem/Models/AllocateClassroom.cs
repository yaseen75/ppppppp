//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AllocateClassroom
    {
        public int ClassId { get; set; }
        public int CourseId { get; set; }
        public System.TimeSpan FromTime { get; set; }
        public System.TimeSpan ToTime { get; set; }
        public string Action { get; set; }
    
        public virtual Course Course { get; set; }
    }
}
