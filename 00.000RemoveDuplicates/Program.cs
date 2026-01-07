using System.Collections.Generic;

namespace _00._000RemoveDuplicates
{
	//移除重複項(Remove Duplicates) - 練習 ArrayList/List
	//題目內容： 給定一個排序好的陣列，原地移除重複的元素，使每個元素只出現一次，並回傳新長度。
	//LeetCode 參考： #26
	//練習重點： 雙指標技巧，或是使用 List<int> 配合.Contains() 來過濾重複項。
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}

		public int[] RemoveDuplicates(int[] nums)
		{
			if (nums == null || nums.Length == 0)
				return new int[0];
			List<int> uniqueList = new List<int>();
			HashSet<int> seen = new HashSet<int>();
			foreach (int num in nums)
			{
				if (!seen.Contains(num))
				{
					seen.Add(num);
					uniqueList.Add(num);
				}
			}
			return uniqueList.ToArray();
		}
	}
}
