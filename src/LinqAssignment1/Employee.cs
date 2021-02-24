using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqAssignment1
{
    public enum SalaryType
    {
        Monthly,
        Performance,
        Bonus
    }
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int Age { get; set; }
    }

    public class Salary
    {
        public int EmployeeID { get; set; }
        public int Amount { get; set; }
        public SalaryType Type { get; set; }
    }
}