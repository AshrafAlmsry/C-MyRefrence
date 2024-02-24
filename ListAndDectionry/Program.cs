using System;
using System.Collections.Generic;
using System.Linq;

namespace ListAndDectionry
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("==========List && Dectionry===========");
			var egypt = new Country("egypt", "EGY");
			var sohag = new Country("Sohag", "SH");
			var cairo = new Country("Cairo", "CA");
			var assiut = new Country("Assiut", "ASU");
			List<Country> countries = new List<Country>() { egypt, sohag };
			countries.Add(new Country("Paris", "par")); // add in last index =>O(1)
			countries.Insert(1, cairo);

			Print(countries);
			Console.WriteLine("if you want you can else you can't");
		}

		public static void Print<T>(List<T> list)
		{
			foreach (var item in list)
			{
				Console.WriteLine(item);
			}
		}
	}

	class Country
	{
		public string Name { get; set; }
		public string IsoCode { get; set; }

		public Country()
		{

		}

		public Country(string name, string isoCode)
		{
			Name = name;
			IsoCode = isoCode;
		}


		public override string ToString()
		{
			return $"{Name} => ({IsoCode})";
		}

	}
}
