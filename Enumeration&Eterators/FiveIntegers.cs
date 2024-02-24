using System;
using System.Collections;
using System.Reflection.Metadata;

namespace Enumeration_Eterators
{
	// create class IEnumerable pu you must create iner class IEnumerator
	class FiveIntegers : IEnumerable // he can't run without IEnumerator
	{
		private int[] _values;

		public FiveIntegers(int n1, int n2, int n3, int n4, int n5)
		{
			_values = new[] { n1, n2, n3, n4, n5 };
		}

		public IEnumerator GetEnumerator()
		{
			foreach (var item in _values)
			{
				yield return item; // yield => automatic create Ienumerator class (: 
			}
		}


		#region this old way to create IEnumerator
		//public IEnumerator GetEnumerator() => new Enumerator(this);

		//class Enumerator : IEnumerator
		//{
		//	private int courrentIndex = -1;
		//	private FiveIntegers _integers;

		//	public Enumerator(FiveIntegers integers)
		//	{
		//		_integers = integers;
		//	}

		//	#region implement IEnumerator

		//	public object Current
		//	{
		//		get
		//		{
		//			if (courrentIndex == -1)
		//				throw new InvalidOperationException("Enumeration not started");
		//			if (courrentIndex == _integers._values.Length)
		//				throw new InvalidOperationException("Enumeration has ended");
		//			return _integers._values[courrentIndex];
		//		}
		//	}

		//	public bool MoveNext()
		//	{
		//		if (courrentIndex >= _integers._values.Length - 1)
		//		{
		//			return false;
		//		}
		//		return ++courrentIndex < _integers._values.Length;
		//	}

		//	public void Reset() => courrentIndex = -1;
		//	#endregion

		//} 
		#endregion
	}
}