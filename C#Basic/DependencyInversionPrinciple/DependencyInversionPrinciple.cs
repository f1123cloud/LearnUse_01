﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDependencyInversionPrinciple
{

	/*依賴反轉原則 Dependency Inversion Principle(DIP)
	高層模組不應該依賴於低層模組。兩者皆應該依賴抽象。
	抽象不應該依賴細節。細節應該依賴抽象*/

	class Program
	{
		static void Main(string[] args)
		{
			var fan = new DeskFan(new PowerSupply());
			Console.WriteLine(fan.Work());
		}
	}

	public interface IPowerSupply
	{
		int GetPower();
	}

	public class PowerSupply : IPowerSupply
	{
		public int GetPower()
		{
			return 110;
		}
	}

	public class DeskFan
	{
		private IPowerSupply _powerSupply;
		public DeskFan(IPowerSupply powerSupply)
		{
			_powerSupply = powerSupply;
		}

		public string Work()
		{
			int power = _powerSupply.GetPower();
			if (power <= 0)
			{
				return "Won't work.";
			}
			else if (power < 100)
			{
				return "Slow";
			}
			else if (power < 200)
			{
				return "Work fine";
			}
			else
			{
				return "Warring!";
			}
		}
	}
}
