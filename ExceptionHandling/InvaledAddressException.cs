using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
	internal class InvaledAddressException : Exception

	{
		public InvaledAddressException(string message) : base(message)
		{

		}
	}
}
