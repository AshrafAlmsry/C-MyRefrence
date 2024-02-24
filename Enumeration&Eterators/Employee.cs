using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeration_Eterators
{
	internal class Employee
	{
		public Employee()
		{

		}
		public Employee(int id, string name, double salary, string department)
		{
			ID = id;
			Name = name;
			Salary = salary;
			Department = department;
		}

		public int ID { get; set; }
		public string Name { get; set; }
		public double Salary { get; set; }
		public string Department { get; set; }

		#region to compait refernce type py content => proparty

		public override bool Equals(object obj) // to compait refernce type py content => proparty
		{
			if (obj == null || !(obj is Employee))
			{
				return false;
			}
			Employee emp = obj as Employee;

			return this.ID == emp.ID
				&& this.Name == emp.Name
				&& this.Salary == emp.Salary
				&& this.Department == emp.Department;
		}



		public override int GetHashCode()
		{
			int hash = 13;
			hash = (hash * 7) + ID.GetHashCode();
			hash = (hash * 7) + Name.GetHashCode();
			hash = (hash * 7) + Salary.GetHashCode();
			hash = (hash * 7) + Department.GetHashCode();
			return hash;
		}



		#endregion

		public static bool operator ==(Employee left, Employee right) => left.Equals(right);
		public static bool operator !=(Employee left, Employee right) => !left.Equals(right);


	}
}
