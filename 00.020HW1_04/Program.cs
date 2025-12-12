using System.Text;

namespace _00._020HW1_04
{
	internal class Program
	{
		//用迴圈呈現指定的結果
		//++++1
		//+++22
		//++333
		//+4444
		//55555
		static void Main(string[] args)
		{
			Console.WriteLine(PrintString(5));
			Console.WriteLine(PrintString1(5));
			Console.WriteLine(PrintStringOptimized(5));
		}

		static string PrintString(int rows)
		{
			StringBuilder sb = new();
			for (int i = 1; i <= rows; i++)
			{
				char numChar = (char)(i + '0');  // 轉成對應數字字元
				//'0' 是字元型別(char)，它的 ASCII / Unicode 編碼是 48。
				//'1' 的編碼是 49， '2' 是 50，以此類推。
				string row = new string('+', rows - i) + new string(numChar, i);
				sb.AppendLine(row);
			}
			return sb.ToString();
		}

		static string PrintString1(int rows)
		{
			StringBuilder sb = new();
			for (int i = 1; i <= rows; i++)
			{
				StringBuilder row = new();
				// 前面的 '+'
				row.Append('+', rows - i);
				// 重複的數字
				char numChar = (char)(i + '0');
				row.Append(numChar, i);

				sb.AppendLine(row.ToString()); // 把整行加入總結果
			}
			return sb.ToString();
		}

		static string PrintStringOptimized(int rows)
		{
			StringBuilder sb = new();

			for (int i = 1; i <= rows; i++)
			{
				// 前面的 '+'
				sb.Append('+', rows - i);

				// 重複的數字
				sb.Append((char)(i + '0'), i);

				// 換行
				sb.AppendLine();
			}

			return sb.ToString();
		}

	}
}
