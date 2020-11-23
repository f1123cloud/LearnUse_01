using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGenericInterface
{
	class Program
	{
		static void Main(string[] args)
		{
			//泛型接口之一
			Student<int> stu1 = new Student<int>();
			stu1.ID = 101;
			stu1.Name = "Cloud";
			Student<ulong> stu2 = new Student<ulong>();
			stu2.ID = 10000000000000000001;
			stu2.Name = "Cloud";

			//泛型接口之二
			Student stu = new Student();
			stu.ID = 10000000000001;
			stu.Name = "Cloud";
		}
	}

	interface IUniqua<TId>
	{
		TId ID { get; set; }
	}

	//泛型接口之一
	class Student<TId> : IUniqua<TId>
	{
		public TId ID { get; set; }
		public string Name { get; set; }
	}

	//泛型接口之二
	class Student : IUniqua<ulong>
	{
		public ulong ID { get; set; }
		public string Name { get; set; }
	}
}
