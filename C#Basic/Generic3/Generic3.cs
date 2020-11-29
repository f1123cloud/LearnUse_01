using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric3
{
	class Program
	{
		static void Main(string[] args)
		{
			Action<string> a1 = Say;
			a1("Cloud");
			Action<int> a2 = Mul;
			a2(1);
		}

		static void Say(string str)
		{
			Console.WriteLine($"Hello,{str}!");
		}

		static void Mul(int x)
		{
			Console.WriteLine(x * 100);
		}
	}
}
