namespace _053505_Mazurenko_Lab8
{
    public class Employee
    {
        public string Name { get; set; }
        
        public int Age { get; set; }
        
        public bool IsBelarus { get; set; }

        public Employee(string name, int age, bool isBelarus)
        {
            Name = name;
            Age = age;
            IsBelarus = isBelarus;
        }
    }
}