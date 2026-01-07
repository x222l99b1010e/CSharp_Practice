namespace _00._000RomantoInteger
{
	//羅馬數字轉整數(Roman to Integer) - 練習 Switch-Case
	//題目內容： 將羅馬數字字串（I, V, X, L, C, D, M）轉換為整數。
	//LeetCode 參考： #13
	//練習重點： 使用 switch-case 處理對應數值，並配合 for 迴圈處理特殊規則（如 IV = 4）。
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}

		public int RomanToInt(string s)
		{
			Dictionary<char, int> romanMap = new Dictionary<char, int>
			{
				{'I', 1},
				{'V', 5},
				{'X', 10},
				{'L', 50},
				{'C', 100},
				{'D', 500},
				{'M', 1000}
			};
			int total = 0;
			int prevValue = 0;
			for (int i = s.Length - 1; i >= 0; i--)
			{
				int currentValue = romanMap[s[i]];
				if (currentValue < prevValue)
				{
					total -= currentValue;
				}
				else
				{
					total += currentValue;
				}
				prevValue = currentValue;
			}
			return total;
		}
	}
}
