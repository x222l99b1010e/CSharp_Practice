
namespace _00._000RotateArray
{
	//陣列旋轉(Rotate Array) - 練習流程控制與陣列操作
	//題目內容： 將一個陣列向右旋轉 $k$ 個位置。例如[1, 2, 3] 向右轉 1 位變成[3, 1, 2]。
	//練習重點： 模數運算 % 以及如何處理索引位移，這對邏輯思考很有幫助。
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}

		public void Rotate(int[] nums, int k)
		{
			if (nums == null || nums.Length == 0 || k <= 0)
				return;
			int n = nums.Length;
			k = k % n; // 處理 k 大於陣列長度的情況
			Reverse(nums, 0, n - 1);       // 反轉整個陣列
			Reverse(nums, 0, k - 1);       // 反轉前 k 個元素
			Reverse(nums, k, n - 1);       // 反轉剩餘的元素
		}

		public void Reverse(int[] nums, int start, int end)
		{
			while (start < end)
			{
				// 經典的交換邏輯 (Swap)
				int temp = nums[start];
				nums[start] = nums[end];
				nums[end] = temp;

				// 移動索引
				start++;
				end--;
			}
		}
	}
}
