using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("\"");
			string message = "ab\"c";//  \r, \n, \t, \"
			Console.WriteLine(message);
			message = @"ab""c";
			Console.WriteLine(message);
			message = @"ab""""c";
			Console.WriteLine(message);
			message = "ab\td";//tab
			Console.WriteLine(message);
			message = "abc\td";
			Console.WriteLine(message);
			message = "abc	d";
			Console.WriteLine(message);
			message = "c:\temp\a.jpg";//a是電腦會嗶一聲
			//Console.WriteLine(message);
			string fullPath = "c:\\temp\\a.jpg";
			Console.WriteLine(fullPath);
			fullPath = @"c:\temp\a.jpg";//有@
			Console.WriteLine(fullPath);

		}
	}
}
