using System;

namespace Enumeration_Eterators
{
	class Temprtuer : IComparable
	{
		private int _vlaue;
		public int Value
		{
			get => _vlaue;
		}

		public Temprtuer(int vlaue)
		{
			_vlaue = vlaue;
		}

		public int CompareTo(object obj)
		{
			if (obj is null)
				return 1;
			var temp = obj as Temprtuer;
			if (temp is null)
				throw new ArgumentException("object is not atemprtuer object");
			return this._vlaue.CompareTo(temp._vlaue);
		}
	}
}