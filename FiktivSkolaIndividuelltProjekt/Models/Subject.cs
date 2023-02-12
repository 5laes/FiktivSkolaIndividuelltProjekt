using System;
using System.Collections.Generic;

namespace FiktivSkolaIndividuelltProjekt.Models
{
    public partial class Subject
    {
        public Subject()
        {
            SetGrades = new HashSet<SetGrade>();
        }

        public int Id { get; set; }
        public string SubjectName { get; set; } = null!;

        public virtual ICollection<SetGrade> SetGrades { get; set; }
    }
}
