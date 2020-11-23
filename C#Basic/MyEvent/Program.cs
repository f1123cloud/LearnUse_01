using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyEvent
{
	/*事件Event
      發布者: 通知某件事情發生
      訂閱者: 對某件事情關注
      事件觸發: 通知所有關注該事件的訂閱者
      註冊: 想在事件發生時被通知
      事件發生時，通知訂閱者，就是調用訂閱者的註冊函數，註冊，就是告訴發布者調用哪一個註冊函數*/
	class Program
	{
		static void Main(string[] args)
		{
			Customer customer = new Customer();
			Waiter waiter = new Waiter();
			customer.Order += waiter.Action;
			customer.Action();
			customer.PayTheBill();
		}
	}

	public class OrderEventArgs : EventArgs
	{
		public string DishName { get; set; }
		public string Size { get; set; }
	}

	public class Customer
	{
		public event EventHandler Order;

		public double Bill { get; set; }

		public void PayTheBill()
		{
			Console.WriteLine("I will pay ${0}.", this.Bill);
		}

		public void WalkIn()
		{
			Console.WriteLine("Walk into the restaurant.");
		}

		public void SitDown()
		{
			Console.WriteLine("Sit down.");
		}

		public void Think()
		{
			for (int i = 0; i < 5; i++)
			{
				Console.WriteLine("Let me think...");
				Thread.Sleep(1000);
			}
			this.OnOrder("Kongpao Chicken", "large");
		}

		protected void OnOrder(string dishName, string size)
		{
			if (this.Order != null)
			{
				OrderEventArgs e = new OrderEventArgs();
				e.DishName = dishName;
				e.Size = size;
				this.Order.Invoke(this, e);
			}
		}

		public void Action()
		{
			Console.ReadLine();
			this.WalkIn();
			this.SitDown();
			this.Think();
		}
	}

	public class Waiter
	{
		public void Action(object sender, EventArgs e)
		{
			Customer customer = sender as Customer;
			OrderEventArgs orderInfo = e as OrderEventArgs;
			Console.WriteLine("I will serve you the dish - {0}.", orderInfo.DishName);
			double price = 10;
			switch (orderInfo.Size)
			{
				case "small":
					price = price * 0.5;
					break;
				case "large":
					price = price * 1.5;
					break;
				default:
					break;
			}
			customer.Bill += price;
		}
	}
}
