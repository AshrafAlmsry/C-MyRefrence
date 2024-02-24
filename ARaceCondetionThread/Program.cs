using System;
using System.Threading;
using Microsoft.Win32.SafeHandles;

namespace ARaceCondetionThread
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=============RaceCondetion Thread(lock(obj)) && dead Lock()==============");
			#region RaceCondetion
			//Wallet wallet = new Wallet("ashraf", 50);
			//Thread t1 = new Thread((() => wallet.Debit(40)));
			//Thread t2 = new Thread((() => wallet.Debit(30)));
			//t1.Start();
			//t2.Start();
			//t1.Join();//inside tow thread in the same time
			//t2.Join();

			//Console.WriteLine(wallet); 
			#endregion

			var wallet1 = new Wallet(1, "Issam", 100);
			var wallet2 = new Wallet(2, "Reem", 50);
			Console.WriteLine("\nBefore transaction");
			Console.WriteLine("--------------------------------------");
			Console.WriteLine($"{wallet1} , {wallet2}");
			Console.WriteLine("\n After transaction");
			Console.WriteLine("--------------------------------------");
			TransferManager transferManager1 = new TransferManager(wallet1, wallet2, 50);
			TransferManager transferManager2 = new TransferManager(wallet2, wallet1, 30);
			//run in tow thread
			var t1 = new Thread(transferManager1.Transfer);
			t1.Name = "T1";
			var t2 = new Thread(transferManager2.Transfer);
			t2.Name = "T2";

			t1.Start();
			t2.Start();
			t1.Join();
			t2.Join();
			Console.WriteLine($"{wallet1} , {wallet2}");

		}
	}
}
