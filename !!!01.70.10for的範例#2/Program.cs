using System.Text;
namespace _01._70._10for的範例_2
{
	internal class Program
	{
		//#
		// #
		//  #
		//   #
		//	#
		//   #
		//  #
		// #
		//#
		//寫一支函數, 傳入整數 rows, 假設傳入 5, 則表示顯示上述結果
		//函數傳回字串, 再在 Main()裡呈現它
		//限制：
		//rows 值會介於[1, 10], 不必在函數裡驗證
		static void Main(string[] args)
		{
			PrintPattern(5);
			PrintPattern2(6);
			string result = PrintPattern3(7);
			Console.WriteLine(result);

		}

		static void PrintPattern(int rows)
		{
			//string output = "";
			for (int i = 1; i <= rows; i++)//上升段
			{				
				string row =new string(' ', i)+'#';
				Console.WriteLine(row);
			}
			for (int i = rows-1; i > 0; i--)//下降段
			{
				string row = new string(' ', i)+'#';
				Console.WriteLine(row);
			}
			
		}

		static void PrintPattern2(int rows)
		{
			for (int t = 1; t <= 2 * rows - 1; t++)
			{
				int indent = (t <= rows) ? t : 2 * rows - t;//拆分出上行跟下行段 t and 2*rows-t
				// ident 類似索引出第幾層 # 
				//t=1,2,3,4,5,6,7,8,... 2*row-1
				//if t >= rows (t = 6,7,8,9...2*rows-1) => indent = 9(2*5-1) - 6(t=6)...9-7(t=7)...
				string row = new string(' ', indent) + '#';
				Console.WriteLine(row);
			}
		}

		static string PrintPattern3(int rows)
		{
			var sb = new StringBuilder(); //System.Text StringBuilder()
			int total = 2 * rows - 1; //總共2*rows -1 層
			for (int t = 1; t <= total; t++)
			{
				int indent = (t <= rows) ? t : 2 * rows - t;//判斷上行還是下行
				sb.Append(' ', indent);   // 連續添加空格 後面t>rows所以開始下行(因為2 * rows)-t，t越來越大
				sb.Append('#');
				if (t < total) sb.AppendLine(); // 避免最後多一個換行(換行用)
			}
			return sb.ToString();
		}
	}
}
