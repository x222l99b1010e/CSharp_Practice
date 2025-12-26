namespace _00._020HW4_OddSeriesAccumulator250
{
	internal class Program
	{
		//1 + 3 + 5 + 7 +...., 請問加到什麼值時, 會剛好超過 250, 顯示值以及總和各是多少
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			int lastOdd = GetOddSumExceedingLimit(250, out int totalSum);
			Console.WriteLine($"最後奇數：{lastOdd}");
			Console.WriteLine($"總和：{totalSum}");
			//====================================================
			var result = GetOddSumExceedingLimit2(250);
			Console.WriteLine($"最後奇數：{result.LastOdd}");
			Console.WriteLine($"總和：{result.Sum}");


		}
		public static int GetOddSumExceedingLimit(int limit, out int sum)
		{
			//奇數數列的性質：
			//第 n 個奇數 = 2n − 1
			//前 n 個奇數總和 = n^2
			int n = (int)Math.Sqrt(limit) + 1;//超過limit的是第 n+1 個數字;
			int result = n * 2 - 1;//第一次超過250的奇數 是 什麼數字?;
			sum = n * n;//總和 是 n 的平方
			return result;
		}

		public static (int LastOdd, int Sum) GetOddSumExceedingLimit2(int limit)
		{
			int n = (int)Math.Sqrt(limit) + 1;
			return (n * 2 - 1, n * n);
		}

	}
}
