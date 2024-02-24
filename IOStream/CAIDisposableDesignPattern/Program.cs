using System;
using System.Net.Http;

namespace CAIDisposableDesignPattern
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("===========Disposid============");

			#region (1) not recommnded
			//1) not recommnded
			//CurrencyService currencyService = new CurrencyService();
			//var result = currencyService.GetCurrencies();
			//currencyService.Dispose();
			//Console.WriteLine(result); 
			#endregion

			#region (2) recommnded
			//2) recommnded
			//CurrencyService currencyService = null;
			//try
			//{
			//	currencyService = new CurrencyService();
			//	var result = currencyService.GetCurrencies();
			//	Console.WriteLine(result);
			//}
			//catch (Exception e)
			//{
			//	Console.WriteLine($"erorr = {e.Message}");

			//}
			//finally
			//{
			//	currencyService?.Dispose();
			//} 
			#endregion

			#region (3) more recommnded 
			//3) more recommnded he is in IIL => ==2) try catch
			//using is auto call the dispose method
			//using (CurrencyService currencyService = new CurrencyService())
			//{
			//	var result = currencyService.GetCurrencies();
			//	Console.WriteLine(result);
			//} 
			#endregion

			#region (4) using with out block in c# 8.9
			//4) using with out block in c# 8.9
			//using CurrencyService currencyService = new CurrencyService();
			//	var result = currencyService.GetCurrencies();
			//	Console.WriteLine(result);

			#endregion


			using (CurrencyService currencyService = new CurrencyService())//3) auto call dispose method
			{
				var result = currencyService.GetCurrencies();
				Console.WriteLine(result);
			}
		}
	}
	//inhert from IDisposable to clean the unmanaged code
	class CurrencyService : IDisposable //step 1
	{
		private readonly HttpClient _httpClient;
		private bool _disposed = false;
		public CurrencyService()
		{
			_httpClient = new HttpClient();
		}

		//finleize called by GC=> garbedg collecter (this way if not remember using any way to call dispose)
		~CurrencyService()
		{
			Dispose(false);
		}
		//disposing : true (dispose(clean) => managed + unManaged)
		//disposing : false(dispose(clean) => unManaged + larg fields)
		protected virtual void Dispose(bool disposing)//step 3
		{
			if (_disposed) return;
			//dispose logic
			if (disposing)
			{
				//dispose managed resource
				_httpClient.Dispose();
			}
			_disposed = true;
		}

		public void Dispose() //step2
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public string GetCurrencies()
		{
			//request to get data from API
			string url = "https://api.coinbase.com/v2/currencies";
			return _httpClient.GetStringAsync(url).Result;
		}
	}
}
