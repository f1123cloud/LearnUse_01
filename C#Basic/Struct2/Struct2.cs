using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStruct2
{
	/*結構體 Struct
      實值型別資料結構。它使得一個單一變數可以儲存各種資料型態的相關資料。
	  結構體是用來代表一個資料*/
	class Program
	{
		static void Main(string[] args)
		{
			Student stu1 = new Student() { ID = 101, Name = "Cloud" };
			Student stu2 = stu1;
			stu2.ID = 1001;
			stu2.Name = "Zack";
			Console.WriteLine($"#{stu1.ID} Name:{stu1.Name}");
			Console.WriteLine($"#{stu2.ID} Name:{stu2.Name}");
			stu1.Speak();
		}
	}

	interface ISpeak
	{
		void Speak();
	}

	struct Student : ISpeak
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public void Speak()
		{
			Console.WriteLine($"I'm #{this.ID} Student:{this.Name}.");
		}
	}
}
