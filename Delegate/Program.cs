using System;

namespace Delegate
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=============Delegate=============");
			var emps = new Employee[]
			{
				new Employee(1,"ashraf",5500m,Gender.Male),
				new Employee(2,"reem",4838m,Gender.Female),
				new Employee(3,"Ahmed",83837,Gender.Male),
				new Employee(4,"marwa",938389m,Gender.Female)
			};

			Report report = new Report(); // he is inctans from class used delegate
			report.ProcessEmployees(emps, "Employees with total salse > $5,000", TotalSalseGreater5000);// use delegate method
			report.ProcessEmployees(emps, "Employees with total salse < $5,000", e => e.TotalSalse < 5000);// use anonimas delegate

			RectangelHelper rectangelHelper = new RectangelHelper();
			//rectangelHelper.GetArea(10, 10); => this way without multiCast Delegate
			//rectangelHelper.GetPerimeter(10, 10);
			RectangelHelper.RectDelegat rect; //inictans from Delegate
			rect = rectangelHelper.GetArea;// use multiCast Delegate
			rect += rectangelHelper.GetPerimeter; // add another method to Delegat
												  //rect -= rectangelHelper.GetPerimeter;

			rect(10, 10); // multiCast Delegate colled tow method by same prametar
		}

		public static bool TotalSalseGreater5000(Employee emp) => emp.TotalSalse > 5000; // he is delegate method
																						 //public static bool TotalSalseLessThan5000(Employee emp) => emp.TotalSalse < 5000;
	}
}
