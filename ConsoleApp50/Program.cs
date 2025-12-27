using System;
using System.Text;

namespace ConsoleApp50
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine(GenerateMultiplicationTables());
			DateTime date = DateTime.Now; 
			string str = date.ToString("d"); // str 為 "2023/3/9"
			Console.WriteLine(str);
			str = date.ToString("D");// str 為 "2023年3月9日"
			Console.WriteLine(str);
			DateTime time = DateTime.Now; 
			str = time.ToString("t"); // str 為 "下午 5:10"
			Console.WriteLine(str);
			str = time.ToString("T");// str 為 "下午 5:10:30"
			Console.WriteLine(str);
			DateTime datetime = DateTime.Now;
			str = datetime.ToString("f");// str 為 "2023年3月9日 下午 5:10"
			Console.WriteLine(str);
			str = datetime.ToString("F"); // str 為 "2023年3月9日 下午 5:10:30"
			Console.WriteLine(str);
			str = datetime.ToString("g");// str 為 "2023/3/9 下午 5:10"
			Console.WriteLine(str);
			str = datetime.ToString("G"); // str 為 "2023/3/9 下午 5:10:30"
			Console.WriteLine(str);
		}



		public static string GenerateMultiplicationTable(int n)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 1; i <= 9; i++)
			{
				int result = n * i;
				sb.AppendLine($"{n} x {i} = {result}");
			}
			return sb.ToString();
		}

		public static string GenerateMultiplicationTables(int start = 2, int end = 9)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = start; i <= end; i++)
			{
				sb.AppendLine(GenerateMultiplicationTable(i));
				sb.AppendLine();
			}
			return sb.ToString();
		}
	}
}
