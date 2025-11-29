using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool gender = false;
			int age = 3;

			int fee = GetFare(gender, age);

			if (age <= 3)
				Console.WriteLine("您為孩童，免費搭乘。");
			else
				Console.WriteLine($"您的票價為{fee}元。");
		}
		static int GetFare(bool gender, int age)
		{
			if (age < 0) throw new ArgumentOutOfRangeException(nameof(age));

			if (age <= 3) return 0;           // 直接回傳，呼叫端可依此決定是否繼續
			if (gender && age >= 70) return 1;
			if (!gender && age >= 60) return 2;
			return 15;
		}
	}
}
