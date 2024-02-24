using System;
using System.Collections.Generic;
using Humanizer;

namespace FaceBook
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var comments = new List<FBComment>()
			{
				new FBComment("ashraf", "if you want you can", new DateTime(2024, 01, 11, 10, 30, 00)),
				new FBComment("ahmed","happy pirth day my love ", new DateTime(2024,01,11,12,00,00)),
				new FBComment("ali", "Ilove programming by C#",new DateTime(2024,01,30,4,44,00))
			};

			comments.ForEach(c => Console.WriteLine(c));
		}
	}

	class FBComment
	{
		public string Owner { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedAt { get; set; }

		public FBComment(string owner, string comment, DateTime createdAt)
		{
			Owner = owner;
			Comment = comment;
			CreatedAt = createdAt;
		}

		public FBComment()
		{

		}

		public override string ToString()
		{
			return $"{Owner} Says : \n \" {Comment} \" \n \t\t {CreatedAt.Humanize()}";//using package humanizer
		}
	}
}
