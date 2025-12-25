namespace _00._020HW4_HundredChickensSolver
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ChickenSolver solver = new ChickenSolver();
			solver.Solve();

			Console.WriteLine("\n按任意鍵結束...");
			Console.ReadKey();
		}
	}

	public class ChickenSolver
	{
		public void Solve()
		{
			int loopCount = 0;
			int totalMoney = 100;
			int totalCount = 100;
			bool found = false;

			Console.WriteLine("【百元買百雞 最佳解法】");
			Console.WriteLine("-----------------------------------------");

			// 優化 1: 公雞最多只可能到 19 隻 (5*19 = 95, 剩下5元不夠分配給母雞和小雞)
			for (int cock = 1; cock <= 19; cock++)
			{
				// 優化 2: 母雞最多只可能到 31 隻
				for (int hen = 1; hen <= 31; hen++)
				{
					loopCount++; // 紀錄迴圈跑了幾次

					// 優化 3: 小雞數量直接用減法算出
					int chicken = totalCount - cock - hen;

					// 檢查條件：
					// 1. 小雞數量必須大於 0
					// 2. 小雞數量必須是 3 的倍數 (因為 3 隻 1 元)
					// 3. 總金額必須剛好 100 元
					if (chicken > 0 && chicken % 3 == 0)
					{
						int cost = (cock * 5) + (hen * 3) + (chicken / 3);

						if (cost == totalMoney)
						{
							Console.WriteLine($"組合方案: 公雞(Cock): {cock,2} 隻, 母雞(Hen): {hen,2} 隻, 小雞(Chicken): {chicken,2} 隻");
							found = true;
						}
					}
				}
			}

			if (!found)
			{
				Console.WriteLine("找不到符合條件的組合。");
			}

			Console.WriteLine("-----------------------------------------");
			Console.WriteLine($"總共執行的迴圈次數：{loopCount} 次");
		}
	}
}
