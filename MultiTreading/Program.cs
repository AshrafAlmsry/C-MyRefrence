using System;
using System.Threading;

namespace AMultiTreading
{
	internal static class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("============Multi Threading=============");
			//this is default thread
			Thread.CurrentThread.Name = "Main Thread";
			Console.WriteLine(Thread.CurrentThread.Name);
			//Console.WriteLine($"background thread : {Thread.CurrentThread.IsBackground}");// false
			//---------------------------
			//create thread => my main thread
			var wallet = new Wallet("ashraf", 80);
			Thread t1 = new Thread(wallet.RunRandomTransaction);
			//thread tack aname
			t1.Name = "T1";//now the thread place in the memory but not start
						   //Console.WriteLine($"T1 background thread : {t1.IsBackground}"); //false 
			Console.WriteLine($"afer declaration {t1.Name} state is : {t1.ThreadState} ");
			t1.Start();//now thread started
			t1.Join();//t2 waite t1 is fineshed process after this t2 run
			Console.WriteLine($"afer start {t1.Name} state is : {t1.ThreadState} ");
			//---------------------------------------------------
			//another way to creat thread
			Thread t2 = new Thread(new ThreadStart(wallet.RunRandomTransaction));
			t2.Name = "T2";
			t2.Start();
			Console.WriteLine($"afer start {t2.Name} state is : {t2.ThreadState} ");
			//now tow thread run in prarell

		}
	}

	class Wallet
	{
		public Wallet(string name, int bitcoine)
		{
			Name = name;
			Bitcoine = bitcoine;
		}

		public string Name { get; set; }
		public int Bitcoine { get; set; }



		public void Debit(int amount)
		{
			Thread.Sleep(1000);
			Bitcoine -= amount;
			Console.WriteLine($"Thread ID : {Thread.CurrentThread.ManagedThreadId} - {Thread.CurrentThread.Name} " +
							  $"Processor ID : {Thread.GetCurrentProcessorId()} => -{amount}");
		}

		public void Credit(int amount)
		{
			#region Decoment
			/// <summary>
			/// Increases the balance of the account by the specified amount.
			/// </summary>
			/// <param name="amount">The amount to be credited to the account.</param> 
			#endregion
			Thread.Sleep(1000);
			Bitcoine += amount;
			Console.WriteLine($"Thread ID : {Thread.CurrentThread.ManagedThreadId} - {Thread.CurrentThread.Name}  " +
							  $"Processor ID : {Thread.GetCurrentProcessorId()} => +{amount}");
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

			}

		}

		public override string ToString()
		{
			return $"[{Name} => {Bitcoine} BC]";
		}
	}
}
