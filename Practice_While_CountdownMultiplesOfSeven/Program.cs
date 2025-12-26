namespace Practice_While_CountdownMultiplesOfSeven
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			CountdownNums(100, 7,1);
		}

		/// <summary>
		/// 在指定範圍內，由大到小搜尋並顯示所有特定數字的倍數。
		/// </summary>
		/// <param name="counter">搜尋的起始上限（從哪個數字開始倒數）。</param>
		/// <param name="ctdnNum">要尋找的倍數基準值（例如：輸入 7 代表尋找 7 的倍數）。</param>
		/// <param name="min">搜尋的終止下限（倒數到哪個數字為止）。</param>
		/// <remarks>
		/// 注意：ctdnNum 必須大於 0，否則會導致計算錯誤。
		/// </remarks>
		public static void CountdownNums(int counter, int ctdnNum, int min)
		{
			if (ctdnNum <= 0) return;
			// 1. 初始化起點變數
			Console.WriteLine($"開始搜尋 {counter} ~ 1 之間 {ctdnNum} 的倍數：");
			Console.WriteLine("-----------------------------------");
			// 【優化點 1】：先將 counter 修正到「第一個可能的倍數」
			// 100 % 7 = 2，所以 100 - 2 = 98 是起點
			counter = counter - (counter % ctdnNum);

			// 2. 使用 while 迴圈，條件是當 counter 大於等於 1 時持續執行
			while (counter >= min)
			{
				// 3. 判斷是否為 ctdnNum 的倍數 (除以 ctdnNum 餘數為 0)
				if (counter % ctdnNum == 0)
				{
					Console.WriteLine($"找到倍數：{counter}");
				}
				counter -= ctdnNum;
			}
			Console.WriteLine("-----------------------------------");
			Console.WriteLine("倒數結束！");
			// 防止視窗直接關閉
			Console.ReadKey();
		}
	}
}
