using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnum
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			Person person = new Person();
			person.Level = Level.Boss1;

			Person boss = new Person();
			boss.Level = Level.Boss1;

			Console.WriteLine(boss.Level > person.Level);
			Console.WriteLine((int)Level.Boss1);
			Console.WriteLine((int)Level.Boss2);
			Console.WriteLine((int)Level.Boss3);
			Console.WriteLine((int)Level.Boss4);

			Console.WriteLine("=========================");
			Console.WriteLine("==========比特位==========");

			//比特位
			person.Name = "Cloud";
			person.Skill = Skill.Drive | Skill.Cook | Skill.Program | Skill.Teach;
			Console.WriteLine(person.Skill);
			Console.WriteLine((person.Skill & Skill.Cook) > 0);
			Console.WriteLine((person.Skill & Skill.Cook) == Skill.Cook);
		}
	}

	enum Level
	{
		Boss1,
		Boss2 = 100,
		Boss3,
		Boss4 = 200,
	}

	//比特位
	enum Skill
	{
		Drive = 1,
		Cook = 2,
		Program = 4,
		Teach = 8,
	}


	class Person
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public Level Level { get; set; }
		public Skill Skill { get; set; }
	}
}
