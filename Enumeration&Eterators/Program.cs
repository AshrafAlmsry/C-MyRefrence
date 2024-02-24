using System;
using System.Collections.Generic;

namespace Enumeration_Eterators
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("===========Eteration&&Iterators===============");
			#region Compaier reference type 
			//Employee eAshraf = new Employee(1, "ashraf", 500000, "FullStack");
			//Employee eMarwa = new Employee(1, "ashraf", 500000, "FullStack");
			//Employee e3 = eAshraf;
			//compair refrence type
			//Console.WriteLine(eAshraf == eMarwa);//False => compair reference to reference pefor  write operator overloading ==  !==
			//Console.WriteLine(e3 == eAshraf);//True => compair refrence to reference 
			// after override equals && write operator overloading ==  !==
			//Console.WriteLine(eAshraf == eMarwa);//true
			//Console.WriteLine(eAshraf.Equals(eMarwa));//ture
			//string s1 = "hello";
			//string s2 = "hello";
			//Console.WriteLine(s1 == s2);//in the string compair to content s1 to content s2 
			#endregion

			#region create custom class Ienumraple
			//now after create custom class Ienumraple can mak inestance and loop him py foreach (:
			//var ints = new FiveIntegers(1, 2, 3, 4, 5);
			//foreach (var i in ints)
			//{
			//	Console.WriteLine(i);
			//} 
			#endregion

			#region to i can sort list by compar proparty
			// implment IcomparTo => to i can sort list by compar proparty
			var temps = new List<Temprtuer>();
			Random rnd = new Random();
			for (var i = 0; i <= 100; i++)
			{
				temps.Add(new Temprtuer(rnd.Next(-30, 50)));
			}
			temps.Sort();
			foreach (var temp in temps)
			{
				Console.WriteLine(temp.Value);
			}
			#endregion
		}
	}
}
