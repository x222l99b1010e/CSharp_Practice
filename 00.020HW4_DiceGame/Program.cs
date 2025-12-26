namespace _00._020HW4_DiceGame
{
	internal class Program
	{
		//撰寫一個 class DiceGame , 內含一個 method Roll
		//每次叫用 Roll(), 它會隨機傳回四顆骰子值(介於[1, 6]), 回傳的 int[] 是長度為4的陣列
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			LuckyNumberGenerator lng = new LuckyNumberGenerator();
			int[] results = lng.GetLuckyNumbers();

			//使用傳統 for 迴圈（推薦用於需要索引時）
			for (int j = 0; j < results.Length; j++)
			{
				// j 是索引 (0, 1, 2)，所以顯示時要 +1 才會變成 (1, 2, 3)
				//Console.WriteLine($"第 {j + 1} 個幸運數字為 {results[j]}");
			}
			//保留 foreach 但手動計數
			int count = 1;
			foreach (int val in lng.GetLuckyNumbers())
			{
				//Console.WriteLine($"第 {count} 個幸運數字為 {val}");
				count++;
			}

			DiceGame rollDice = new DiceGame();
			int[] finalResult = rollDice.Roll(10);
			//記得序列起點為0，從1開始是第二顆骰子
			//並且只會顯示三顆骰子的結果
			//漏掉了第一顆骰子：因為你設定 int i = 1，程式會從索引[1] 開始抓（這是第二顆）。在 C# 中，陣列的起點永遠是 0。
			//數量不對：如果你的陣列長度是 4（索引為 0, 1, 2, 3），這段迴圈只會跑 i = 1, 2, 3，也就是說你只會印出 3 顆骰子的結果。
			int sumUp = 0;
			int allSumUp = finalResult.Sum(); // 這一行直接取代迴圈加總
			for (int i = 0; i < finalResult.Length; i++)
			{
				// 顯示時用 i + 1，人類看起來就是 第1顆、第2顆...
				Console.WriteLine($"第{i + 1}顆骰子結果為{finalResult[i]}");
				sumUp += finalResult[i];
			}
			Console.WriteLine($"總和為{sumUp}");
			Console.WriteLine($"總和為{allSumUp}");
		}
	}
	public class DiceGame 
	{
		// 1. 在類別層級宣告 Random，確保隨機性更穩定
		private Random _rnd = new Random();
		public int[] Roll(int count = 4)//預設四顆骰子
		{
			// 2. 準備一個長度為 4 的陣列
			int[] diceResult = new int[count];
			// 3. 使用 for 迴圈來填充陣列
			for (int i = 0; i < diceResult.Length; i++)
			{
				diceResult[i] = _rnd.Next(1,7);
			}
			return diceResult;
		}
	}

	public class LuckyNumberGenerator
	{
		// 1. 在類別層級宣告 Random，確保隨機性更穩定
		private Random _random = new Random();

		public int[] GetLuckyNumbers()
		{
			// 2. 準備一個長度為 3 的陣列
			int[] luckyNumbers = new int[3];

			// 3. 使用 for 迴圈來填充陣列
			for (int i = 0; i < luckyNumbers.Length; i++)
			{
				// Next(1, 101) 代表產生 1~100 的數字 (不包含 101)
				luckyNumbers[i] = _random.Next(1, 101);
			}

			// 4. 回傳填充好的陣列
			return luckyNumbers;
		}
	}
}
