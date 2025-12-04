using System;
using System.Text.Unicode;

namespace _00._000練習題目
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//整體目標
			//對字串 a（或 b）去掉所有空白字元，然後把剩下的每個字元轉成小寫，最後把結果重新組成一個新的 string（放到 sa / sb）。
			Console.WriteLine(IsAnagram("aaa", "bbb"));

			//單元測試（你可以放在 Main 或單元測試框架裡）
			//以下是六組測試案例，涵蓋：
			//基本 A–Z
			//句子（含空白）
			//不同大小寫
			//中文
			//Emoji（注意：C# 的 char 無法完整處理 surrogate pair 的 emoji → 會算兩個 char，但演算法仍安全）
			//非 anagram 情境
			Console.WriteLine(IsAnagram1("listen", "silent")); // true 
			Console.WriteLine(IsAnagram1("A gentleman", "Elegant man")); // true
			Console.WriteLine(IsAnagram1("Dormitory", "Dirty room")); // true
			Console.WriteLine(IsAnagram1("中文測試", "試測文中")); // true
			Console.WriteLine(IsAnagram1("😀😃😄", "😄😀😃")); // true（emoji 會被當成 char 計數）
			Console.WriteLine(IsAnagram1("hello", "world")); // false

			//補充：為什麼 Dictionary 是最安全的？
			//int[256] 版本只能安全處理 0–255 的 ASCII 字元。
			//遇到中文、日文、emoji，就會：
			//❌ (byte)c 造成截斷
			//❌ counts[(byte)c] 超出範圍
			//❌ 不同的字元被放到同一個 bucket → 判斷錯誤
			//Dictionary<char, int> 完整支援 UTF - 16 單一 char（0–65535）
			//C# 的 char 是 16-bit，可支援 Unicode BMP（大部分常用字元）
		}

		//逐步說明（從左到右）
		//a.Where(c => !char.IsWhiteSpace(c))
		//Where 是 LINQ 的篩選方法（必須 using System.Linq;）。
		//它把 a 當作可枚舉的字元序列來處理（string 本身可以被當成 IEnumerable<char>）。
		//c => !char.IsWhiteSpace(c) 是一個 lambda（匿名函數），意思是「對每個字元 c，當 c 不是空白字元時才保留」。
		//char.IsWhiteSpace(c) 會檢查 c 是否為空白（包括空格、換行、tab 等）。
		//結果：得到一個 IEnumerable<char>，只包含非空白字元。
		//.Select(char.ToLower)
		//Select 也是 LINQ 方法，用來將序列中的每個元素映射（transform）。
		//char.ToLower 這裡傳入 Select，等於對每個字元呼叫 char.ToLower(c)，把字元轉成小寫。
		//結果：仍是 IEnumerable<char>，但每個字元都變小寫了。
		//.ToArray()
		//ToArray() 會把 IEnumerable<char> 轉成 char[]（字元陣列）。
		//所以答案：不是把字串放進陣列（字串本身已是字元序列），而是把剛篩選 & 映射出來的序列「複製」成一個 char[] 陣列，方便下一步使用。
		//new string (...)
		//new string (char[]) 建構子會把 char[] 轉回 string。
		//所以整個連串方法的輸出就是一個新的字串，內容是原來去掉空白並轉小寫後的結果。

		public static bool IsAnagram(string a, string b)
		{
			if (a == null || b == null) return false;
			string sa = new string(a.Where(c => !char.IsWhiteSpace(c)).Select(char.ToLower).ToArray());
			string sb = new string(b.Where(c => !char.IsWhiteSpace(c)).Select(char.ToLower).ToArray());
			if (sa.Length != sb.Length) return false;

			//這段在做什麼（高階概念）
			//這在用「計數」的方法判斷兩個字串是不是 anagram（字母相同、順序不同但頻率相同）：
			//counts 是一個整數陣列，用來記錄每個字元出現的次數（index 對應某個字元）。
			//第一個 foreach：把 sa（已去空白、轉小寫的字串）裡每個字元的計數加 1。
			//第二個 foreach：把 sb 裡每個字元的計數減 1；如果任何一個字元減到小於 0，代表 sb 含有比 sa 更多該字元->不是 anagram，立即回傳 false。
			//如果第二個迴圈全部跑完都沒遇到負數，代表兩邊字元頻率一一對上，最後回傳 true（是 anagram）。
			//這個方法的好處：時間複雜度 O(n)（只讀兩次字串），空間複雜度 O(k)（k = 字元表大小），比把字元排序然後比較更快（排序是 O(n log n)）。
			//每行細節說明
			//var counts = new int[256];
			//建一個長度 256 的整數陣列（初始值都是 0）。作者預期字元範圍在 0–255（也就是 ASCII 或 extended ASCII）。
			//foreach (var c in sa) counts[(byte)c]++;
			//對 sa 的每個 char c，先把它強制轉型成 byte（(byte)c），再把 counts 相對應索引的值加 1。
			//foreach (var c in sb) { if (--counts[(byte)c] < 0) return false; }
			//對 sb 的每個字元，先把該索引的計數減 1（--counts[...]），若結果小於 0，表示 sb 含有一個 sa 沒有或數量比 sa 多的字元，立刻回傳 false。
			//return true;
			//若都沒問題，兩字串的字元頻率一致 → 回傳 true。
			var counts = new int[256];
			foreach (var c in sa) counts[(byte)c]++;
			foreach (var c in sb)
			{
				if (--counts[(byte)c] < 0) return false;
			}
			return true;
		}

		//更安全的替代做法
		//用 Dictionary<char, int>（支援所有 char，適合 Unicode BMP）
		//優點：不需要假設字元範圍，能正確處理中文字、標點等 BMP（基本多語平面）內的字元。
		public static bool IsAnagram1(string a, string b)
		{
			// 1. null 檢查
			if (a == null || b == null) return false;

			// 2. 去掉空白 + 統一小寫（使用 Invariant 避免語系差異）
			string sa = new string(
				a.Where(c => !char.IsWhiteSpace(c))
				 .Select(char.ToLowerInvariant)
				 .ToArray()
			);

			string sb = new string(
				b.Where(c => !char.IsWhiteSpace(c))
				 .Select(char.ToLowerInvariant)
				 .ToArray()
			);

			// 3. 提前剪枝：長度不同 → 不可能是 anagram
			if (sa.Length != sb.Length) return false;

			// 4. 計數（支援 Unicode BMP）
			var counts = new Dictionary<char, int>();

			// sa → 加計數
			foreach (var c in sa)
			{
				if (counts.ContainsKey(c))
					counts[c]++;
				else
					counts[c] = 1;
			}

			// sb → 減計數，如遇到不夠就直接 false
			foreach (var c in sb)
			{
				if (!counts.TryGetValue(c, out var cnt) || cnt == 0)
					return false;

				counts[c] = cnt - 1;
			}

			// 5. 走到這裡表示所有字元計數都平衡 → 是 anagram
			return true;
		}


	}
}
