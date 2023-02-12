using FiktivSkolaIndividuelltProjekt.Models;
using System.Security.Cryptography.X509Certificates;

namespace FiktivSkolaIndividuelltProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FictionalSchoolDbContext context = new FictionalSchoolDbContext();
            ProgramStart(context);
        }

        public static void ProgramStart(FictionalSchoolDbContext context)
        {
            Console.Clear();
            Console.Write("\n\tVad vill du göra?" +
                "\n\t[1]Visa alla elever" +
                "\n\t[2]Visa alla elever i en klass" +
                "\n\t[3]Lägg till ny personal" +
                "\n\t[4]Antal personal per avdelning" +
                "\n\t[5]Visa All Information om alla elever" +
                "\n\t[6]Visa aktiva kurser" +
                "\n\t[7]Avsluta Program" +
                "\n\t: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    ShowAllStudents(context);
                    break;

                case 2:
                    ShowSpecificClassStudents(context);
                    break;

                case 3:
                    AddEmployee(context);
                    break;

                case 4:
                    ShowEmployeeByDepartment(context);
                    break;

                case 5:
                    ShowAllInfoAllStudents(context);
                    break;

                case 6:
                    ShowActiveCourses(context);
                    break;

                case 7:
                    Environment.Exit(0);
                    break;

                default:
                    Console.Write("\n\t!!!ERROR!!!");
                    Console.ReadLine();
                    ProgramStart(context);
                    break;
            }
        }

        public static void ShowAllStudents(FictionalSchoolDbContext context)
        {
            Console.Clear();
            bool nameSort = SortByFirstOrLastName();
            bool sortOrder = SortAccendingOrDecending();

            Console.Clear();
            if (nameSort == true && sortOrder == true)
            {
                var students = context.Students
                    .OrderBy(x => x.FirstName);
                foreach (var item in students)
                {
                    Console.Write($"\n\t{item.FirstName} {item.LastName}");
                }
            }

            if (nameSort == true && sortOrder == false)
            {
                var students = context.Students
                    .OrderByDescending(x => x.FirstName);
                foreach (var item in students)
                {
                    Console.Write($"\n\t{item.FirstName} {item.LastName}");
                }
            }

            if (nameSort == false && sortOrder == true)
            {
                var students = context.Students
                    .OrderBy(x => x.LastName);
                foreach (var item in students)
                {
                    Console.Write($"\n\t{item.LastName} {item.FirstName}");
                }
            }

            if (nameSort == false && sortOrder == false)
            {
                var students = context.Students
                    .OrderByDescending(x => x.LastName);
                foreach (var item in students)
                {
                    Console.Write($"\n\t{item.LastName} {item.FirstName}");
                }
            }
            Console.ReadLine();
            ProgramStart(context);
        }

        public static bool SortByFirstOrLastName()
        {
            Console.Clear();
            Console.Write("\n\tVill du sortera efter förnamn eller efternamn?" +
                "\n\t[1]Förnamn" +
                "\n\t[2]Efternamn" +
                "\n\t: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    return true;

                case 2:
                    return false;

                default:
                    return true;
            }
        }

        public static bool SortAccendingOrDecending()
        {
            Console.Clear();
            Console.Write("\n\tVill du sortersa A till Ö eller Ö till A?" +
                "\n\t[1]A till Ö" +
                "\n\t[2]Ö till A" +
                "\n\t: ");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    return true;

                case 2:
                    return false;

                default:
                    return true;
            }
        }

        public static void ShowSpecificClassStudents(FictionalSchoolDbContext context)
        {
            Console.Clear();
            int classNumber = GetClassNumber(context);
            bool nameSort = SortByFirstOrLastName();
            bool sortOrder = SortAccendingOrDecending();

            Console.Clear();
            if (nameSort == true && sortOrder == true)
            {
                var students = context.Students
                    .Where(x => x.ClassYearId == classNumber)
                    .OrderBy(x => x.FirstName);

                foreach (var item in students)
                {
                    Console.Write($"\n\t{item.FirstName} {item.LastName}");
                }
            }

            if (nameSort == true && sortOrder == false)
            {
                var students = context.Students
                    .Where(x => x.ClassYearId == classNumber)
                    .OrderByDescending(x => x.FirstName);

                foreach (var item in students)
                {
                    Console.Write($"\n\t{item.FirstName} {item.LastName}");
                }
            }

            if (nameSort == false && sortOrder == true)
            {
                var students = context.Students
                    .Where(x => x.ClassYearId == classNumber)
                    .OrderBy(x => x.LastName);

                foreach (var item in students)
                {
                    Console.Write($"\n\t{item.LastName} {item.FirstName}");
                }
            }

            if (nameSort == false && sortOrder == false)
            {
                var students = context.Students
                    .Where(x => x.ClassYearId == classNumber)
                    .OrderByDescending(x => x.LastName);

                foreach (var item in students)
                {
                    Console.Write($"\n\t{item.LastName} {item.FirstName}");
                }
            }
            Console.ReadLine();
            ProgramStart(context);
        }

        public static int GetClassNumber(FictionalSchoolDbContext context)
        {
            int choiceNumber = 1;

            Console.Clear();
            Console.Write("\n\tVilken klass vill du kolla på?");
            var classes = context.ClassYears
                .Select(x => x.Id);

            foreach (var item in classes)
            {
                Console.Write($"\n\t[{choiceNumber}]{item}");
                choiceNumber++;
            }

            Console.Write("\n\t: ");
            int.TryParse(Console.ReadLine(), out int choice);

            if (choice < 1 || choice > 9)
            {
                return 1;
            }
            else
            {
                return choice;
            }
        }

        public static void AddEmployee(FictionalSchoolDbContext context)
        {
            Console.Clear();
            Console.Write("\n\tAnge Förnamn     :");
            string firstName = Console.ReadLine();
            Console.Write("\n\tAnge Efternamn   :");
            string lastName = Console.ReadLine();
            Console.Write("\n\tAnge Ålder       :");
            int.TryParse(Console.ReadLine(), out int age);

            int index = 1;
            var proffession = context.Proffessions;
            Console.Write("\n\tVad är deras anställning");
            foreach (var item in proffession)
            {
                Console.Write($"\n\t[{index}]{item.ProffessionName}");
                index++;
            }
            Console.Write("\n\t: ");
            int.TryParse(Console.ReadLine(), out int professionIndex);

            Console.Write("\n\tAnge Lön         :");
            decimal.TryParse(Console.ReadLine(), out decimal salary);

            Employee newEmployee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                DateOfEmployment = DateTime.Now,
                Salary  = salary,
                ProffessionId = professionIndex
            };

            context.Employees.Add(newEmployee);
            context.SaveChanges();
            ProgramStart(context);
        }

        public static void ShowEmployeeByDepartment(FictionalSchoolDbContext context)
        {
            Console.Clear();
            for (int i = 1; i < context.Proffessions.Count(); i++)
            {
                var professionName = context.Proffessions
                    .Where(x => x.Id == i)
                    .Select(x => x.ProffessionName)
                    .FirstOrDefault();

                var departmentEmployees = context.Employees
                    .Where(x => x.ProffessionId == i);

                Console.Write($"\n\tAntal {professionName}: {departmentEmployees.Count()}");
                foreach (var employee in departmentEmployees)
                {
                    Console.Write($"\n\t{employee.FirstName} {employee.LastName}");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            ProgramStart(context);
        }

        public static void ShowAllInfoAllStudents(FictionalSchoolDbContext context)
        {
            Console.Clear();
            var students = context.Students
                .OrderBy(x => x.FirstName);
            foreach (var student in students)
            {
                Console.Write($"\n\t[First Name: {student.FirstName} | Last Name: {student.LastName} | Age: {student.Age} | Class Year: {student.ClassYearId}]\n\t");
            }
            Console.ReadLine();
            ProgramStart(context);
        }

        public static void ShowActiveCourses(FictionalSchoolDbContext context)
        {
            Console.Clear();
            var subjects = context.Subjects;
            foreach (var subject in subjects)
            {
                Console.Write($"\n\t{subject.SubjectName}");
            }
            Console.ReadLine();
            ProgramStart(context);
        }
    }
}