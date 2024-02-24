using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace ALinkedList
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("========Linked List===========");

			#region Instances
			var lesson1 = new YouTubeVedio("YTV01", "class", new TimeSpan(00, 30, 00));
			var lesson2 = new YouTubeVedio("YTV02", "array", new TimeSpan(00, 45, 00));
			var lesson3 = new YouTubeVedio("YTV03", "string", new TimeSpan(00, 20, 00));
			var lesson4 = new YouTubeVedio("YTV04", "generice", new TimeSpan(00, 50, 00));
			var lesson5 = new YouTubeVedio("YTV05", "event", new TimeSpan(00, 10, 00));
			var lesson6 = new YouTubeVedio("YTV06", "delegate", new TimeSpan(00, 40, 00));
			var lesson7 = new YouTubeVedio("YTV07", "linkedList", new TimeSpan(00, 33, 00));
			#endregion

			YouTubeVedio[] YTVedios = new[] { lesson1, lesson2, lesson3, lesson4, lesson5, lesson6, lesson7 };
			//first way to assign nodes in => LinkedList
			//LinkedList<YouTubeVedio> playList = new LinkedList<YouTubeVedio>(YTVedios);
			//another way to assign nodes in => LinkedList
			LinkedList<YouTubeVedio> playList = new LinkedList<YouTubeVedio>();
			playList.AddFirst(lesson1);
			playList.AddAfter(playList.First, lesson2);
			var node3 = new LinkedListNode<YouTubeVedio>(lesson3);
			playList.AddAfter(playList.First.Next, node3);
			playList.AddBefore(playList.Last, lesson4);
			playList.AddLast(lesson5);

			Print("C# form zero to hero", playList);
		}

		static void Print(string title, LinkedList<YouTubeVedio> playList)
		{
			//alt+218
			Console.WriteLine($"┌{title}");
			foreach (var vedio in playList)
			{
				Console.WriteLine(vedio);
			}
			//alt+192
			Console.WriteLine("└");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine($"Total => {playList.Count} Items(s)");
		}
	}

	class YouTubeVedio
	{
		public YouTubeVedio()
		{

		}
		public YouTubeVedio(string id, string title, TimeSpan duration)
		{
			Id = id;
			Title = title;
			Duration = duration;
		}

		public string Id { get; set; }
		public string Title { get; set; }
		public TimeSpan Duration { get; set; }


		public override string ToString()
		{
			//C# variables (00:30:00)
			//        https://www.youtube.com/watch?v=tes3321
			//alt+195 ├  , alt+196 ─ , alt+179 │
			return $"├─ {Title}  ({Duration})\n│\t  https://www.youtube.com/watch?v={Id}";
		}
	}
}
