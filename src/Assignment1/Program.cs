
using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Please enter Id Name and Department Name in different lines");
            int userIdInput = Int32.Parse(Console.ReadLine());
            string userNameInput = Console.ReadLine();
            string userDepartmentNameInput = Console.ReadLine();
            var emp = new Employee(userIdInput, userNameInput, userDepartmentNameInput);
            emp.MethodCalled += OnMethodCalled;
            DisplayEmployeeDetails(emp);
            System.Console.WriteLine($"The id is {emp.GetId()}");

        }
        static void DisplayEmployeeDetails(Employee emp)
        {
            System.Console.WriteLine($"The id is {emp.GetId()}");
            System.Console.WriteLine($"The name is {emp.GetName()}");
            System.Console.WriteLine($"The department Name is {emp.GetDepartmentName()}");
            emp.ModifyEmployeeData(10);
        }
        static void OnMethodCalled(object sender, EventArgs e, string methodName)
        {
            System.Console.WriteLine($"{methodName} is invoked");
        }
    }
}