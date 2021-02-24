using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] colorOptions = { "Red", "Espresso", "White", "Navy" };
            foreach (var color in colorOptions)
            {
                color = color.ToLower();
                Console.WriteLine(color);
            }


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
