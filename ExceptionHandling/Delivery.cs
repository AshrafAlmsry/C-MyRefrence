using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
	public enum DeliveryStatus
	{
		UNKNOWN, PROCESSED, SHIPPED, INTRANSIT, DELIVERED
	}
	internal class Delivery
	{
		public int ID { get; set; }
		public string CustomerName { get; set; }
		public string Address { get; set; }
		public DeliveryStatus DeliveryStatus { get; set; }

		#region Overrides of Object

		public override string ToString()
		{
			return $" ID : {ID} | CustomerName : {CustomerName} | Sddress : {Address} | DelivryStatus : {DeliveryStatus}";
		}

		#endregion
	}
}
