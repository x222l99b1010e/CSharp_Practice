using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20
{
	internal class Program
	{
		/// <summary>
		/// >= 70男性，1元
		/// >= 60女性，2元
		/// <=  3小孩，0元
		/// 其他，15元
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{

			bool gender = false;//性別
			int age = 3;
			int fee = 0;

			if (age <= 3)
			{
				fee = 0;
				Console.WriteLine("您為孩童，免費搭乘。");
				return;
			}
			else if (gender && age >= 70)
			{
				fee = 1;
			}
			else if (!gender && age >= 60)
			{
				fee = 2;
			}
			else
			{
				fee = 15;
			}
			Console.WriteLine($"您的票價為{fee}元。");
		}
	}
}
