using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFor
{
	class Program
	{
		static void Main(string[] args)
		{
			PrintNumber p = new PrintNumber();
			p.ForPrintTo1(10);
			p.IfElsePrintTo1(10);

			//1到100加總和
			int resultForeach = p.ForSumFrom1ToX(100);
			Console.WriteLine(resultForeach);
			int resultIfElse = p.IfElseSumFrom1ToX(100);
			Console.WriteLine(resultIfElse);
			int resultMath = p.MathSumFrom1ToX(100);
			Console.WriteLine(resultMath);
		}
	}

	class PrintNumber
	{
		public void ForPrintTo1(int x)
		{
			for (int i = x; i > 0; i--)
			{
				Console.WriteLine(i);
			}
		}

		public void IfElsePrintTo1(int x)
		{
			if (x == 1)
			{
				Console.WriteLine(x);
			}
			else
			{
				Console.WriteLine(x);
				IfElsePrintTo1(x - 1);
			}
		}

		public int ForSumFrom1ToX(int x)
		{
			int result = 0;
			for (int i = 1; i < x + 1; i++)
			{
				result = result + i;
			}
			return result;
		}

		public int IfElseSumFrom1ToX(int x)
		{
			if (x == 1)
			{
				return 1;
			}
			else
			{
				int result = x + IfElseSumFrom1ToX(x - 1);
				return result;
			}
		}

		public int MathSumFrom1ToX(int x)
		{
			return (1 + x) * x / 2;
		}
	}
}
