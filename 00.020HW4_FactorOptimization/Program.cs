namespace _00._020HW4_FactorOptimization
{
	internal class Program
	{
		//使用 while , 在畫面顯示所有可以整除 300 的整數, 例如: 1, 2, 3, 4, 5, 6, 10, ...., 300
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			int target =78125;
			Console.WriteLine($"{target}的因數有");
			Console.WriteLine("====================");

			// 呼叫方法
			List<int> finalResult = GetFactor(target);
			// 顯示結果
			foreach (int f in finalResult)
			{
				Console.WriteLine(f);
			}
			// 在 foreach 之後
			Console.WriteLine($"總共有 {finalResult.Count} 個因數。");
			Console.WriteLine();
		}
		static List<int> GetFactor(int number)
		{
			List<int> factorList = new List<int>(); // 使用 List 處理動態長度
			int i = 1;
			int limit = (int)Math.Sqrt(number);
			while (i <= limit)
			{
				if (number % i == 0)
				{
					factorList.Add(i);
					//將另外半邊因數加進來
					int j = number / i;					
					if (number >= j && i != j)	factorList.Add(j);
				}
				i++;
			}
			factorList.Sort();
			return factorList;
		}
	}
}
