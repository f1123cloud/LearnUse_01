using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLoop
{
	/*差異
	  While    重複執行，直到達到指定的條件時，才會停止
	  DoWhile  至少會執行一次迴圈的內容
	  For      迴圈必須等到邏輯運算達到指定條件後，才會終止
	  Foreach  每一次迴圈時，從集合中取出一個新的元素值*/

	class Program
	{
		static void Main(string[] args)
		{
			MyWhile mw = new MyWhile();
			mw.GoWhile();

			MyDoWhile dmw = new MyDoWhile();
			dmw.GoDoWhile();

			MyFor mf = new MyFor();
			mf.DoMathTable();

			MyForeach forh = new MyForeach();
			forh.DoForeach();
		}
	}

	class MyWhile
	{
		int score = 0;
		bool canContinue = true;

		public void GoWhile()
		{
			while (canContinue)
			{
				Console.WriteLine("Start While Test!!");
				Console.WriteLine("input 2number = 100");
				Console.WriteLine("Please input first number: ");
				string str1 = Console.ReadLine();
				int x = int.Parse(str1);

				Console.WriteLine("Please input second number: ");
				string str2 = Console.ReadLine();
				int y = int.Parse(str2);

				int sum = x + y;
				if (sum == 100)
				{
					score++;
					Console.WriteLine("Correct! {0}+{1}={2}", x, y, sum);
				}
				else
				{
					Console.WriteLine("Error! {0}+{1}={2}", x, y, sum);
					canContinue = false;
				}
			}
			Console.WriteLine("Your score is {0} Point!!", score);
			Console.WriteLine("GAME OVER!");
			Console.WriteLine("===============================");
		}
	}

	class MyDoWhile
	{
		int score = 0;
		int sum = 0;

		public void GoDoWhile()
		{
			do
			{
				Console.WriteLine("Start DoWhile Test!!");
				Console.WriteLine("Input (End) Can Close Game! ");
				Console.WriteLine("input 2number = 100 Can Add Point");
				Console.WriteLine("Please input first number: ");

				string str1 = Console.ReadLine();
				if (str1.ToLower() == "end")
				{
					break;
				}
				int x = 0;
				try
				{
					x = int.Parse(str1);
				}
				catch
				{
					Console.WriteLine("First number has problem. Restart input!!");
					continue;
				}

				Console.WriteLine("Please input second number: ");
				string str2 = Console.ReadLine();
				if (str2.ToLower() == "end")
				{
					break;
				}
				int y = 0;
				try
				{
					y = int.Parse(str2);
				}
				catch
				{
					Console.WriteLine("Second number has problem. Restart input!!");
					continue;
				}

				sum = x + y;
				if (sum == 100)
				{
					score++;
					Console.WriteLine("Correct! {0}+{1}={2}", x, y, sum);
				}
				else
				{
					Console.WriteLine("Error! {0}+{1}={2}", x, y, sum);
				}
			} while (sum == 100);
			Console.WriteLine("Your score is {0} Point!!", score);
			Console.WriteLine("GAME OVER!");
			Console.WriteLine("===============================");
		}
	}

	class MyFor
	{
		public void DoMathTable()
		{
			for (int a = 1; a <= 9; a++)
			{
				for (int b = 1; b <= a; b++)
				{
					Console.Write("{0}x{1}={2}\t", a, b, a * b);
				}
				Console.WriteLine();
			}
		}
	}

	class MyForeach
	{
		public void DoForeach()
		{
			int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
			List<int> intList = new List<int>() { 9, 8, 7, 6, 5, 4, 3, 2, 1 };

			foreach (var current in intArray)
			{
				Console.Write(current);
			}

			Console.WriteLine();

			foreach (var current in intList)
			{
				Console.Write(current);
			}
			Console.WriteLine();
		}
	}
}
