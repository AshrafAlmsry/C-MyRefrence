using System;

namespace ExceptionHandling
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("============Exception Handling=============");

			#region try && catch
			//try
			//{
			//	var result = BadMethod();
			//	Console.WriteLine(result);
			//}
			//catch (Exception e) when (e.Source == "ExceptionHandling") // exception fillters
			//{
			//	Console.WriteLine(e.Message);
			//	//throw;
			//}
			//finally
			//{
			//	Console.WriteLine("Done");
			//} 
			#endregion

			Delivery delivery = new Delivery()
			{ ID = 1, CustomerName = "ashraf", Address = "gerga", DeliveryStatus = DeliveryStatus.PROCESSED };
			var serviec = new DeliveryService();
			serviec.Start(delivery);
			Console.WriteLine(delivery);

		}

		public static int BadMethod()
		{
			int x = 2;
			int y = 0;
			return x / y;
		}
	}
}
