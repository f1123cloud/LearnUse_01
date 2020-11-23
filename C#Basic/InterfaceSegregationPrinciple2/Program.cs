using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterfaceSegregationPrincipe2
{
	class Program
	{
		static void Main(string[] args)
		{
			IKiller killer = new WarmKiller();
			killer.Kill();
			var wk = killer as WarmKiller;
			wk.Love();
		}
	}

	interface IGentleman
	{
		void Love();
	}

	interface IKiller
	{
		void Kill();
	}

	class WarmKiller : IGentleman, IKiller
	{
		public void Love()
		{
			Console.WriteLine("I will love you for ever...");
		}
		public void Kill()
		{
			Console.WriteLine("Let me kill the enemy...");
		}
	}
}
