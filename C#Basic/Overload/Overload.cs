using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOverload
{
	/*同一個函式的名稱，卻有不同的參數類型與數量(不含回傳值的型別)，
	  此時，要呼叫這個函式的時候，就需要根據所傳入的引數來判斷，
	  通常在 Visual Studio 內，會有 IntelliSense 來幫助我們來選擇可以使用那些函式*/

	class Program
	{
		static void Main(string[] args)
		{
			Overload o = new Overload();

			int x1 = o.Add(100, 100);
			Console.WriteLine(x1);

			int x2 = o.Add(100, 100, 100);
			Console.WriteLine(x2);

			double x3 = o.Add(100D, 100D);
			Console.WriteLine(x3);
		}
	}

	class Overload
	{
		public int Add(int a, int b)
		{
			return a + b;
		}

		public int Add(int a, int b, int c)
		{
			return a + b + c;
		}

		public double Add(double a, double b)
		{
			return a + b;
		}
	}
}
