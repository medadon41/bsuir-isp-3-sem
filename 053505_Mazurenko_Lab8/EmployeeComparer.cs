using _053505_Mazurenko_Lab8;
using System.Collections.Generic;

namespace __053505_Mazurenko_Lab8
{
    public class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee firstObject, Employee secondObject)
        {
            /*if (firstObject == null || secondObject == null) 
                return 0;
            if (firstObject.Name.Length > secondObject.Name.Length) 
                return 1;
            if (firstObject.Name.Length < secondObject.Name.Length) 
                return -1;
            return 0;*/

            return firstObject.Name.Length.CompareTo(secondObject.Name.Length);
        }
    }
}