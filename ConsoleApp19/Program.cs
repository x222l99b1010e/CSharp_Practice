using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region 根據年齡性別計算車資
			//男性，18以下，免費
			//男性，18以上，30元
			//女性，18以下，10元
			//女性，18以上，20元
			Console.Write("請輸入性別(男性:true/女性:false)：");
			bool gender = bool.Parse(Console.ReadLine());
			Console.Write("請輸入年齡：");
			int age = int.Parse(Console.ReadLine());

			int fee2;//車資

			if (gender)
			{
				fee2 = (age < 18) ? 0 : 30;
			}
			else 
			{
				fee2 = (age < 18) ? 10 : 20;
			}
			Console.WriteLine($"您好，您的車資為{fee2}元");

			//if (gender)
			//{
			//	if (age < 18)
			//	{
			//		fee2 = 0;
			//	}
			//	else
			//	{
			//		fee2 = 30;
			//	}
			//}
			//else {
			//	if (age < 18)
			//	{
			//		fee2 = 10;
			//	}
			//	else
			//	{
			//		fee2 = 20;
			//	}
			//}
			//Console.WriteLine($"您好，您的車資為{fee2}元");

			//if (gender && age < 18)
			//{
			//	fee2 = 0;
			//}
			//else if (gender && age >= 18)
			//{
			//	fee2 = 30;
			//}
			//else if (!gender && age < 18)
			//{
			//	fee2 = 10;
			//}
			//else
			//{
			//	fee2 = 20;
			//}
			//Console.WriteLine($"您好，您的車資為{fee2}元");

			#endregion


		}
	}
}
