namespace _00._020作業2_模擬簡單計算機
{
	internal class Program
	{
		//模擬簡單計算機：
		//建立一個 Calculator 類別，提供以下方法：
		//Add(int a, int b)：回傳兩數相加結果。
		//Subtract(int a, int b)：回傳兩數相減結果。
		//Multiply(int a, int b)：回傳兩數相乘結果。
		//Divide(int a, int b)：回傳兩數相除結果(避免除以零錯誤)。
		static void Main(string[] args)
		{
			Calculator c = new Calculator();
			int result = c.Add(3, 5);
			Console.WriteLine(result);
			result = c.Sub(3, 5);
			Console.WriteLine(result);
			result = c.Mul(3, 5);
			Console.WriteLine(result);
			result = c.Div(3, 0);
			Console.WriteLine(result);

			//=========================================================
			//優點：語意清楚（成功/失敗由 bool 表示），
			//沒有例外處理的成本，很常見於 .NET（參考 int.TryParse）。
			//缺點：呼叫端需要 out 變數，API 較多一個參數，不過可讀性很好。
			if (c.TryDiv(3, 0, out int res))
				Console.WriteLine(res);
			else
				Console.WriteLine("除法失敗：除數為 0");
			//=========================================================
			//優點：語意強烈，錯誤不會被悄悄忽略，適合責任應該由呼叫端顯式處理的情況。
			//缺點：例外的建立 / 拋出成本比普通返回值高，
			//如果在「正常流程」頻繁發生會有性能影響（但對大多數應用這不是問題）。
			try
			{
				int r = c.Div1(3, 0);
				Console.WriteLine(r);
			}
			catch (DivideByZeroException ex)
			{
				Console.WriteLine($"錯誤：{ex.Message}");
			}
			//=========================================================
			//優點：簡潔、語意明確（null = 失敗），在 C# 中用得也不少。
			//缺點：須處理 nullable，且對某些 API 設計來說不夠顯式。
			int? q = c.DivNullable(3, 0);
			if (q.HasValue)
				Console.WriteLine(q.Value);
			else
				Console.WriteLine("除法失敗（除數為 0）");



		}
	}

	//=========================================================
	public class Calculator
	{
		public int Add(int a, int b) { return a + b; }
		public int Sub(int a, int b) { return a - b; }
		public int Mul(int a, int b) { return a * b; }
		public int Div(int a, int b)
		{
			if (b == 0)
			{
				Console.WriteLine("除數不能為 0。");
				return 0;  // 回傳一個你可以接受的預設值
			}
			return a / b;
		}
		//=========================================================
		public bool TryDiv(int a, int b, out int result)
		{
			if (b == 0)
			{
				result = 0;
				return false;
			}
			result = a / b;
			return true;
		}
		//=========================================================
		public int Div1(int a, int b)
		{
			if (b == 0)
				throw new DivideByZeroException("除數不能為 0");
			return a / b;
		}
		//另一個選項：回傳可為 null 的 int?
		public int? DivNullable(int a, int b)
		{
			if (b == 0) return null;
			return a / b;
		}
	}
}
