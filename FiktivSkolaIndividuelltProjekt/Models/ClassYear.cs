using System;
using System.Collections.Generic;

namespace FiktivSkolaIndividuelltProjekt.Models
{
    public partial class ClassYear
    {
        public ClassYear()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string ClassYear1 { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
