using System.Collections;

namespace _00._000Hashtable
{
	//出現頻率統計 - 練習 Hashtable 概念
	//題目內容： 給定一個字串，計算其中每個字元出現的次數，並依序輸出。
	//練習重點： 運用 Dictionary<char, int>，如果 Key 不存在則 Add，存在則 Value++。
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}

		public void Example()
		{
			// 建立 Hashtable
			Hashtable hashtable = new Hashtable();
			// 添加鍵值對
			hashtable.Add("apple", 1);
			hashtable.Add("banana", 2);
			hashtable.Add("orange", 3);
			// 訪問值
			int appleCount = (int)hashtable["apple"];
			Console.WriteLine($"Apple count: {appleCount}");
			// 檢查鍵是否存在
			if (hashtable.ContainsKey("banana"))
			{
				Console.WriteLine("Banana exists in the hashtable.");
			}
			// 刪除鍵值對
			hashtable.Remove("orange");
			// 遍歷 Hashtable
			foreach (DictionaryEntry entry in hashtable)
			{
				Console.WriteLine($"{entry.Key}: {entry.Value}");
			}
		}
	}
}
