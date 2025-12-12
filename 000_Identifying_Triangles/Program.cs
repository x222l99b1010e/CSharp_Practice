//題目三：Identifying Triangles（判別三角形）
//工廠在生產線上組裝三角形玩具，每個玩具有三個邊長 a、b、c。
//一個三角形是「有效」的條件為：兩條較短邊的長度總和要大於最長邊。

//例子：假設有 n=4個三角形，三邊長列表為：triangleToy = ["2 1", "3 3 3", "3 4 5", "1 1 3"]
//輸出：["Isosceles", "Equilateral", "None of these", "None of these"]
//解釋：
//第一個三角形 (2, 1, 2)：有 2 個邊相等 → Isosceles
//第二個三角形 (3, 3, 3)：3 個邊都相等 → Equilateral
//第三個三角形 (3, 4, 5)：有效三角形（3 + 4 > 5），但邊都不相等 → None of these
//第四個三角形 (1, 1, 3)：無效（1 + 1 ≯ 3），兩條長度為 1 的邊無法與 3 連接 → None of these


//需要辨識以下兩種特殊的有效三角形：
//若有兩邊長度相等，為 Isosceles（等腰）。
//若三邊長度皆相等，為 Equilateral（等邊）。
//若不是有效三角形，或雖然有效但不屬於以上兩種形式，則輸出 "None of these"。
//給定一個字串陣列 triangleToy，每個元素為 "a b c" 形式的三邊長，請實作函式
//List<string> triangleType(List<string> triangleToy)，
//依序回傳每個三角形的類型字串。

//限制條件：
//1≤n≤5000（triangleToy 長度）。
//1≤a, b, c≤2000。

//解題步驟
//逐個讀取三角形的三邊長

//檢查是否為有效三角形（兩短邊之和 > 最長邊）

//若有效，判斷類型：

//如果 a=b=c
//a=b=c → Equilateral
//如果有任意兩邊相等 → Isosceles
//其他 → None of these
//若無效 → None of these
namespace _000_Identifying_Triangles
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}

		public static List<string> triangleType(List<string> triangleToy)
		{
			List<string> result = new List<string>();

			foreach (string triangle in triangleToy)
			{
				string[] parts = triangle.Split(' ');
				long a = long.Parse(parts[0]);
				long b = long.Parse(parts[1]);
				long c = long.Parse(parts[2]);

				// 找出最長邊
				long max = Math.Max(a, Math.Max(b, c));
				long sum = a + b + c - max;  // 另外兩邊的和

				// 檢查是否為有效三角形
				if (sum > max)
				{
					// 是有效三角形，判斷類型
					if (a == b && b == c)
					{
						// 3 個邊都相等
						result.Add("Equilateral");
					}
					else if (a == b || b == c || a == c)
					{
						// 有 2 個邊相等
						result.Add("Isosceles");
					}
					else
					{
						// 都不相等
						result.Add("None of these");
					}
				}
				else
				{
					// 無效三角形
					result.Add("None of these");
				}
			}

			return result;
		}
		//執行邏輯
		//分割字串：用空格將邊長分開，轉成 long 類型

		//找最長邊：max = Math.Max(a, Math.Max(b, c))

		//計算另外兩邊的和：sum = a + b + c - max

		//判斷有效性：

		//若 sum > max → 有效三角形

		//否則 → 無效，輸出 "None of these"

		//分類有效三角形：

		//a == b == c → Equilateral

		//任意兩邊相等 → Isosceles

		//都不相等 → None of these

	}
}
