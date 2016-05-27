using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace SalomatinDZ3
{
    [Serializable]
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int Salary { get; set; }
        public Employee()
        { }
        public Employee (string name, int age, string position, int salary)
        {
            Name = name;
            Age = age;
            Position = position;
            Salary = salary;

        }
    }
}
