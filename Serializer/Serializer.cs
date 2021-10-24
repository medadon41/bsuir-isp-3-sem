using _053505_Mazurenko_Lab9.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace _053505_Mazurenko_Lab9
{
    public class Serializer : ISerializer
    {
        public IEnumerable<Company> DeSerializeByLINQ(string fileName)
        {
            List<Company> result = new();
            XDocument xdoc = XDocument.Load($"{fileName}.xml");
            foreach (XElement phoneElement in xdoc.Element("CompanyArray").Elements("Company"))
            {
                var name = phoneElement.Element("Name");
                var depart = phoneElement.Element("Depart");
                var workfrom = depart.Element("WorkFrom");
                var workto = depart.Element("WorkTo");

                result.Add(new Company { Name = name.Value, Depart = new Depart { WorkFrom = DateTime.Parse(workfrom.Value), WorkTo = DateTime.Parse(workto.Value) } });
            }

            return result;
        }
       public IEnumerable<Company> DeSerializeXML(string fileName)
        {
            XmlSerializer reader = new XmlSerializer(typeof(List<Company>));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"//{fileName}.xml";
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            var result = (IEnumerable<Company>)reader.Deserialize(file);
            file.Close();
            return result;
        }
        public IEnumerable<Company> DeSerializeJSON(string fileName)
        {
            var jsonString = File.ReadAllText($"{fileName}.json");
            IEnumerable<Company> list = JsonSerializer.Deserialize<IEnumerable<Company>>(jsonString);
            return list;
        }
        public void SerializeByLINQ(IEnumerable<Company> list, string fileName)
        {
            XDocument xdoc = new XDocument();
            var companyarray = new XElement("CompanyArray");
            foreach (var item in list)
            {
                var company = new XElement("Company");
                var compName = new XElement("Name", item.Name);
                var depart = new XElement("Depart");
                var workfrom = new XElement("WorkFrom", item.Depart.WorkFrom);
                var workto = new XElement("WorkTo", item.Depart.WorkTo);
                depart.Add(workfrom);
                depart.Add(workto);
                company.Add(compName);
                company.Add(depart);
                companyarray.Add(company);
            }
            xdoc.Add(companyarray);
            xdoc.Save($"{fileName}.xml");
        }
        public void SerializeXML(IEnumerable<Company> list, string fileName)
        {
            XmlSerializer writer = new XmlSerializer(typeof(List<Company>));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + $"//{fileName}.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, list);

            file.Close();

        }
        public void SerializeJSON(IEnumerable<Company> list, string fileName)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize<IEnumerable<Company>>(list, options);
            File.WriteAllText($"{fileName}.json", jsonString);
        }
    }
}
