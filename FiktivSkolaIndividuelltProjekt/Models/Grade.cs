using System;
using System.Collections.Generic;

namespace FiktivSkolaIndividuelltProjekt.Models
{
    public partial class Grade
    {
        public Grade()
        {
            SetGrades = new HashSet<SetGrade>();
        }

        public int Id { get; set; }
        public string Grade1 { get; set; } = null!;

        public virtual ICollection<SetGrade> SetGrades { get; set; }
    }
}
