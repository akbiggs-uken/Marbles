using System;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public static class ListExtensions
	{
		public static T Pop<T>(this List<T> list, int index) {
			T poppedValue = list[index];
			list.RemoveAt(index);
			return poppedValue;
		}
	}
}

