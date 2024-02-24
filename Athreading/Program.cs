using System;
using System.Diagnostics;
using System.Threading;

namespace Athreading
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("========process and Threading=======");
			#region thread ID'S
			////process id in task manager
			//Console.WriteLine($"process ID : {Process.GetCurrentProcess().Id}");
			////thread id or thread number
			//Console.WriteLine($"thread ID : {Thread.CurrentThread.ManagedThreadId}");
			////processor id it warck the thread
			//Console.WriteLine($"processor ID : {Thread.GetCurrentProcessorId()}"); 
			#endregion

			Console.WriteLine("========squential senchronous Approach(singel thread)===========");

			var wallet = new Wallet("ashraf", 80);

			wallet.RunRandomTransaction();
			Console.WriteLine("--------------------------------------");
			Console.WriteLine($"{wallet}\n");

			wallet.RunRandomTransaction();
			Console.WriteLine("--------------------------------------");
			Console.WriteLine($"{wallet}\n");

		}
	}

	class Wallet
	{
		public string Name { get; set; }
		public int Bitcoine { get; set; }

		public Wallet(string name, int bitcoine)
		{
			Name = name;
			Bitcoine = bitcoine;
		}

		public void Debit(int amount)
		{
			Bitcoine -= amount;
		}

		public void Credit(int amount)
		{
			#region Decoment
			/// <summary>
			/// Increases the balance of the account by the specified amount.
			/// </summary>
			/// <param name="amount">The amount to be credited to the account.</param> 
			#endregion

			Bitcoine += amount;
		}

		public void RunRandomTransaction()
		{
			int[] amounts = new[] { 20, 30, 10, -20, 10, -10, 30, -10, 40, 20 };
			foreach (var amount in amounts)
			{
				var absValue = Math.Abs(amount);
				if (amount < 0)
				{
					Debit(amount);
				}
				else
				{
					Credit(amount);
				}
				Console.WriteLine($"Thread ID : {Thread.CurrentThread.ManagedThreadId}  " +
								  $"Processor ID : {Thread.GetCurrentProcessorId()} => {amount}");
			}

		}

		public override string ToString()
		{
			return $"[{Name} => {Bitcoine} BC]";
		}
	}
}
