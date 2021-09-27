using System.Collections.Generic;
using System.IO;

namespace _053505_Mazurenko_Lab8
{
    public class FileService : IFileService
    {
        public IEnumerable<Employee> ReadFile(string fileName)
        {
            using var reader = new BinaryReader(File.Open(fileName, FileMode.Open));
            
            while (reader.PeekChar() > -1)
            {
                var name = reader.ReadString();
                var age = reader.ReadInt32();
                var isBelarus = reader.ReadBoolean();
                yield return new Employee(name, age, isBelarus);
            }
        }

        public void SaveData(IEnumerable<Employee> data, string fileName)
        {
            using var writer = new BinaryWriter(File.Open(fileName, FileMode.OpenOrCreate));
            
            foreach (var employee in data)
            {
                writer.Write(employee.Name);
                writer.Write(employee.Age);
                writer.Write(employee.IsBelarus);
            }
        }
    }
}