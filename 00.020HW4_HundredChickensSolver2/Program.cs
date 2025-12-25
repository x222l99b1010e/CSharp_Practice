namespace _00._020HW4_HundredChickensSolver2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ChickenSolver solver = new ChickenSolver();
			solver.SolveOptimized();

			Console.WriteLine("\n按任意鍵結束...");
			Console.ReadKey();
		}
	}

	public class ChickenSolver
	{
		public void SolveOptimized()
		{
			int loopCount = 0;
			bool found = false;

			Console.WriteLine("【百元買百雞 數學最佳化解法】");
			Console.WriteLine("公式推導：7x + 4y = 100");
			Console.WriteLine("-----------------------------------------");

			// 根據推導 x (公雞) 的範圍只需要跑 1 到 13
			for (int cock = 1; cock <= 13; cock++)
			{
				loopCount++;

				// 判斷 (100 - 7 * cock) 是否能被 4 整除
				int remainder = 100 - (7 * cock);

				if (remainder > 0 && remainder % 4 == 0)
				{
					int hen = remainder / 4;
					int chicken = 100 - cock - hen;

					// 檢查 z 是否也大於 0 (雖然由推導可知一定會大於 0)
					if (chicken > 0)
					{
						Console.WriteLine($"組合方案: 公雞: {cock,2}, 母雞: {hen,2}, 小雞: {chicken,2}");
						found = true;
					}
				}
			}

			if (!found) Console.WriteLine("找不到符合條件的組合。");

			Console.WriteLine("-----------------------------------------");
			Console.WriteLine($"總共執行的迴圈次數：{loopCount} 次");
		}
	}
}
