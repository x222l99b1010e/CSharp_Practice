using System;

namespace ConsoleApp14
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("請輸入全名：");
			string fullName =  Console.ReadLine();

			if (string.IsNullOrWhiteSpace(fullName))
			{
				Console.WriteLine("全名不能為空，請重新輸入!");
			}
			else {
				Console.WriteLine($"您的全名為{fullName}");			
			}
		}
	}
}
