using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
	internal class DeliveryService
	{
		public void Start(Delivery delivery)
		{
			try
			{
				Process(delivery);
				Shipp(delivery);
				Transit(delivery);
				Deliver(delivery);
			}
			catch (AccidentException e)
			{
				Console.WriteLine($"ther was an Accident in {e.Location} us delivry {e.Message}");
				delivery.DeliveryStatus = DeliveryStatus.UNKNOWN;
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				delivery.DeliveryStatus = DeliveryStatus.UNKNOWN;
			}
			finally
			{
				Console.WriteLine("Done");
			}
		}

		private void Process(Delivery delivery)
		{
			FakeIt("Processing");
			if (new Random().Next(1, 5) == 1)
			{
				throw new InvalidOperationException("processing is feald");
			}
			delivery.DeliveryStatus = DeliveryStatus.PROCESSED;
		}

		private void Shipp(Delivery delivery)
		{
			FakeIt("Shipping");
			if (new Random().Next(1, 5) == 1)
			{
				throw new InvalidOperationException("shipping is feald");
			}
			delivery.DeliveryStatus = DeliveryStatus.SHIPPED;
		}

		private void Transit(Delivery delivery)
		{
			FakeIt("On It's Way");
			if (new Random().Next(1, 5) == 1)
			{

				throw new AccidentException("345 Streat", "ACCSIDENT!!!!");
			}
			delivery.DeliveryStatus = DeliveryStatus.INTRANSIT;
		}

		private void Deliver(Delivery delivery)
		{
			FakeIt("Delivered is Done");
			if (new Random().Next(1, 5) == 1)
			{
				throw new InvaledAddressException($"{delivery.Address} is invaled !!!");
			}
			delivery.DeliveryStatus = DeliveryStatus.DELIVERED;
		}

		private void FakeIt(string title)
		{
			Console.Write(title);
			System.Threading.Thread.Sleep(300);
			Console.Write(".");
			System.Threading.Thread.Sleep(300);
			Console.Write(".");
			System.Threading.Thread.Sleep(300);
			Console.Write(".");
			System.Threading.Thread.Sleep(300);
			Console.Write(".");
			System.Threading.Thread.Sleep(300);
			Console.Write(".");
			System.Threading.Thread.Sleep(300);
			Console.WriteLine(".");
		}
	}
}
