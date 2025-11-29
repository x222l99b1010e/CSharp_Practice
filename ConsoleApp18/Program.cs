using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string input = "abc";
			bool isValid = input.Length > 0; // true
			Console.WriteLine(isValid);

			if (isValid) {
				Console.WriteLine(input);
			}
		}
	}
}
