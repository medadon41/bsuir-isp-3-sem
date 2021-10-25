using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053505_Mazurenko_Lab10
{
    class Employee
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public bool IsIt { get; set; }

        public Employee()
        {

        }

        public Employee(string name, int age, bool isBelarus)
        {
            Name = name;
            Age = age;
            IsIt = isBelarus;
        }
    }
}
