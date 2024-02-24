using System;

namespace ExctentionMethod
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("============Extension Mentod===============");
			#region Date Time
			//DateTime dt =DateTime.Now;
			//Console.WriteLine($"DateTime.Now: (dt)"); // yyyy-HM-dd hh:mm:ss am/pm
			//TimeSpan ts = new TimeSpan(2, 15, 0);
			//dt = dt.Add(ts);
			//Console.WriteLine($"DateTime.Now + 2:15 : {dt}"); // yyyy - MM - dd hh: mm: ss am/ pm

			//dt = new DateTime(2021, 3, 1, 11, 30, 00);
			//Console.WriteLine("DateTime: (dt)"); // yyyy-MP-dd hh:maiss am/pm
			//DateTimeOffset dts = DateTimeOffset.Now;
			//Console.WriteLine($"Date tiem offser.now : {dts}");
			//dts = DateTimeOffset.UtcNow;
			//Console.WriteLine($"DateTineOffset.UtcNow: (dts)"); 
			#endregion

			//DateTime dt = DateTime.Now;
			//dt = dt.AddDays(1);
			//Console.WriteLine($"Is week end : {dt.IsWeekEnd()}");
			//Console.WriteLine($"Is week day : {dt.IsWeekDay()}");

			Pizza p = new Pizza();
			p.AddCheexe(true).AddDough("then").AddSouce().AddTopping("black oil", 80.80);
			Console.WriteLine(p);

		}
	}

	static class PizaaEx
	{
		public static Pizza AddDough(this Pizza value, string type)
		{
			value.Content += $"\n{type} Dough x $4,00";
			value.TotalPrice += 4;
			return value;
		}

		public static Pizza AddSouce(this Pizza valuePizza)
		{
			valuePizza.Content += $"\ntomato Souce x $4,00";
			valuePizza.TotalPrice += 4;
			return valuePizza;
		}

		public static Pizza AddCheexe(this Pizza valuePizza, bool extra)
		{
			valuePizza.Content += $"\n{(extra ? "extra" : "regular")} cheeze x ${(extra ? "8,00" : "6,00")}";
			valuePizza.TotalPrice += extra ? 8 : 6;
			return valuePizza;
		}

		public static Pizza AddTopping(this Pizza valuePizza, string type, double price)
		{
			valuePizza.Content += $"\n{type} x ${price.ToString("##.###")}";
			valuePizza.TotalPrice += price;
			return valuePizza;
		}
	}
	class Pizza
	{
		public string Content { get; set; }
		public double TotalPrice { get; set; }

		public override string ToString()
		{
			return $"content : {Content}\n----------------------\n total Price : {TotalPrice.ToString("##.###")}";
		}

	}
}
