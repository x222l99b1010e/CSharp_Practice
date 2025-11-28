using System;
using System.Threading;

namespace ConsoleApp5
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write(123);
			Console.WriteLine("Allen Kuo");
			Console.Write(123);
			Console.WriteLine("\n");
			int height = 170;
			int weight = 60;
			string name = "Allen";
			string message = name + height + weight ;//不好的寫法，
													 //name 是字串，
													 //後面的 height、weight 會被 自動轉成字串 再做字串相加（串接），
													 //會被隱式呼叫 ToString() 先變成字串：
													 //height.ToString() → "170"
													 //weight.ToString() → "60"
													 //Allen17060
			Console.WriteLine(message);
			message = name + (height + weight);
			Console.WriteLine(message);
			message = name + (height + weight).ToString();// 
			Console.WriteLine(message);
			message = name + height.ToString() + weight.ToString();
			Console.WriteLine(message);
			//換行
			Console.WriteLine("第1行第2行");//換行
			Console.WriteLine("第1行\n第2行");//換行
			Console.WriteLine("隔開");
			Console.WriteLine("第1行\r\n第2行");//換行
											// return \r的效果
			//組合成 \r\n 時，主控台會把它當作「換到下一行行首」用。
			Console.WriteLine("1234\rZ");//Z234
										 //多行，使用@符號
			Console.Write("第1行");
			Thread.Sleep(1000);       // 等待一下看變化
			Console.Write("\r第2行"); // \r 把游標拉回這一行行首，再寫「第2行」
			Console.Write("\n");
			string message1 = @"第10行



第11行";
			Console.WriteLine(message1);
			message1 = "line 1 \n\n\n\n\n line2";
			Console.WriteLine(message1);

		}
	}
}
