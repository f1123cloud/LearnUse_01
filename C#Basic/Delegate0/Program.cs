using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDelegate0
{
	/*委託 Delegate

	返回值的數據類型一致
	把方法當作參數傳給另一個方法

	缺點
	緊耦合
	可讀性下降 Debug難度增加
	
	Action和Func兩者差異
    Action是void不回傳值得委託
    Func是有回傳值的委託*/

	class Program
	{
		static void Main(string[] args)
		{
			Action<string, string> action = new Action<string, string>(SayHello);
			action("Cloud", "Tifa");

			var action2 = new Action<string, int>(SayHello2);
			action2("Cloud", 3);

			Func<int, int, int> Func = new Func<int, int, int>(Add);
			int res = Func(100, 200);
			Console.WriteLine(res);

			var func = new Func<double, double, double>(Mul);
			double res2 = func(3.0, 4.0);
			Console.WriteLine(res2);
		}

		static void SayHello(string name1, string name2)
		{
			Console.WriteLine($"Hello,{name1} and {name2}!");
		}

		static void SayHello2(string name, int round)
		{
			for (int i = 0; i < round; i++)
			{
				Console.WriteLine($"Hello, {name}!");
			}
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
}
