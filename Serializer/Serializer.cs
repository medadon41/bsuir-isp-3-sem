using _053505_Mazurenko_Lab9.Domain;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Serializer
{
    public class Serializer : ISerializer
    {
        IEnumerable<Company> DeSerializeByLINQ(string fileName)
        {

        }
        IEnumerable<Company> DeSerializeXML(string fileName)
        {

        }
        IEnumerable<Company> DeSerializeJSON(string fileName)
        {

        }
        void SerializeByLINQ(IEnumerable<Company> xxx, string fileName)
        {

        }
        void SerializeXML(IEnumerable<Company> xxx, string fileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(IEnumerable<Company>));

        }
        void SerializeJSON(IEnumerable<Company> xxx, string fileName)
        {

        }
    }
}
