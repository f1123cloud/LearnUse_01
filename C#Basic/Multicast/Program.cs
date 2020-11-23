using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyMulticast
{
	/*多播委派 Multicast Delegate
	  同步調用 異步調用
      進程(Process)
      線程(Thread)
      同步調用是在同一線程內
      異步調用是多線程
      串行==同步==單線程
      並行==異步==多線程

      隱式多線程 顯示多線程
      直接同步調用  使用方法名
      間接同步調用  使用單播/多播委派的Invoke方法
      隱式異步調用  使用委派的BeginInvoke
      顯示異步調用  使用Thread或Task

      應適時使用接口(Interface)取代一些委派使用*/


	class Program
	{
		static void Main(string[] args)
		{
			Student stu1 = new Student() { ID = 1, PenColor = ConsoleColor.Yellow };
			Student stu2 = new Student() { ID = 2, PenColor = ConsoleColor.Green };
			Student stu3 = new Student() { ID = 3, PenColor = ConsoleColor.Red };
			Action action1 = new Action(stu1.DoHomework);
			Action action2 = new Action(stu2.DoHomework);
			Action action3 = new Action(stu3.DoHomework);
			Thread thread1 = new Thread(new ThreadStart(stu1.DoHomework));
			Thread thread2 = new Thread(new ThreadStart(stu2.DoHomework));
			Thread thread3 = new Thread(new ThreadStart(stu3.DoHomework));
			Task task1 = new Task(new Action(stu1.DoHomework));
			Task task2 = new Task(new Action(stu2.DoHomework));
			Task task3 = new Task(new Action(stu3.DoHomework));

			//直接(同步調用)
			stu1.DoHomework();
			stu2.DoHomework();
			stu3.DoHomework();

			//間接(同步調用)
			action1.Invoke();
			action2.Invoke();
			action3.Invoke();

			//多播委託(同步調用)
			action1 += action2;
			action1 += action3;
			action1.Invoke();

			//隱式異步調用
			action1.BeginInvoke(null, null);
			action2.BeginInvoke(null, null);
			action3.BeginInvoke(null, null);

			//顯式異步調用
			thread1.Start();
			thread2.Start();
			thread3.Start();

			task1.Start();
			task2.Start();
			task3.Start();

			for (int i = 1; i < 4; i++)
			{
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.WriteLine("Main thread{0},", i);
				Thread.Sleep(1000);
			}
		}
	}
}

class Student
{
	public int ID { get; set; }
	public ConsoleColor PenColor { get; set; }

	public void DoHomework()
	{
		for (int i = 1; i < 4; i++)
		{
			Console.ForegroundColor = this.PenColor;
			Console.WriteLine("Studend,{0} doing homework{1}hour(s).", this.ID, i);
			Thread.Sleep(1000);
		}
	}
}
