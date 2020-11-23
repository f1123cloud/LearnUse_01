using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyReference
{
	/*引用參數
	  用ref修飾符聲明形參，引用形參並不創建新的記憶體位置(是方法調用作為實參的變量記憶體位置)*/

	class Program
	{
		static void Main(string[] args)
		{
			Student outterStu1 = new Student() { Name = "Tim" };
			Console.WriteLine("HashCode={0},Name={1}", outterStu1.GetHashCode(), outterStu1.Name);
			Console.WriteLine("===============================");
			IWantSideEffect(ref outterStu1);
			Console.WriteLine("HashCode={0},Name={1}", outterStu1.GetHashCode(), outterStu1.Name);
			Console.WriteLine("=================================================");

			Student outterStu2 = new Student() { Name = "Tim" };
			Console.WriteLine("HashCode={0},Name={1}", outterStu2.GetHashCode(), outterStu2.Name);
			Console.WriteLine("===============================");
			SomeSideEffect(ref outterStu2);
			Console.WriteLine("HashCode={0},Name={1}", outterStu2.GetHashCode(), outterStu2.Name);
		}

		static void IWantSideEffect(ref Student stu)
		{
			stu = new Student() { Name = "Tom" };
			Console.WriteLine("HashCode={0},Name={1}", stu.GetHashCode(), stu.Name);
		}

		static void SomeSideEffect(ref Student stu)
		{
			stu.Name = "Tom";
			Console.WriteLine("HashCode={0},Name={1}", stu.GetHashCode(), stu.Name);
		}
	}

	class Student
	{
		public string Name { get; set; }
	}
}
