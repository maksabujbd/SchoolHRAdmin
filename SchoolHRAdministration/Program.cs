// See https://aka.ms/new-console-template for more information

using HRAdministrationAPI;

namespace SchoolHRAdministration
{
    public enum EmployeeType
    {
        Teacher,
        HeadOfDepartment,
        DeputyHeadMaster,
        HeadMaster
    }

    class Program
    {
        static void Main(string[] args)
        {
            decimal totalSalaries = 0;
            List<IEmployee> employees = new List<IEmployee>();
            SeedData(employees);
            // foreach (IEmployee employee in employees)
            // {
            //     totalSalaries += employee.Salary;
            // }
            //
            // Console.WriteLine($"Total Annual Salaries (including bonus): {totalSalaries}");

            Console.WriteLine($"Total Annual Salaries (including bonus): {employees.Sum(x => x.Salary)}");
        }

        public static void SeedData(List<IEmployee> employees)
        {
            // IEmployee teacher1 = new Teacher
            // {
            //     Id = 1, FirstName = "Abdul", LastName = "Kader", Salary = 40000
            // };
            // employees.Add(teacher1);
            // IEmployee teacher2 = new Teacher
            // {
            //     Id = 2, FirstName = "Jannatul", LastName = "Ferdows", Salary = 40000
            // };
            // employees.Add(teacher2);
            //
            // IEmployee headOfDepartment = new HeadOfDepartment
            // {
            //     Id = 3, FirstName = "Alifa", LastName = "Bint Kader", Salary = 50000
            // };
            // employees.Add(headOfDepartment);
            // IEmployee deputyHeadMaster = new DeputyHeadMaster
            // {
            //     Id = 4, FirstName = "Kamrul", LastName = "Hasan", Salary = 60000
            // };
            // employees.Add(deputyHeadMaster);
            //
            // IEmployee headMaster = new HeadMaster
            // {
            //     Id = 5, FirstName = "Siddiqur", LastName = "Rahman", Salary = 80000
            // };
            // employees.Add(headMaster);
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Abdul", "kader", 40000);
            employees.Add(teacher1);
            IEmployee teacher2 =
                EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Jannatul", "Ferdows", 40000);
            employees.Add(teacher2);
            IEmployee headOfDepartment =
                EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadOfDepartment, 3, "Alifa", "Bint Kader", 50000);
            employees.Add(headOfDepartment);
            IEmployee deputyHeadMaster =
                EmployeeFactory.GetEmployeeInstance(EmployeeType.DeputyHeadMaster, 4, "Kamrul", "Hasan", 60000);
            employees.Add(deputyHeadMaster);
            IEmployee headMaster =
                EmployeeFactory.GetEmployeeInstance(EmployeeType.HeadMaster, 4, "Siddiqur", "Rahman", 80000);
            employees.Add(headMaster);
        }
    }

    public class Teacher : EmployeeBase
    {
        public override decimal Salary => base.Salary * (1 + 0.02m);
    }

    public class HeadOfDepartment : EmployeeBase
    {
        public override decimal Salary => base.Salary * (1 + 0.03m);
    }

    public class DeputyHeadMaster : EmployeeBase
    {
        public override decimal Salary => base.Salary * (1 + 0.04m);
    }

    public class HeadMaster : EmployeeBase
    {
        public override decimal Salary => base.Salary * (1 + 0.05m);
    }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(
            EmployeeType employeeType, int id, string firstName,
            string lastName, decimal salary)
        {
            IEmployee employee = null;

            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    // employee = new Teacher { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    break;
                case EmployeeType.HeadOfDepartment:
                    // employee = new HeadOfDepartment
                    //     { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    employee = FactoryPattern<IEmployee, HeadOfDepartment>.GetInstance();
                    break;
                case EmployeeType.DeputyHeadMaster:
                    // employee = new DeputyHeadMaster
                    //     { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    employee = FactoryPattern<IEmployee, DeputyHeadMaster>.GetInstance();
                    break;
                case EmployeeType.HeadMaster:
                    // employee = new HeadMaster
                    //     { Id = id, FirstName = firstName, LastName = lastName, Salary = salary };
                    employee = FactoryPattern<IEmployee, HeadMaster>.GetInstance();
                    break;
                default:
                    break;
            }

            if (employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.Salary = salary;
            }
            else
            {
                throw new NullReferenceException();
            }

            return employee!;
        }
    }
}

// Console.WriteLine("Hello, World!");