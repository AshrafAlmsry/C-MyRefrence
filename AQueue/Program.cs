using System;
using System.Collections.Generic;

namespace AQueue
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("==========Queue===========");
			Queue<PrintingJop> printingJobs = new Queue<PrintingJop>();

			printingJobs.Enqueue(new PrintingJop("user-stories.pdf", 21));
			printingJobs.Enqueue(new PrintingJop("report.xlsx", 22));
			printingJobs.Enqueue(new PrintingJop("payroll.report", 4));
			printingJobs.Enqueue(new PrintingJop("budget.xlsx", 5));
			printingJobs.Enqueue(new PrintingJop("algorithm.focx", 20));
			printingJobs.Enqueue(new PrintingJop("documentation.docx", 13));

			Random rnd = new Random();
			while (printingJobs.Count > 0)
			{
				Console.ForegroundColor = ConsoleColor.Green;
				var jop = printingJobs.Dequeue();
				Console.WriteLine($"printing...... [{jop}]");
				System.Threading.Thread.Sleep(rnd.Next(1, 5) * 1000);
				Console.ForegroundColor = ConsoleColor.White;
			}

			//printingJobs.TryPeek(out PrintingJop result);
			//printingJobs.TryDequeue(out PrintingJop result);
		}
	}


	class PrintingJop
	{
		public PrintingJop(string file, int copies)
		{
			_file = file;
			_copies = copies;
		}

		private readonly string _file;
		private readonly int _copies;

		public override string ToString()
		{
			return $"{_file} X #{_copies} copies";
		}
	}
}
