using System;
using System.Collections.Generic;

namespace FiktivSkolaIndividuelltProjekt.Models
{
    public partial class Student
    {
        public Student()
        {
            SetGrades = new HashSet<SetGrade>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public int ClassYearId { get; set; }

        public virtual ClassYear ClassYear { get; set; } = null!;
        public virtual ICollection<SetGrade> SetGrades { get; set; }
    }
}
