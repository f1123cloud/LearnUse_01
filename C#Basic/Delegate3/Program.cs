using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegate3
{
	class Program
	{
		static void Main(string[] args)
		{
			MyDele<int> deleAdd = new MyDele<int>(Add);
			int res = deleAdd(100, 200);
			Console.WriteLine(res);
			MyDele<double> deleMul = new MyDele<double>(Mul);
			double mulRes = deleMul(3.0, 4.0);
			Console.WriteLine(mulRes);
		}

		static int Add(int x, int y)
		{
			return x + y;
		}

		static double Mul(double x, double y)
		{
			return x * y;
		}
	}

	delegate T MyDele<T>(T a, T b);
}
