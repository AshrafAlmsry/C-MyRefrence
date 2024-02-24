using System;
using System.Diagnostics;

namespace Attributes
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("===============Attributes==============");
			Update[] updates = new Update[]
			{
				new Update(1, "securty updae"),
				new Update(2, "UI inhancment update"),
				new Update(3, "fixes pug update"),
				new Update(4, "code update")
			};
			UpdateProcessor.Download(updates);
			UpdateProcessor.Install(updates);

		}
	}


}
