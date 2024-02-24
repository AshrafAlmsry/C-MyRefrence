using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExctentionMethod
{
	internal static class DateTimeEx
	{
		public static bool IsWeekEnd(this DateTime valueDateTime)
		{
			return valueDateTime.DayOfWeek == DayOfWeek.Friday || valueDateTime.DayOfWeek == DayOfWeek.Saturday;
		}

		public static bool IsWeekDay(this DateTime valueDateTime)
		{
			return !IsWeekEnd(valueDateTime);
		}
	}
}
