using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event
{

	internal class Stock // publisher
	{
		private string _name;
		private double _price;

		public string Name { get { return _name; } }
		public double Price { get => _price; set => this._price = value; }

		public Stock(string stockName)
		{
			this._name = stockName;
		}

		public delegate void StockPriceChangeHandelr(Stock stock, double oldPrice);//initalize delegat

		public event StockPriceChangeHandelr OnPriceChangeHandelr;//initialze event by deleget type

		public void ChangeStockPriceBy(double percent)
		{
			double oldPrice = this.Price;
			_price += Math.Round(_price * percent, 2);
			if (OnPriceChangeHandelr != null) // make shur thar id subscriber
			{
				OnPriceChangeHandelr(this, oldPrice); // firing the event
			}
		}
	}
}
