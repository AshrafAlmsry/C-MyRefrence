using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace XmlSrilization
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("==========xml Serilization===========");

			var e1 = new Employee()
			{
				Id = 1,
				Fname = "ashraf",
				Lname = "hesham",
				Benfits = { "ponase", "helthy incom" }
			};

			#region Serialize and save in file 
			var xmlContent = srializeToXmlString(e1);

			Console.WriteLine(xmlContent);

			File.WriteAllText("mxlDocument.xml", xmlContent);
			#endregion

			#region DeSerialize

			Employee e2 = DesrializeFromXmlContent(xmlContent);
			Console.WriteLine(e2);
			#endregion

			Console.ReadLine();
		}

		private static Employee DesrializeFromXmlContent(string xmlContent)
		{
			Employee employee = null;

			var xmlSerializer = new XmlSerializer(typeof(Employee));
			using (TextReader textReader = new StringReader(xmlContent))
			{
				employee = xmlSerializer.Deserialize(textReader) as Employee;
			}

			return employee;
		}

		private static string srializeToXmlString(Employee e1)
		{
			var result = "";
			var xmlSrializer = new XmlSerializer(e1.GetType());
			using (var sw = new StringWriter())
			{
				using (var writer = XmlWriter.Create(sw, new XmlWriterSettings { Indent = true }))
				{
					xmlSrializer.Serialize(writer, e1);
					result = sw.ToString();
				}
			}

			return result;
		}
	}
}

public class Employee
{
	public int Id { get; set; }
	public string Fname { get; set; }
	public string Lname { get; set; }
	public List<string> Benfits { get; set; } = new List<string>();

	public override string ToString()
	{
		return $"name : {Fname + Lname} , id : {Id}";
	}
}