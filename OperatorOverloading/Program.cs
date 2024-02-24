using System;

namespace OperatorOverloading
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("============Operator OverLoading===========");
			var m1 = new Money(10);
			var m2 = new Money(20);
			Console.WriteLine($"m1 : {m1.Amount}  ,  m2 : {m2.Amount}");
			//Money m3 = new Money(m2.Amount + m1.Amount);
			Money m3 = m2 + m1;
			Console.WriteLine($"m3 amount : {m3.Amount}");

			Console.WriteLine((++m2).Amount);
		}
	}

	class Money
	{
		private decimal _amount;

		public decimal Amount => _amount;

		public Money(decimal value)
		{
			_amount = Math.Round(value, 2);
		}

		public static Money operator +(Money m1, Money m2) => new Money(m1.Amount + m2.Amount);
		public static Money operator -(Money m1, Money m2) => new Money(m1.Amount - m2.Amount);

		public static bool operator <(Money m1, Money m2) => m1.Amount < m2.Amount;
		public static bool operator >(Money m1, Money m2) => m1.Amount > m2.Amount;
		public static bool operator <=(Money m1, Money m2) => m1.Amount <= m2.Amount;
		public static bool operator >=(Money m1, Money m2) => m1.Amount >= m2.Amount;

		public static bool operator ==(Money m1, Money m2) => m2.Amount == m1.Amount;
		public static bool operator !=(Money m1, Money m2) => m1.Amount != m2.Amount;

		public static Money operator ++(Money money)
		{
			var value = money.Amount;
			return new Money(++value);
		}

		public static Money operator --(Money money)
		{
			var value = money.Amount;
			return new Money(--value);
		}
	}
}
