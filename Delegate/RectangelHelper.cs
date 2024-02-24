using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Console = System.Console;

namespace Delegate
{
	internal class RectangelHelper
	{
		public delegate void RectDelegat(double width, double height);
		public void GetArea(double width, double height)
		{
			var result = width * height;
			Console.WriteLine($"Area : {width} x {height} = {result}");
		}

		public void GetPerimeter(double width, double height)
		{
			var result = 2 * (width + height);
			Console.WriteLine($"Perimeter : 2 x ({width} + {height}) = {result}");
		}
	}
}
