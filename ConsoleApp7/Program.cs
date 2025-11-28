using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.Write("請輸入全名：");
			//string fullName = Console.ReadLine();
			//Console.WriteLine("Hi," + fullName);

			double tax = 0.05;
			int price = 100;
			Console.WriteLine(price*tax);

			int counter = 0;
			for (int i = 0; i <= 100; i++)
			{ 
				counter++;
				if (i == 50)tax = 0.1;
				Console.WriteLine($"現在tax={tax}, i={i}");						
			}
			Console.WriteLine(price * tax);
		}
	}
}
