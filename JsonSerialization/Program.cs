using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace JsonSerialization
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("==============json serilazation===============");
			var emp = new Employee
			{
				Id = 292,
				Fname = "ashraf",
				Lname = "hesham",
				Benfits = { "benfits1", "benfits2", "benfits3" }
			};

			string jsonContent = SerializeToJson(emp);
			Console.WriteLine(jsonContent);


			var e2 = DeSerializeFromJson(jsonContent);
			Console.WriteLine(e2);

			Console.ReadKey();
		}
		//using newtonsoft.json
		public static string SerializeToJson(Employee employee)
		{
			return JsonConvert.SerializeObject(employee, Formatting.Indented);
		}

		public static Employee DeSerializeFromJson(string jsonContent)
		{
			Employee employee = null;
			employee = JsonConvert.DeserializeObject<Employee>(jsonContent);
			return employee;
		}
	}

	public class Employee
	{
		public int Id { get; set; }
		public string Fname { get; set; }
		public string Lname { get; set; }
		public List<string> Benfits { get; set; }


		public override string ToString()
		{
			return $"name : {Fname + Lname} , id : {Id}";
		}
	}
}
