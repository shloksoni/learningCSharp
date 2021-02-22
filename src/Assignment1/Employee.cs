using System;

namespace Assignment1
{
    public delegate void MethodCalledDelegate(object sender, EventArgs args, string methodName);
    public class Employee
    {
        public Employee(int id, string name, string departmentName)
        {
            this.id = id;
            this.name = name;
            this.departmentName = departmentName;
        }
        public int GetId()
        {
            if (MethodCalled != null)
            {
                MethodCalled(this, new EventArgs(), "GetId()");
            }
            return id;
        }
        public string GetName()
        {
            if (MethodCalled != null)
            {
                MethodCalled(this, new EventArgs(), "GetName()");
            }
            return name;
        }
        public string GetDepartmentName()
        {
            if (MethodCalled != null)
            {
                MethodCalled(this, new EventArgs(), "GetDepartmentName()");
            }
            return departmentName;
        }

        public void ModifyEmployeeData(int id)
        {
            this.id = id;
        }
        public void ModifyEmployeeData(string name)
        {
            this.name = name;
        }
        public void ModifyEmployeeData(string name, string departmentName)
        {
            this.name = name;
            this.departmentName = departmentName;
        }

        public event MethodCalledDelegate MethodCalled;
        int id;
        string name, departmentName;
    }
}