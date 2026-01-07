using System.Linq;

namespace _00._000PalindromeNumberString
{
	//回文檢查(Palindrome Number/String) - 練習字串與流程控制
	//題目內容： 輸入一個字串或數字，判斷它是否為回文（正著讀、反著讀都一樣）。
	//練習重點： for 迴圈與 if-else 判斷，熟悉字串轉陣列 ToCharArray() 或索引存取。
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}

		public bool IsPalindrome(string s)
		{
			if (s == null)
				return false;
			int left = 0;
			int right = s.Length - 1;
			while (left < right)
			{
				// 移動左指針直到找到字母或數字
				while (left < right && !char.IsLetterOrDigit(s[left]))
				{
					left++;
				}
				// 移動右指針直到找到字母或數字
				while (left < right && !char.IsLetterOrDigit(s[right]))
				{
					right--;
				}
				// 比較忽略大小寫的字符
				if (char.ToLower(s[left]) != char.ToLower(s[right]))
				{
					return false;
				}
				left++;
				right--;
			}
			return true;
		}

		public bool whetherPalindrome(string s)
		{
			if (string.IsNullOrWhiteSpace(s))
				return false;
			//string revS = new string(s.Reverse().ToArray());
			char[] charArray = s.ToCharArray();
			Array.Reverse(charArray);
			string revS = new string(charArray);
			return s.Equals(revS, StringComparison.OrdinalIgnoreCase);
		}

		public bool whetherPalindrome2(string s)
		{
			if (string.IsNullOrWhiteSpace(s)) return false;
			//string lowerS = s.ToLower();
			// SequenceEqual 可以直接比對兩個序列是否相等
			return s.Reverse().SequenceEqual(s.ToCharArray(), EqualityComparer<char>.Default);
			//return s.Reverse().SequenceEqual(s, StringComparer.OrdinalIgnoreCase);
		}
	}
}
