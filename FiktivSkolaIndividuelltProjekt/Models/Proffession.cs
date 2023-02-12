using System;
using System.Collections.Generic;

namespace FiktivSkolaIndividuelltProjekt.Models
{
    public partial class Proffession
    {
        public Proffession()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string ProffessionName { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
