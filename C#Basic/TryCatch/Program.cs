using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTryCatch
{
	class Program
	{
		static void Main(string[] args)
		{
			Calculator c = new Calculator();

			int one = c.Add(null, "100");
			Console.WriteLine(one);
			Console.WriteLine("=================================");

			int two = c.Add("轉換後不是int值", "100");
			Console.WriteLine(two);
			Console.WriteLine("=================================");

			int three = c.Add("999999999999999999999", "100");
			Console.WriteLine(three);
			Console.WriteLine("=================================");

			int done = c.Add("100", "100");
			Console.WriteLine(done);
			Console.WriteLine("=================================");
		}
	}

	class Calculator
	{
		public int Add(string arg1, string arg2)
		{
			int a = 0;
			int b = 0;
			bool hasError = false;

			try
			{
				a = int.Parse(arg1);
				b = int.Parse(arg2);
			}
			catch (ArgumentNullException ane)
			{
				Console.WriteLine(ane.Message);
				hasError = true;
			}
			catch (FormatException fe)
			{
				Console.WriteLine(fe.Message);
				hasError = true;
			}
			catch (OverflowException oe)
			{
				Console.WriteLine(oe.Message);
				hasError = true;
			}
			finally
			{
				if (hasError)
				{
					Console.WriteLine("Execution has error!");
				}
				else
				{
					Console.WriteLine("Done!");
				}
			}
			int result = a + b;
			return result;
		}

	}
}
