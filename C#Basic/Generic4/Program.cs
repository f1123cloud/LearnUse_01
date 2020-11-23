using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric4
{
	class Program
	{
		static void Main(string[] args)
		{
			Func<double, double, double> func1 = Add;
			var result1 = func1(100.1, 200.2);
			Console.WriteLine(result1);

			//泛型與Lambda結合使用
			Func<double, double, double> func2 = (a, b) => { return a + b; };
			var result2 = func1(100.1, 200.2);
			Console.WriteLine(result2);

		}

		static int Add(int a, int b)
		{
			return a + b;
		}

		static double Add(double a, double b)
		{
			return a + b;
		}
	}
}
