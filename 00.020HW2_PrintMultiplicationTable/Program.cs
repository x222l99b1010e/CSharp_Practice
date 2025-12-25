using System.Text;

namespace _00._020HW2_PrintMultiplicationTable
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//PrintMultiplicationTable(2, 6);

			string finalResult = CreateMultiplicationTable(3, 7);
			//Console.WriteLine(finalResult);

			//Print99Table(9, 9);

			var lines = CreateMultiplicationTableLines(3, 7);
			//PrintLines(lines);
			foreach (var line in lines)
			{
				Console.WriteLine(line);
			}
		}
		//你只能測：「整坨字串是否一模一樣」
		//但實務上，我們更常測：
		//第 1 行對不對
		//第 3 行內容是否正確
		//行數是否正確
		//👉 字串太粗顆粒
		static string CreateMultiplicationTable(int start, int end)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = start; i <= end; i++)
			{
				for (int j = 1; j <= 9; j++)
				{
					string result = $"{i} * {j} = {i * j}  ";
					sb.Append(result);
					if (j == 9) sb.Append(Environment.NewLine);//換行
															   //sb.AppendLine();//可讀性更好（非必要）
															   //if (j == 9) Console.WriteLine();//這個作法錯誤!!!!!!!!!!主控台換行（與 sb 無關）
															   //如果這邊直接Console.WriteLine()換行 
															   //Console.WriteLine() 不是寫進 StringBuilder
															   //而是「直接輸出到主控台」
															   //上面的迴圈行為只是單純加入sb.Append不會真的在主控台印出來
															   //因此用Console.WriteLine()會在主控台輸出先看到一堆空行
															   //接著才輸出迴圈結果
				}
			}
			return sb.ToString();
		}

		static void Print99Table(int a, int b)
		{
			for (int i = 1; i <= a; i++)
			{
				for (int j = 1; j <= b; j++)
					Console.Write($"{i} * {j} = {i * j}  ");
				Console.WriteLine();//換行
			}
		}

		static List<string> CreateMultiplicationTableLines(int start, int end)
		{
			var lines = new List<string>();

			for (int i = start; i <= end; i++)
			{
				for (int j = 1; j <= 9; j++)
				{
					lines.Add($"{i} * {j} = {i * j}");
				}
			}

			return lines;
		}

	}
}
