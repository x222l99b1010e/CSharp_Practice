using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string str1 = null;
			string str2 = "";
			string str3 = "Hello";
			string str4 = string.Empty;
			Console.WriteLine(string.IsNullOrEmpty(str1));
			Console.WriteLine(string.IsNullOrEmpty(str2));
			Console.WriteLine(string.IsNullOrEmpty(str3));
			Console.WriteLine(string.IsNullOrWhiteSpace(str4));
		}
	}
}
