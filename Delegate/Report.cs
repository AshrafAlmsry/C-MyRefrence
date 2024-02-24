using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
	internal class Report
	{
		// delegate is => refrnce type , geve me power send method from same type => as parametr 
		public delegate bool IllegibleSalse(Employee employee); // initial coustom delegate

		public void ProcessEmployees(Employee[] employees, string title, IllegibleSalse isIllegibleSalse)
		{
			Console.WriteLine(title);
			Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
			foreach (var employee in employees)
			{
				if (isIllegibleSalse(employee))
				{
					Console.WriteLine($"{employee.ID} | {employee.Name} | {employee.Gender} | {employee.TotalSalse}");
				}
			}
			Console.WriteLine("\n \n");
		}
	}
}
