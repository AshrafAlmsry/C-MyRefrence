using System;
using System.Collections.Generic;

namespace AStack
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("============Stack=============");
			// push() => add to stack
			//pop() => access and remove last item in the stack
			//peek() => just access the last item dont remove it
			Stack<Command> undo = new Stack<Command>();
			Stack<Command> redo = new Stack<Command>();
			string line;
			while (true)
			{
				Console.Write("URL : 'exite' to quit : ");
				line = Console.ReadLine().ToLower();
				if (line == "exite")
				{
					break;
				}
				else if (line == "back")
				{
					if (undo.Count > 0)
					{
						var item = undo.Pop();
						redo.Push(item);
					}
					else
					{
						continue;
					}
				}
				else if (line == "forward")
				{
					if (redo.Count > 0)
					{
						var item = redo.Pop();
						undo.Push(item);
					}
					else
					{
						continue;
					}
				}
				else
				{
					//add in undo 
					undo.Push(new Command(line));
				}
				Console.Clear();
				Print("back", undo);
				Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~");
				Print("forward", redo);
			}

		}

		static void Print(string name, Stack<Command> commands)
		{
			Console.WriteLine($"{name} => Hestory");
			Console.BackgroundColor = name.ToLower() == "back" ? ConsoleColor.DarkGreen : ConsoleColor.DarkBlue;
			foreach (var command in commands)
			{
				Console.WriteLine($"\t{command}");
			}

			Console.BackgroundColor = ConsoleColor.Black;
		}
	}

	class Command
	{
		public Command(string url)
		{
			_createsAt = DateTime.Now;
			_url = url;
		}

		private readonly DateTime _createsAt;
		private readonly string _url;

		#region Overrides of Object

		public override string ToString()
		{
			return $"[{this._createsAt.ToString("yyyy-MM-dd  hh:mm")}] : {this._url}";
		}

		#endregion
	}
}
