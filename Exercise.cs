//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exercise
    {
        public int ExerciseId { get; set; }
        public Nullable<int> SetId { get; set; }
        public Nullable<int> GymExerciseId { get; set; }
    
        public virtual GymExercise GymExercise { get; set; }
        public virtual Set Set { get; set; }
    }
}
