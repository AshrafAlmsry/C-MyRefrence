using System;

namespace XML
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("=========XML Decomintion==========");

			do
			{
				Console.Write("Enter Fname : ");
				string fname = Console.ReadLine();

				Console.Write("Enter Lname : ");
				string lname = Console.ReadLine();

				Console.Write("Enter HireDAte : ");
				DateTime? hireDate = null;
				if (DateTime.TryParse(Console.ReadLine(), out DateTime hdate))
					hireDate = hdate;
				string empId = Generator.GenerateId(fname, lname, hireDate);
				string randomPassword = Generator.GenerateRandomPassword(8);
				Console.WriteLine(
					$"{{\n fname : {fname} ,\n lname : {lname} ,\n HireDate : {hireDate} ,\n empID : {empId} ,\n Password : {randomPassword}}}");

			} while (1 == 1);

		}
	}

	/// <summary>
	/// the main generator class
	/// </summary>
	/// <remarks>
	/// this class can generate employee IDs && Password
	/// </remarks>
	class Generator
	{
		/// <value>
		/// The last identifier sequence.
		/// </value>
		public static int LastIdSequence { get; private set; } = 1;
		/// <summary>
		/// Generates Employee Id py processing <paramref name="fname"/> , <paramref name="lname"/> and <paramref name="hireDate"/>
		/// <list type="bullet">
		///<item>
		/// <term>II </term>
		/// <description>first letter form <paramref name="lname"/> and first letter from <paramref name="fname"/></description>
		/// </item>
		/// <item>
		/// <term>yy </term>
		/// <description>year of hireing</description>
		/// </item>
		///  <item>
		/// <term>MM</term>
		/// <description>Month of hireing</description>
		/// </item>
		///  <item>
		/// <term>dd </term>
		/// <description>day of hireing</description>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="fname">The fname.</param>
		/// <param name="lname">The lname.</param>
		/// <param name="hireDate">The hire date.</param>
		/// <example>
		///<code>
		///var id = Generator.GenerateId(fname , lname , hireDate);
		/// </code>
		/// </example>
		/// <returns>
		///Employee Id as string
		/// </returns>
		/// <exception cref="System.InvalidOperationException"></exception>
		public static string GenerateId(string fname, string lname, DateTime? hireDate)
		{
			//II YY MM DD 01
			if (fname is null)
				throw new InvalidOperationException($"{nameof(fname)} can not be null");
			if (lname is null)
				throw new InvalidOperationException($"{nameof(lname)} can not be null");
			if (hireDate is null) { hireDate = DateTime.Now; }
			else
			{
				if (hireDate.Value.Date < DateTime.Now.Date)
				{
					throw new InvalidOperationException($"{nameof(hireDate)} can not be in the past");
				}
			}

			string yy = hireDate.Value.ToString("yy");
			string mm = hireDate.Value.ToString("MM");
			string dd = hireDate.Value.ToString("dd");
			string code = $"{lname.ToUpper()[0]}{fname.ToUpper()[0]} {yy} {mm} {dd} {(LastIdSequence++).ToString().PadLeft(2, '0')}";
			return code;
		}

		public static string GenerateRandomPassword(int length)
		{
			const string ValidScope = "abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ0123456789";
			string result = "";
			Random rnd = new Random();

			while (0 < length--)
			{
				result += ValidScope[rnd.Next(ValidScope.Length)];
			}

			return result;
		}

	}
}
