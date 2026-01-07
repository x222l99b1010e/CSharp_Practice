using System;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

namespace _00._000test0
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Test.Execute("I, Jimmy, saw a saw saw a saw");
			Console.ReadLine();
		}
	}
	public class Test
		{
		public static void Execute(string stInp)
		{
			if (stInp == null)
				return;
			//string[] word = stInp.Replace(",", " ").Replace(".", " ").Split(new char[] { ' ' });

			// 直接傳入單個字元，不需 new char[]
			string[] words = stInp.Replace(",", " ").Replace(".", " ").Split(' ', StringSplitOptions.RemoveEmptyEntries);

			//ArrayList arrWord = new ArrayList();
			List<string> arrWord = new List<string>();

			//Hashtable hm = new Hashtable();
			HashSet<string> hm = new HashSet<string>();

			Dictionary<string, int> wordCounts = new Dictionary<string, int>();

			foreach (string st in words)
			{
				if (st != null && st.Length > 0)//這邊需要判斷st.Length > 0
				{
					arrWord.Insert(0, st);
					//Add(value)：把東西放在最後面（排隊）。
					//Insert(index, value)：把東西擠進指定位置（插隊）。

					//這是一個很聰明的技巧，用來達成 * *「句子倒置」**。 假設輸入是 "I", "saw", "a"：
					//插入 "I" 到位置 0：["I"]
					//插入 "saw" 到位置 0（把 I 往後擠）：["saw", "I"]
					//插入 "a" 到位置 0（把大家都往後擠）：["a", "saw", "I"] 結果： 順序自然就反過來了。

					//統計次數
					if (wordCounts.ContainsKey(st))
					{
						wordCounts[st]++; // 若已存在，次數 + 1
					}
					else
					{
						wordCounts.Add(st, 1); // 若不存在，初始次數為 1
					}
					//arrWord.Add(st);


					//if (!hm.ContainsKey(st))
					//{
					//	hm.Add(st, st);
					//}
					// HashSet 的 Add 會自動檢查，若重複則回傳 false，不會報錯
					hm.Add(st);
				}

			}
			//arrWord.Reverse();

			Console.WriteLine("Reversed string=");
			foreach (string st in arrWord)
			{
				Console.Write(st + " ");
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Word Counts=");
			foreach (var pair in wordCounts)
			{
				Console.WriteLine($"{pair.Key}: {pair.Value}");
			}
			Console.WriteLine();
			Console.WriteLine("All Words=");
			//foreach (Object key in hm.Keys)
			//{
			//	Console.Write(key + " ");
			//}
			Console.WriteLine(string.Join(" ", hm));
		}
	}
}
