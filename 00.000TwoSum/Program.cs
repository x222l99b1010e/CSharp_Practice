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
			//Console.WriteLine("Hello, World!");
			int[] num2 = { 1, 2, 3, 5, 8, 13, 21, 34 };
			int target = 4;
			int[] indices = TwoSum(num2, target);

			if (indices[0] != -1)
			{
				// 1. 印出回傳的「索引」
				Console.WriteLine($"索引結果: [{string.Join(", ", indices)}]");

				// 2. 透過索引印出對應的「Key」(也就是陣列裡的數值)
				int key1 = num2[indices[0]];
				int key2 = num2[indices[1]];

				Console.WriteLine($"這組索引對應的 Key (數值) 分別是: {key1} 和 {key2}");
				Console.WriteLine($"{key1} + {key2} = {target}");
			}
			else
			{
				Console.WriteLine("沒有找到符合條件的組合。");
			}

			int[] num1 = TwoSum(num2, 4);
			Console.Write("[");
			for (int i = 0; i < num1.Length; i++)
			{
				Console.Write(num1[i] + (i == num1.Length - 1 ? "" : ", "));
			}
			Console.WriteLine("]");

		}

		public static int[] TwoSum(int[] nums, int target)
		{
			// 使用 Dictionary 來儲存數字與其索引
			// 1. 宣告：Dictionary<Key型別, Value型別>
			//Key: 數字 Value: 索引
			//建立 Dictionary
			Dictionary<int, int> numDict = new Dictionary<int, int>();			

			//跑回圈
			for (int i = 0; i < nums.Length; i++)
			{
				//計算補數
				//補數 = 目標值 - 當前數字
				//檢查補數是否存在於 Dictionary 中
				//如果存在，回傳補數的索引和當前索引
				//如果不存在，將當前數字和索引加入 Dictionary
				//繼續下一個數字
				//如果迴圈結束後仍未找到解，回傳 [-1, -1]
				int complement = target - nums[i];
				//nums 是一個陣列（Array），而 i 是當前迴圈的計數器。
				if (numDict.ContainsKey(complement))
				{
					// 2. 加入資料：numDict.Add(Key, Value)
					// 這裡我們把「數字」放前面當 Key，「索引」放後面當 Value
					//numDict.Add(nums[i], i);
					return new int[] { numDict[complement], i };

					// 3. 查詢：numDict[Key]
					// 這裡我們輸入「補數(數字)」，它會吐回「索引」
					//int index = numDict[complement];
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
