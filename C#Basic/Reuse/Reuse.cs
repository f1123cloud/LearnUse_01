using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReUse
{
	class Program
	{
		static void Main(string[] args)
		{
			Calculator c = new Calculator();
			Console.WriteLine(c.GetCircleArea(10));
			Console.WriteLine(c.ReUseGetCircleArea(10));
			Console.WriteLine(c.GetCylinderVolume(10, 2));
			Console.WriteLine(c.ReUseGetCylinderVolume(10, 2));
			Console.WriteLine(c.GetConeVolume(10, 2));
			Console.WriteLine(c.ReUseGetConeVolume(10, 2));
		}
	}

	class Calculator
	{
		public double GetCircleArea(double r)
		{
			return 3.14 * r * r;
		}

		public double GetCylinderVolume(double r, double h)
		{
			return 3.14 * r * r * h;
		}

		public double GetConeVolume(double r, double h)
		{
			return 3.14 * r * r * h / 3;
		}

		//複用方法
		public double ReUseGetCircleArea(double r)
		{
			return Math.PI * r * r;
		}

		public double ReUseGetCylinderVolume(double r, double h)
		{
			return ReUseGetCircleArea(r) * h;
		}

		public double ReUseGetConeVolume(double r, double h)
		{
			return ReUseGetCylinderVolume(r, h) / 3;
		}
	}
}
