using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
	internal class AccidentException : Exception // coustom excption
	{
		public string Location { get; set; }

		public AccidentException(string location, string message) : base(message)
		{
			Location = location;
		}
	}
}
