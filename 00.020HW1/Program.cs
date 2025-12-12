namespace _00._020HW1
{
	internal class Program
	{
		//生成反向的靠左, 靠右, 置中三角形(共六種), 每個圖形五列
		static void Main(string[] args)
		{
			//Console.WriteLine(MakeLeftStar(5));
			//以下相同作法不包函式 靠左
			int rows = 5;
			for (int i = 0; i <= rows; i++)
			{
				string row = new string('a', rows-i);
				//Console.WriteLine(row);
			}

			//Console.WriteLine(MakeRightStar(5));
			Console.WriteLine(MakeMediumStarReverse(5));
			Console.WriteLine(MakeMediumStar1(5));

		}
		static string MakeStar(int rows)//效率較好的方式
		{
			var sb = new System.Text.StringBuilder();
			for (int i = 0; i < rows; i++)
			{
				sb.AppendLine(new string('*', rows - i));//將結果加入stringbuilder
			}
			return sb.ToString();
		}

		static string MakeLeftStar(int rows)
		{
			string row = "";
			for (int i = 0; i < rows; i++)
			{
				row += new string('*',rows-i)+"\n";//要將結果累加
			}
			return row;
		}

		static string MakeRightStar(int rows)
		{
			string row = "";
			for (int i = 0;i<=rows;i++)
			{
				row += new string(' ',i) + new string('*', rows-i) + "\n";
			}
			return row;
		}

		static string MakeMediumStarReverse(int rows)
		{
			string row = "";
			for (int i = 0; i < rows; i++)
			{
				row += new string(' ', i) + new string('*', 2 * (rows - i) - 1) + "\n";
			}
			return row;
		}

		static string MakeMediumStar1(int rows)
		{
			string row = "";
			for (int i = 0; i < rows; i++)//i=>第i層  rows=>有rows層
			{ 
				row += new string(' ',i) + new string('*',2*(rows-i)-1) + new string(' ',i)+ "\n";
				// 假設rows= 5 =>第一層 兩邊沒有 i =>[2*(5-1)-1]
				//=> 其實不需要後面的new string(' ',i)，  因為只要前面有空格撐開  再換行即可
			}
			return row;
		}
	}
}
