using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterface
{
	/*接口 interface關鍵字
      指定一組函數成員，不實現引用類型
      只能用來被實現
      也是一種引用類型
      可實現多個接口*/

	class Program
	{
		static void Main(string[] args)
		{
			var user1 = new PhoneUser(new NokiaPhone());
			user1.UserPhone();

			var user2 = new PhoneUser(new SonyPhone());
			user2.UserPhone();
		}
	}

	class PhoneUser
	{
		private IPhone _phone;
		public PhoneUser(IPhone phone)
		{
			_phone = phone;
		}

		public void UserPhone()
		{
			_phone.Dail();
			_phone.PickUp();
			_phone.Send();
			_phone.Receive();
		}
	}

	interface IPhone
	{
		void Dail();
		void PickUp();
		void Send();
		void Receive();
	}

	class NokiaPhone : IPhone
	{
		public void Dail()
		{
			Console.WriteLine("Nokia calling!");
		}

		public void PickUp()
		{
			Console.WriteLine("Nokia PickUp!");
		}

		public void Send()
		{
			Console.WriteLine("Nokia Send!");
		}

		public void Receive()
		{
			Console.WriteLine("Nokia Receive!");
		}
	}

	class SonyPhone : IPhone
	{
		public void Dail()
		{
			Console.WriteLine("Sony calling!");
		}

		public void PickUp()
		{
			Console.WriteLine("Sony PickUp!");
		}

		public void Send()
		{
			Console.WriteLine("Sony Send!");
		}

		public void Receive()
		{
			Console.WriteLine("Sony Receive!");
		}
	}
}
