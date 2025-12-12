using System;

namespace ConcatStringStringExec
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//結果=>My name is Allen Kuo, and my height is 100cm.
			//給定下列變數完成
			string firstName = "Allen";
			string lastName = "Kuo";
			int height = 100;
			string message =firstName +" "+lastName;// 請完成這行程式 
			Console.WriteLine(message);
			Console.WriteLine($"My name is {message}, and my height is {height}cm.");
		}
	}
}
