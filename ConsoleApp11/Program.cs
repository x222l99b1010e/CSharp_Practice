using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Int64 num = 65535;
			Int64 result = num * num;
			Console.WriteLine(result);
			int num1 = 65535;
			int result1 = num1 * num1;
			Console.WriteLine(result1);
		}
	}
}
