using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAbstract
{
	/*抽象類和抽象方法
 
  1.抽象成員
    必須是方法，屬性，事件，索引
	必須用abstract關鍵字
	不能有方法體

  2.抽象類
    目的是被繼承
	不能實例化，用abstract修飾
	可以包含抽象成員和普通成員
	在派生類中需要用override關鍵字*/

	class Program
	{
		static void Main(string[] args)
		{
			Vehicle v1 = new Car();
			v1.Run();

			Vehicle v2 = new Truck();
			v2.Run();

			Vehicle v3 = new RaceCar();
			v3.Run();
		}
	}

	abstract class Vehicle
	{
		public void Stop()
		{
			Console.WriteLine("Stopped!");
		}

		public void Fill()
		{
			Console.WriteLine("Pay and fill");
		}

		//抽象方法
		public abstract void Run();
	}

	class Car : Vehicle
	{
		public override void Run()
		{
			Console.WriteLine("Car is running...");
		}
	}

	class Truck : Vehicle
	{
		public override void Run()
		{
			Console.WriteLine("Truck is running...");
		}
	}

	class RaceCar : Vehicle
	{
		public override void Run()
		{
			Console.WriteLine("Racecar is running...");
		}
	}
}
