//題目二：Factors of 3 and 5（3 和 5 的因子）
//定義「完美數（ideal number）」為：只含有質因數 3 和 5 的正整數，也就是可以寫成(3^x) * (5^y)，其中x, y 為非負整數。

//給定兩個整數 low 和 high，請寫一個函式 getIdealNums(long low, long high)，
//回傳在區間 [low, high]（含端點）之中，有多少個完美數。

//限制條件：1<=low<=high<=2*10^9 。
//測試=>[200,405]
namespace Factors_of_3_and_5
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(getIdealNums(200,405));
		}

		public static long getIdealNums(long low, long high)
		{
			long count = 0;

			// 列舉所有 3^x
			for (long pow3 = 1; pow3 <= high; pow3 *= 3)
			{
				// 列舉所有 5^y
				for (long pow5 = 1; pow3 * pow5 <= high; pow5 *= 5)
				{
					long idealNum = pow3 * pow5;

					// 檢查是否在 [low, high] 範圍內
					if (idealNum >= low && idealNum <= high)
					{
						count++;
					}
				}
			}

			return count;
		}
	}
}
