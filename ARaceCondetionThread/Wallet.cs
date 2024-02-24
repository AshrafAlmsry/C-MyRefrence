using System.Threading;

namespace ARaceCondetionThread
{
	class Wallet
	{
		//reference object to lock
		private readonly object BitcoinLock = new object();
		public int Id { get; set; }
		public string Name { get; set; }
		public int Bitcoine { get; set; }

		public Wallet(int id, string name, int bitcoine)
		{
			Id = id;
			Name = name;
			Bitcoine = bitcoine;
		}

		public void Debit(int amount)
		{
			//t2
			lock (BitcoinLock)//waite inside thread to finesh
			{
				//race condetion
				if (Bitcoine >= amount)
				{
					//t1
					Thread.Sleep(1000);
					Bitcoine -= amount;
				}
			}
		}

		public void Credit(int amount)
		{
			Thread.Sleep(1000);
			Bitcoine += amount;
		}


		public override string ToString()
		{
			return $"[{Name} => {Bitcoine} BC]";
		}
	}
}