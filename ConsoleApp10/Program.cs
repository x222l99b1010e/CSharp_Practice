using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("請輸入至少8~16個字的密碼：");
			string passWord = Console.ReadLine();

			if (passWord.Length < 8)
			{
				Console.WriteLine("密碼長度不足8個字");
			}
			else if (passWord.Length > 16) 
			{
				Console.WriteLine("密碼長度超過16個字");
			}
			else
			{
				Console.WriteLine("輸入了符合正確長度的密碼");
			}

			Console.WriteLine(passWord);
		}
	}
}
