using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStruct1
{
	class Program
	{
		static void Main(string[] args)
		{
			Student stu = new Student() { ID = 101, Name = "Cloud" };
			object obj = stu;//裝箱
			Student stu2 = (Student)obj;//拆箱
			Console.WriteLine($"#{stu2.ID} Name:{stu2.Name}");
		}
	}

	class Student
	{
		public int ID { get; set; }
		public string Name { get; set; }
	}
}
