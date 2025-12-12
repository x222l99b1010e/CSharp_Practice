namespace idealNum
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int result = (int)getIdealNums(205, 405);
			Console.WriteLine(result);
		}

		public static long getIdealNums(long low, long high)
		{
			long count = 0;
			//列舉出3^x
			//從3^1次方開始直到high
			for (long pow3 = 1; pow3 <= high; pow3 *= 3)
			{
				//列舉出5^x
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
