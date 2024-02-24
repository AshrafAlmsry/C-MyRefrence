using System;
using System.Diagnostics.SymbolStore;

namespace Event
{
	internal class Program // subscriber
	{
		static void Main(string[] args)
		{
			Console.WriteLine("============Event===========");

			Stock stock = new Stock("Amazon");
			stock.Price = 100;

			stock.OnPriceChangeHandelr += Stock_OnPriceChangeHandelr;// subscrib to event
																	 //stock.OnPriceChangeHandelr -= Stock_OnPriceChangeHandelr; // unsubscribe to event
			stock.ChangeStockPriceBy(0.05);
			stock.ChangeStockPriceBy(-0.03);
			stock.ChangeStockPriceBy(0.00);
		}
		//this method tack the same delegate segneture
		private static void Stock_OnPriceChangeHandelr(Stock stock, double oldprice) // method colled in event hapend
		{
			string result = "";
			if (stock.Price > oldprice)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				result = "UP";
			}
			else if (oldprice > stock.Price)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				result = "DOWN";
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Gray;

			}
			Console.WriteLine($"{stock.Name} : {stock.Price} - {result}");
		}
	}
}
