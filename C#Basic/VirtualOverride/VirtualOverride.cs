using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVirtualOverride
{
	/*虛方法:virtual的方法可以使用override重寫
	  多態:通過指向派聲類的基類引用，調用虛函數，
	  根據引用所指向派生類的實際類型，調用派生類中的同名重寫函數*/

	class Program
	{
		static void Main(string[] args)
		{
			Vehicle v1 = new Vehicle();
			v1.Run();
			Console.WriteLine(v1.Speed);

			Vehicle v2 = new Car();
			v2.Run();
			Console.WriteLine(v2.Speed);
		}
	}

	class Vehicle
	{
		private int _speed;
		public virtual int Speed
		{
			get { return _speed; }
			set { Speed = value; }
		}

		public virtual void Run()
		{
			Console.WriteLine("I'm running!");
			_speed = 100;
		}
	}

	class Car : Vehicle
	{
		private int _rpm;

		public override int Speed
		{
			get { return _rpm / 100; }
			set { _rpm = value * 100; }
		}

		public override void Run()
		{
			Console.WriteLine("Car is running!");
			_rpm = 10000;
		}
	}

	class RaceCar : Car
	{
		public override void Run()
		{
			Console.WriteLine("Racecar is running!");
		}
	}
}
