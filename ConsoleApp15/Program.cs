using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int age = 30;
			string info = "";
			info = (age > 18) ? "已成年" : "未成年";
			Console.WriteLine(info);
		}
	}
}
