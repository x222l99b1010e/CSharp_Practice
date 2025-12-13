namespace _00._020HW2_BMI_Method
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// 1. 取得使用者輸入
			int height = GetValidatedInt("身高", "公分", 90, 250);
			int weight = GetValidatedInt("體重", "公斤", 35, 150);

			// 2. 單位換算
			double heightM = height / 100.0;

			// 3. 計算 BMI
			double bmi = weight / Math.Pow(heightM, 2);

			// 4. 判斷肥胖呈度
			string category;
			if (bmi >= 35) category = "重度肥胖";
			else if (bmi >= 30) category = "中度肥胖";
			else if (bmi >= 27) category = "輕度肥胖";
			else if (bmi >= 24) category = "過重";
			else category = "體重適中";

			// 5. 輸出結果
			Console.WriteLine($"BMI：{bmi:F2}, {category}");

			//漏了一個工程師會想的問題： 如果明天規則改了（例如新增一級）， 我要改幾行？風險大不大？??????????

			//更進階的做法：用資料結構管理規則
			//可以用陣列或列表存 BMI 範圍與文字：
			var rules = new List<(double min, double max, string label)>
						{
							(35, double.MaxValue, "重度肥胖"),
							(30, 35, "中度肥胖"),
							(27, 30, "輕度肥胖"),
							(24, 27, "過重"),
							(0, 24, "體重適中")
						};
			//只要迭代規則就能找到對應分類：
			string category1 = rules.First(r => bmi >= r.min && bmi < r.max).label;
			//新增 / 修改規則不用改程式流程
			//風險小，易維護
		}
		/// <summary>
		/// 取得驗證值
		/// </summary>
		/// <param name="promptName">要驗證的參數名稱</param>
		/// <param name="unitLabel">要驗證的單位</param>
		/// <param name="maxValue">最大值</param>
		/// <param name="minValue">最小值</param>
		/// <returns></returns>
		public static int GetValidatedInt(string promptName, string unitLabel, int minValue, int maxValue)
		{
			int a;
			while (true)
			{
				Console.Write($"請輸入{promptName}(單位:{unitLabel})：");
				string input = Console.ReadLine()?.Trim() ?? "";

				if (string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine($"{promptName}不可空白，請重新輸入。");
					continue;
				}
				if (!int.TryParse(input, out a) || (a > maxValue || a < minValue))
				{
					Console.WriteLine($"{promptName}必須是介於{minValue}~{maxValue}之正整數，請重新輸入。");
					continue;
				}
				break;
			}
			return a;
		}

		//把肥胖分類邏輯抽成方法，例如：
		//Main 呼叫：string category = GetBmiCategory(bmi);
		public static string GetBmiCategory(double bmi)
		{
			if (bmi >= 35) return "重度肥胖";
			if (bmi >= 30) return "中度肥胖";
			if (bmi >= 27) return "輕度肥胖";
			if (bmi >= 24) return "過重";
			return "體重適中";
		}

	}
}
