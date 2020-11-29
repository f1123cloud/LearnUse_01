using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLambda
{
	/*Lambda
	  匿名方法*/

	class Program
	{
		static void Main(string[] args)
		{
			//Func<int, int, int> func = new Func<int, int, int>((int a, int b) => { return a + b; });
			Func<int, int, int> func = (a, b) => { return a + b; };
			int res = func(100, 200);
			Console.WriteLine(res);

			//func = new Func<int, int, int>((int x, int y) => { return x * y; });
			func = (x, y) => { return x * y; };
			res = func(3, 4);
			Console.WriteLine(res);

			//DoSomeCale<int>((int a, int b) => { return a * b; }, 100, 200);
			DoSomeCale((a, b) => { return a * b; }, 100, 200);
			DoSomeCale((c, d) => { return c * d; }, 100.1, 200.2);
		}

		static void DoSomeCale<T>(Func<T, T, T> func, T x, T y)
		{
			T res = func(x, y);
			Console.WriteLine(res);
		}
	}
}
