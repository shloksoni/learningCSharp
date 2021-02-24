using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqAssignment1
{
    public class Program
    {
        IList<Employee> employeeList;
        IList<Salary> salaryList;


        public Program()
        {
            employeeList = new List<Employee>()
            {
                new Employee(){ EmployeeID = 1, EmployeeFirstName = "Rajiv", EmployeeLastName = "Desai", Age = 49},
                new Employee(){ EmployeeID = 2, EmployeeFirstName = "Karan", EmployeeLastName = "Patel", Age = 32},
                new Employee(){ EmployeeID = 3, EmployeeFirstName = "Sujit", EmployeeLastName = "Dixit", Age = 28},
                new Employee(){ EmployeeID = 4, EmployeeFirstName = "Mahendra", EmployeeLastName = "Suri", Age = 26},
                new Employee(){ EmployeeID = 5, EmployeeFirstName = "Divya", EmployeeLastName = "Das", Age = 20},
                new Employee(){ EmployeeID = 6, EmployeeFirstName = "Ridhi", EmployeeLastName = "Shah", Age = 60},
                new Employee(){ EmployeeID = 7, EmployeeFirstName = "Dimple", EmployeeLastName = "Bhatt", Age = 53}
            };
            salaryList = new List<Salary>()
            {
                new Salary(){ EmployeeID = 1, Amount = 1000, Type = SalaryType.Monthly},
                new Salary(){ EmployeeID = 1, Amount = 500, Type = SalaryType.Performance},
                new Salary(){ EmployeeID = 1, Amount = 100, Type = SalaryType.Bonus},
                new Salary(){ EmployeeID = 2, Amount = 3000, Type = SalaryType.Monthly},
                new Salary(){ EmployeeID = 2, Amount = 1000, Type = SalaryType.Bonus},
                new Salary(){ EmployeeID = 3, Amount = 1500, Type = SalaryType.Monthly},
                new Salary(){ EmployeeID = 4, Amount = 2100, Type = SalaryType.Monthly},
                new Salary(){ EmployeeID = 5, Amount = 2800, Type = SalaryType.Monthly},
                new Salary(){ EmployeeID = 5, Amount = 600, Type = SalaryType.Performance},
                new Salary(){ EmployeeID = 5, Amount = 500, Type = SalaryType.Bonus},
                new Salary(){ EmployeeID = 6, Amount = 3000, Type = SalaryType.Monthly},
                new Salary(){ EmployeeID = 6, Amount = 400, Type = SalaryType.Performance},
                new Salary(){ EmployeeID = 7, Amount = 4700, Type = SalaryType.Monthly}
            };
        }

        public static void Main()
        {
            Program program = new Program();

            program.Task1();

            program.Task2();

            program.Task3();
        }

        public void Task1()
        {
            // Q1 -> Print total Salary of all the employees with their corresponding names 
            //       in ascending order of their salary.
            System.Console.WriteLine("\n\n\n\n------------------------------------Task 1---------------------------------------------------\n\n");
            var query = salaryList.GroupBy(s => s.EmployeeID)
                    .Select(g =>
                    {

                        var results = g.Aggregate(new SalaryCalculator(), (acc, s) => acc.accum(s), acc => acc.compute());
                        return new
                        {
                            EmployeeId = g.Key,
                            results.TotalSalary
                        };

                    })
                    .Join(employeeList, g => g.EmployeeId, e => e.EmployeeID, (g, e) => new
                    {
                        g.EmployeeId,
                        g.TotalSalary,
                        e.EmployeeFirstName,
                        e.EmployeeLastName
                    })
                    .OrderBy(g => g.TotalSalary);



            foreach (var result in query)
            {
                System.Console.WriteLine($"{result.EmployeeFirstName} {result.EmployeeLastName} \tTotal salary:  Rs.{result.TotalSalary}");
            }



        }



        public void Task2()
        {
            //Q2 -> Print Employee details of 2nd oldest employee
            //      including his/her total monthly salary.
            System.Console.WriteLine("\n\n\n\n------------------------------------Task 2---------------------------------------------------\n\n");

            var query = salaryList.Where(s => (int)s.Type == 0)

                        .Join(employeeList, s => s.EmployeeID, e => e.EmployeeID, (s, e) => new
                        {
                            s.Amount,
                            e.EmployeeFirstName,
                            e.EmployeeLastName,
                            e.Age
                        })
                        .OrderByDescending(g => g.Age)
                        .Select(g => g);



            foreach (var result in query.Skip(1).Take(1))
            {
                System.Console.WriteLine($"{result.EmployeeFirstName} {result.EmployeeLastName} \tAge: {result.Age} \tMonthly salary:  Rs.{result.Amount}");
            }



        }
        public void Task3()
        {

            System.Console.WriteLine("\n\n\n\n------------------------------------Task 2---------------------------------------------------\n\n");

            var query = employeeList.Where(g => g.Age > 30)
                        .Join(salaryList, e => e.EmployeeID, s => s.EmployeeID, (e, s) => s)

                        .Aggregate(new SalaryCalculator(), (acc, s) => acc.accum(s), acc => acc.compute());

            System.Console.WriteLine($"Mean Monthly Salary : \t{query.MeanMonthlySalary}\nMean Performance Salary:  \t{query.MeanPerformanceSalary}\nMean Bonus Salary:  \t{query.MeanBonusSalary}");





        }
    }
}

