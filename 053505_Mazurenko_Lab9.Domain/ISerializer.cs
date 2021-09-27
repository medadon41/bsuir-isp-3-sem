using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _053505_Mazurenko_Lab9.Domain
{
    public interface ISerializer
    {
        IEnumerable<Company> DeSerializeByLINQ(string fileName);
        IEnumerable<Company> DeSerializeXML(string fileName);
        IEnumerable<Company> DeSerializeJSON(string fileName);
        void SerializeByLINQ(IEnumerable<Company> xxx, string fileName);
        void SerializeXML(IEnumerable<Company> xxx, string fileName);
        void SerializeJSON(IEnumerable<Company> xxx, string fileName);
    }
}
