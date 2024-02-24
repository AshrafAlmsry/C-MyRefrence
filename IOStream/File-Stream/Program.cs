using System;
using System.IO;

namespace File_Stream
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("========File Stream =======");
			Example02();
		}

		static void Example01()
		{
			string path = @"H:\BackEnd\C#-ref\IOStream\File-Stream\f1.txt";
			using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
			{
				Console.WriteLine($"length : {fs.Length} Byts(s)");
				Console.WriteLine($"CanRead : {fs.CanRead} ");
				Console.WriteLine($"CanWrite : {fs.CanWrite} ");
				Console.WriteLine($"CanSeek : {fs.CanSeek} ");
				Console.WriteLine($"CanTimeout : {fs.CanTimeout} ");
				Console.WriteLine($"Position : {fs.Position} ");//position of curser
				fs.WriteByte(65);//A
				fs.WriteByte(66);//B
				Console.WriteLine($"Position : {fs.Position} ");//position of curser
				fs.WriteByte(13);//enter
				for (byte i = 0; i < 123; i++)
				{
					fs.WriteByte(i);
				}


			}
		}
		static void Example02()
		{
			string path = @"H:\BackEnd\C#-ref\IOStream\File-Stream\f1.txt";
			using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
			{


			}
		}
	}
}
