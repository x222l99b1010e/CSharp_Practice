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
	}
}
