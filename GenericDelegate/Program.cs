using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericDelegate
{
	//public delegate Tresult Filter<in Tsurce, out Tresult>(T value); //coustom generic delegate
	//*piltin generic delegate
	//(Func<16 input parameter, Tresult> | Action<16 input paramter> void return | predicat<16 input paramter> return bool)

	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("==========Generic Delegate ===========");
			List<int> numsList = new List<int>() { 1, 2, 3, 4, 5, 6, 4, 5, 6, 7, 8, 9, 10, 12, 11, 13 };

			PrintNumbers(numsList, n => n > 6);
		}

		public static void PrintNumbers<Tsourc>(IEnumerable<Tsourc> secunce, Predicate<Tsourc> filter)
		{
			foreach (var n in secunce)
			{
				if (filter(n))
				{
					Console.WriteLine(n);
				}
			}
		}
	}
}
