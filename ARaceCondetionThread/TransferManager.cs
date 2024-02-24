using System;
using System.Threading;

namespace ARaceCondetionThread
{
	class TransferManager
	{
		private Wallet _from;
		private Wallet _to;
		private int _amountTransfer;

		public TransferManager(Wallet from, Wallet to, int amountTransfer)
		{
			_from = from;
			_to = to;
			_amountTransfer = amountTransfer;
		}

		public void Transfer()
		{
			//this solve dead lock => second way
			var lock1 = _from.Id < _to.Id ? _from : _to;
			var lock2 = _from.Id < _to.Id ? _to : _from;
			Console.WriteLine($"{Thread.CurrentThread.Name} trying to lock .... {_from}");
			lock (lock1)
			{
				Console.WriteLine($"{Thread.CurrentThread.Name} lock acquired .... {_from}");
				Thread.Sleep(1000);
				Console.WriteLine($"{Thread.CurrentThread.Name} trying lock .... {_to}");
				lock (lock2)
				{
					//Console.WriteLine($"{Thread.CurrentThread.Name} lock acqured .... {_to}");
					_from.Debit(_amountTransfer);
					_to.Credit(_amountTransfer);

				}

				#region this solve dead lock => first way
				//this solve dead lock => first way
				//if (Monitor.TryEnter(_to, 1000))
				//{
				//	Console.WriteLine($"{Thread.CurrentThread.Name} lock acqured .... {_to}");
				//	try
				//	{
				//		_from.Debit(_amountTransfer);
				//		_to.Credit(_amountTransfer);
				//	}
				//	finally
				//	{
				//		Monitor.Exit(_to);
				//	}
				//}
				//else
				//{
				//	Console.WriteLine($"{Thread.CurrentThread.Name} unable to acqured lock .... {_to}");
				//} 
				#endregion
			}
		}
	}
}