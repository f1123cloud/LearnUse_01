using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterfaceSegregationPrinciple1
{
	/*接口隔離原則
	  以最小的依賴來創建接口*/

	class Program
	{
		static void Main(string[] args)
		{
			var driver = new Driver(new HeavyTank());
			driver.Drive();
		}
	}

	class Driver
	{
		private IVehicle _vehicle;
		public Driver(IVehicle vehicle)
		{
			_vehicle = vehicle;
		}

		public void Drive()
		{
			_vehicle.Run();
		}
	}

	interface IVehicle
	{
		void Run();
	}

	class Car : IVehicle
	{
		public void Run()
		{
			Console.WriteLine("Car is running...");
		}
	}

	class Truck : IVehicle
	{
		public void Run()
		{
			Console.WriteLine("Truck is running...");
		}
	}

	interface IWeapon
	{
		void Fire();
	}

	interface ITank : IVehicle, IWeapon
	{
	}

	class LightTank : ITank
	{
		public void Fire()
		{
			Console.WriteLine("Boom!");
		}

		public void Run()
		{
			Console.WriteLine("Ka Ka Ka!...");
		}
	}

	class MediumTank : ITank
	{
		public void Fire()
		{
			Console.WriteLine("Boom!!");
		}

		public void Run()
		{
			Console.WriteLine("Ka Ka Ka!!...");
		}
	}

	class HeavyTank : ITank
	{
		public void Fire()
		{
			Console.WriteLine("Boom!!!");
		}

		public void Run()
		{
			Console.WriteLine("Ka Ka Ka!!!...");
		}
	}
}
