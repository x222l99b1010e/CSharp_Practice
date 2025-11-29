using System;
using System.Linq;

namespace ConsoleApp22
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int num1 = 15, num2 = 20, num3 = 6;
			int max = num1;
			max = Math.Max(max, num2);
			max = Math.Max(max, num3);
			Console.WriteLine($"三個數值為{num1}、{num2}、{num3}，最大數值為{max}");
			//Console.Read();

			max = num1;
			max = (num2 > max) ? num2 : max;
			max = (num3 > max) ? num3 : max;
			Console.WriteLine($"三個數值為 {num1}, {num2}, {num3}, 最大值為 {max}");
			//Console.Read();

			int[] numbers = { 10, 6, 15, 2000, 99999 };
			int max1 = numbers.Max();
			Console.WriteLine(max1);

		}
	}
}
