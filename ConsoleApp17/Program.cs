using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp17
{
	internal class Program
	{
		/// <summary>
		/// 計算停車費,一小時？元,每天最多收？元
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args)
		{
			int hours = 8;//停車費
			int fee;//停車費用
			const int hourlyRate = 60;//每小時停車費
			const int maxFee = 200;//每天最高收費

			//使用三元運算子計算停車費
			fee = (hours * hourlyRate > maxFee) ? maxFee : hours * hourlyRate;
			Console.WriteLine($"停車費用為{fee}");

			//使用Math.Min找出最小值
			fee = Math.Min(hours * hourlyRate, maxFee);
			Console.WriteLine($"停車費用為{fee}");
		}
	}
}
