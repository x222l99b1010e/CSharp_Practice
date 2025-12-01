namespace _01._70._30計算數值總和
{
	internal class Program
	{
		//- 寫一行程式，算出 1 ~ 5 總和
		//- 寫五行程式，算出 1 ~ 5 總和
		//- 用迴圈算出 1~ 5 總和

		static void Main(string[] args)
		{
			Console.WriteLine(CalculateNum(1,5));
			Console.WriteLine(CalculateNum1(-5,100));
		}
		/// <summary>
		/// 計算開頭到結尾數字之總合
		/// </summary>
		/// <param name="begin">開始數字</param>
		/// <param name="end">結束數字</param>
		static int CalculateNum(int begin, int end)
		{
			int sum = (begin + end) * Math.Abs(end - begin + 1) / 2;
			return sum;
		}
		/// <summary>
		/// 用迴圈算出區間數字總和
		/// </summary>
		/// <param name="begin"></param>
		/// <param name="end"></param>
		/// <returns></returns>

		static int CalculateNum1(int begin, int end)
		{
			int sum = 0; 
			for (int i = begin; i <= end; i++)
			{
				sum += i;
			}
			return sum;
		}
	}
}
