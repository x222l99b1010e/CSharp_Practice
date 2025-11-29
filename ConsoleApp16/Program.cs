using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int a = 10, b = 20;
			int max = (a > b) ? a : b;//使用三元運算子找出最大值
			Console.WriteLine(max);

			int max2 = Math.Max(a, b);//使用Math.max找出最大值
			Console.WriteLine(max2);
		}
	}
}
