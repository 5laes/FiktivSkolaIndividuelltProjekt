using System;
using System.Collections.Generic;

namespace FiktivSkolaIndividuelltProjekt.Models
{
    public partial class Employee
    {
        public Employee()
        {
            SetGrades = new HashSet<SetGrade>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public decimal Salary { get; set; }
        public int ProffessionId { get; set; }

        public virtual Proffession Proffession { get; set; } = null!;
        public virtual ICollection<SetGrade> SetGrades { get; set; }
    }
}
