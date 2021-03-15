using System;
using System.Collections.Generic;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            Employee emp1 = new Employee(25, "A", 30);
            Employee emp2 = new Employee(26, "B", 40);
            Employee emp3 = new Employee(27, "C", 50);
            Employee emp4 = new Employee(28, "D", 60);
            Employee emp5 = new Employee(29, "E", 70);

            list.Add(emp1);
            list.Add(emp2);
            list.Add(emp3);
            list.Add(emp4);
            list.Add(emp5);

            IsPromotable isPromotable = new IsPromotable(Promotable);

            Employee.IsEmployeePromotable(list, Promotable);
        }

        private static bool Promotable(Employee emp)
        {
            if (emp.Salary > 50)
                return true;
            else
                return false;
        }
    }

    delegate bool IsPromotable(Employee emp);

    class Employee
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public Employee(int Age,string Name, int Salary)
        {
            this.Age = Age;
            this.Name = Name;
            this.Salary = Salary;
        }

        public static void IsEmployeePromotable(List<Employee> list,IsPromotable isPromotable)
        {
            foreach(Employee emp in list)
            {
                if (isPromotable(emp))
                {
                    Console.WriteLine(emp.Name + " is promotable");
                }
            }
        }
    }
}
