using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._50._90輸出
{
	//新增一個主控台應用程式, 依序要求使用者輸入
	//姓
	//名字
	//Email
	//並在輸入完畢之後, 顯示以下文字
	//您好, 王 小明
	//您的電子信箱是: allen @gmail.com
	//上方文字的"王 小明", "allen@gmail.com" 是使用者輸入的值
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("請輸入姓：");
			string lastName = Console.ReadLine();
			Console.Write("請輸入名：");
			string firstName = Console.ReadLine();
			Console.Write("請輸入電子信箱：");
			string email = Console.ReadLine();

			Console.WriteLine("");
			Console.WriteLine($"您好，{lastName}{firstName}，{email}");
			string message = $@"您好," + lastName + firstName + ",\r\n您的電子信箱為" + email;
			Console.WriteLine(message);

		}
	}
}
