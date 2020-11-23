using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProperty
{
	/*屬性 Property
	  是另一種型別的類成員，定義屬性的目的是在於便於一些私有欄位的訪問。
	  類提供給外部呼叫時用的可以設定或讀取一個值，屬性則是對欄位的封裝，
	  將欄位和訪問自己欄位的方法組合在一起，提供靈活的機制來讀取、編寫或計算私有欄位的值。
	  屬性有自己的名稱，並且包含get 訪問器和set 訪問器*/

	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				Student stu1 = new Student();
				stu1.Age = 20;
				Student stu2 = new Student();
				stu2.Age = 20;
				Student stu3 = new Student();
				stu3.Age = 200;

				int avgAge = (stu1.Age + stu2.Age + stu3.Age) / 3;
				Console.WriteLine(avgAge);
			}
			catch (Exception ex)
			{

				Console.WriteLine(ex.Message);
			}

		}
	}

	class Student
	{
		private int age;
		public int Age
		{
			get
			{
				return this.age;
			}
			set
			{
				if (value >= 0 && value <= 120)
				{
					this.age = value;
				}
				else
				{
					throw new Exception("Age value has error!!");
				}
			}
		}
	}
}
