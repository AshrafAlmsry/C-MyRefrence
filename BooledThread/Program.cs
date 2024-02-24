using System;
using System.Threading;
using System.Threading.Tasks;

namespace BooledThread
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("==========Bool Thread============");
			//1
			Console.WriteLine("~~~~~~~~~using thread bool~~~~~~~~~~~~~");
			ThreadPool.QueueUserWorkItem(new WaitCallback(Print));
			//2
			Console.WriteLine("~~~~~~~~~using Task~~~~~~~~~~~~~");
			Task.Run(Print);
			Console.ReadKey();

		}

		private static void Print(object state)
		{
			//Thread.CurrentThread.Name = "Main Thread";
			Console.WriteLine(
				$"Thread ID : {Thread.CurrentThread.ManagedThreadId} , Tread Name : {Thread.CurrentThread.Name}");
			Console.WriteLine($"Is Booled Thread : {Thread.CurrentThread.IsThreadPoolThread}");
			Console.WriteLine($"Background : {Thread.CurrentThread.IsBackground}");
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine($"Cycle => {i + 1}");
			}
		}
		private static void Print()
		{
			//Thread.CurrentThread.Name = "Main Thread";
			Console.WriteLine(
				$"Thread ID : {Thread.CurrentThread.ManagedThreadId} , Tread Name : {Thread.CurrentThread.Name}");
			Console.WriteLine($"Is Booled Thread : {Thread.CurrentThread.IsThreadPoolThread}");
			Console.WriteLine($"Background : {Thread.CurrentThread.IsBackground}");
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine($"Cycle => {i + 1}");
			}
		}
	}
}
