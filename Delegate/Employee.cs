using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
	public enum Gender
	{
		Male, Female
	}
	internal class Employee
	{
		public Employee(int id, string name, decimal totalSalse, Gender gender)
		{
			ID = id;
			Name = name;
			TotalSalse = totalSalse;
			Gender = gender;
		}

		public int ID { get; set; }
		public string Name { get; set; }
		public decimal TotalSalse { get; set; }
		public Gender Gender { get; set; }

		public Employee()
		{

		}


	}
}
