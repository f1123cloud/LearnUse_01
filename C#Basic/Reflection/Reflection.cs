using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
	/*反射 Reflection
	公共語言運行時將為它創建一個 Type
	使用 Type 對象的方法、字段、屬性和嵌套類來查找有關該類型的所有訊息*/

	class Program
	{
		static void Main(string[] args)
		{
			//基本反射原理
			ITank tank = new HeavyTank();
			//====================================
			var t = tank.GetType();
			object o = Activator.CreateInstance(t);
			MethodInfo fireMi = t.GetMethod("Fire");
			MethodInfo runMi = t.GetMethod("Run");
			fireMi.Invoke(o, null);
			runMi.Invoke(o, null);
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
