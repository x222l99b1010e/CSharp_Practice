using System;
using System.Diagnostics;
using System.Reflection;

namespace _00._000TwoSum
{
//1. 兩數之和(Two Sum) - 練習 Dictionary
//題目內容： 給定一個整數陣列 nums 和一個目標值 target，請回傳該陣列中和為目標值的那兩個整數的 索引(index)。
//LeetCode 參考： #1
//練習重點： 使用 Dictionary 來儲存看過的數字與索引，將搜尋時間從 $O(n^2)$ 降到 $O(n)$。
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}

		public int[] TwoSum(int[] nums, int target)
		{
			Dictionary<int, int> numDict = new Dictionary<int, int>();
			for (int i = 0; i < nums.Length; i++)
			{
				int complement = target - nums[i];
				if (numDict.ContainsKey(complement))
				{
					return new int[] { numDict[complement], i };
				}
				if (!numDict.ContainsKey(nums[i]))
				{
					numDict.Add(nums[i], i);
				}
			}
			return new int[] { -1, -1 }; // 如果沒有找到解，返回 [-1, -1]
		}
	}
}
