//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace netProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class registStudent2Course
    {
     
        public int Id_lecturer { get; set; }
        public Nullable<int> id_course { get; set; }
        public Nullable<int> id_student { get; set; }
        public int FinalGrade { get; set; }
    
        public virtual course course { get; set; }
        public virtual Lecturer Lecturer { get; set; }
        public virtual student student { get; set; }
    }
}
