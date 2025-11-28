using System;

namespace ConsoleApp4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int total = 1;
			Console.WriteLine(total);
			total += 2;
			Console.WriteLine(total);
			total += 2;
			Console.WriteLine(total);
			total = 999;
			Console.WriteLine(total);

			for (int i = 1; i < 19; i +=2)
			{
				if (i % 3 == 0)
				{
					Console.WriteLine('*');
				}
				else if (i % 5 == 0)
				{
					Console.WriteLine("\"Fuen43\"");				
				}

				else
				{
					Console.WriteLine(i);
				}
			}

			decimal taxRate = 0.05m;
			Console.WriteLine(taxRate);
			decimal priceWithTax = (taxRate + 1);
			decimal apple = 59;
			Console.WriteLine(apple * priceWithTax);
		}
	}
}
