using System;

namespace Attributes
{
	class UpdateProcessor
	{


		//it this method will not be supported in the next release consider using => [Obsolete(message,exception)]
		[Obsolete("it this method will not be supported in the next release consider using DownloadAndInstall()", false)]
		public static void Download(Update[] updates)
		{
			for (int i = 0; i < updates.Length; i++)
			{
				Console.WriteLine($"Downloading : {updates[i]}");
				System.Threading.Thread.Sleep(750);
			}
		}
		public static void Install(Update[] updates)
		{
			for (int i = 0; i < updates.Length; i++)
			{
				Console.WriteLine($"Installing : {updates[i]}");
				System.Threading.Thread.Sleep(750);
			}
		}
		public static void DownloadAndInstall(Update[] updates)
		{
			for (int i = 0; i < updates.Length; i++)
			{
				Console.WriteLine($"Downloading : {updates[i]}");
				System.Threading.Thread.Sleep(750);
				Console.WriteLine($"Installing : {updates[i]}");
			}
		}
	}
}