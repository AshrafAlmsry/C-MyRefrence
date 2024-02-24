using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Dynamic;
using System.Threading.Channels;
using static AHashSet.Customer;
namespace AHashSet
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//hashSet dont acsept repeat the element => you must override gethascode and equals;
			Console.WriteLine("============HashSet=============");
			CreatCustomer("ashraf", "01061106293", out var cust1);
			CreatCustomer("ahmed", "1245877771", out var cust2);
			CreatCustomer("ali", "1245877772", out var cust3);
			CreatCustomer("ysser", "1245877773", out var cust4);
			CreatCustomer("shwkt", "1245877774", out var cust5);
			CreatCustomer("ashraf", "1245877774", out var cust6);// repeate the same telephne 

			var customers = new List<Customer>() { cust1, cust2, cust3, cust4, cust5 };
			var customers2 = new List<Customer>()
			{
				new Customer("reem", "12450158"), new Customer("hager","12455214521"),
				new Customer("marwa", "03586654"), new Customer("aya", "2458559658")
			};

			var custHashSet = new HashSet<Customer>(customers);
			var custHashSet2 = new HashSet<Customer>(customers2);
			//custHashSet.Add(cust6); add new item
			custHashSet.UnionWith(custHashSet2);

			foreach (var customer in custHashSet) Console.WriteLine(customer);

			Console.WriteLine("============Sorted Set=============");
			var sortedSet = new SortedSet<Customer>(customers);

			foreach (var item in sortedSet) Console.WriteLine(item);



		}
	}

	class Customer : IComparable<Customer>
	{
		public string Name { get; set; }
		public string Telephone { get; set; }
		public Customer() { }

		public Customer(string name, string telephone)
		{
			Name = name;
			Telephone = telephone;
		}

		public static void CreatCustomer(string name, string telephone, out Customer customer)
		{
			customer = new Customer(name, telephone);
		}

		public override int GetHashCode()
		{
			var hash = 17;
			hash = hash * 397 + Telephone.GetHashCode();
			return hash;
		}

		public override bool Equals(object obj)
		{
			var customer = obj as Customer;
			if (customer == null) return false;
			return this.Telephone.Equals(customer.Telephone);
		}

		public override string ToString()
		{
			return $"{Name}=>({Telephone})";
		}

		public int CompareTo(Customer other)
		{
			if (object.ReferenceEquals(this, other)) return 0;
			if (other == null) return -1;
			return this.Name.CompareTo(other.Name);
		}
	}

	class Order
	{
		public static int Id { get; set; } = 0;
		public string Name { get; set; }
		public double Price { get; set; }
		public DateTime CreatAt { get; set; }

		public Order(string name)
		{
			Name = name;
			switch (name)
			{
				case "crip":
					Price = 50;
					break;
				case "pizza":
					Price = 80;
					break;
				default:
					Price = 0;
					break;
			}

			++Id;
			CreatAt = DateTime.Now;
		}

		public override string ToString()
		{
			return $"id : {Id} , name : {Name} , time : {CreatAt} , price : {Price}";
		}
	}

}
