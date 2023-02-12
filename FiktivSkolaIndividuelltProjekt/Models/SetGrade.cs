using System;
using System.Collections.Generic;

namespace FiktivSkolaIndividuelltProjekt.Models
{
    public partial class SetGrade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int GradeId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime TimeOfGrade { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual Grade Grade { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
        public virtual Subject Subject { get; set; } = null!;
    }
}
