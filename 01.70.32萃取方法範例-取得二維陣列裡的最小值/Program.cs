using System.Data.Common;

namespace _01._70._32萃取方法範例_取得二維陣列裡的最小值
{
	internal class Program
	{
		//「萃取方法」（Extract Method）是什麼？
		//「萃取方法」（或稱 Extract Method、Method Extraction、函式抽取）是一種常見的程式重構手法，
		//意思就是把一段有明確責任或功能的程式碼片段，從原本的函式/方法中拿出來，封裝成一個新的獨立方法。
		//像範例裡把「比較並選出較小的數」抽成 GetMin 就是萃取方法的實例。

		//萃取方法的好處：
		//可讀性提高：主流程（例如迴圈）變得更清楚，看起來像是在說「做什麼」，而不是被細節淹沒。
		//重用：若相同邏輯會在多處使用，放成一支函式就能避免重複程式碼（DRY）。
		//易於測試：小而單一職責的函式更容易寫單元測試。
		//封裝與維護：未來要修改該邏輯只要改一處即可。
		//語意清楚：方法名可以表達意圖，例如 GetMin、CalculateTax、ParseInput 等，讓讀程式的人快速理解目的。

		//可能的壞處（或需要注意的地方）：
		//如果過度抽取、產生很多小函式，會讓閱讀跳轉頻繁（在某些情況反而降低可讀性）。
		//若新函式需要很多參數，代表責任可能沒有被很好地拆分（可以考慮用物件封裝）。
		static void Main(string[] args)
		{
			//int[,] 是 矩形（rectangular）二維陣列，每一列的欄數都相同。
			//若你需要每一列的長度不同，可以用交錯陣列 int[][]（陣列的陣列），
			//存取寫法為 arr[row][column]。語意上也是 row/ column，但實作不同。
			int[,] numbers = {
								{ 3, 99, 100 },
								{ 13, 199, 200 },
								{ 6, 2, 300 },
							};

			//numbers.GetLength(0)：回傳陣列第 0 個維度的長度，對於二維矩陣 int[,]，第 0 維通常對應 列數（rows）。
			//numbers.GetLength(1)：回傳陣列第 1 個維度的長度，對於二維矩陣，這是 欄數（columns）。
			//簡單記法：GetLength(d) 中的 d 是「維度編號（dimension index）」，從 0 開始。

			for (int r = 0; r < numbers.GetLength(0); r++)
			{
				for (int c = 0; c < numbers.GetLength(1); c++)
				{
					Console.WriteLine($"numbers[{r},{c}] = {numbers[r, c]}");
				}
			}

			Console.WriteLine("---------------------------------------------------");
			//把 GetLength 的結果先存變數（rows, cols）是常見好習慣，避免每次循環都呼叫方法。
			int rows = numbers.GetLength(0);
			int cols = numbers.GetLength(1);

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					Console.WriteLine($"numbers[{r},{c}] = {numbers[r, c]}");
				}
			}
			Console.WriteLine("---------------------------------------------------");
			//與其他相關 API（比較）
			//numbers.Rank：回傳維度數（對二維陣列會是 2）。
			//numbers.Length：回傳陣列中所有元素的總數（rows* cols）。
			//例如上面 numbers.Length → 9。
			//numbers.GetUpperBound(d)：回傳在第 d 維的最大索引（等於 GetLength(d) -1）。
			//numbers.GetUpperBound(0) → 2（列最大索引）
			//numbers.GetUpperBound(1) → 2（欄最大索引）
			Console.WriteLine(numbers.Rank);//2(維度)
			Console.WriteLine(numbers.Length);//9=>總數（rows* cols）
			Console.WriteLine(numbers.GetLength(0));//3
			Console.WriteLine(numbers.GetLength(1));//3
			Console.WriteLine(numbers.GetUpperBound(0));//2
			Console.WriteLine(numbers.GetUpperBound(1));//2



		}

		/// <summary>
		/// 寫法 1=>直接寫, 取得二維陣列裡的最小值
		/// </summary>
		/// <returns></returns>
		private static int Demo01()
		{
			//numbers 是一個 3x3 的二維陣列
			int[,] numbers = {
								{  3,  99, 100 },   // row 0
								{ 13, 199, 200 },   // row 1
								{  6,   2, 300 },   // row 2
							};
			//result 初始設為 int.MaxValue（當作一個「非常大」的起始值），
			//確保陣列裡任何實際數值都會比它小，第一次比較會把 result 設為陣列的第一個元素。
			int result = int.MaxValue;
			//兩層 for 迴圈分別遍歷列（row）與欄（column），檢查每個 numbers[row, column]。
			for (int row = 0; row < numbers.GetLength(0); row++)
			{
				for (int column = 0; column < numbers.GetLength(1); column++)
				{
					if (numbers[row, column] < result) result = numbers[row, column];
				}
			}
			//若目前元素小於 result，就把 result 更新為該元素。
			//結果是整個陣列的最小值。以此陣列為例，回傳值會是 2。
			return result;

			//演算法特性：
			//時間複雜度 O(rows* cols)（必須看所有元素一次）。
			//空間複雜度 O(1)（只用一個暫存變數 result）。
		}
		/// <summary>
		/// 寫法 2=>將判斷兩個數值誰比較小的功能抽離成一支函數
		/// </summary>
		/// <returns></returns>

		//Demo02 做的事與 Demo01 功能相同：找出陣列的最小值，最後會回傳 2。
		//差別在於「比較並更新最小值」這個邏輯被抽出去成一支函式 GetMin。
		private static int Demo02()
		{
			int[,] numbers = {
								{  3,  99, 100 },   // row 0
								{ 13, 199, 200 },   // row 1
								{  6,   2, 300 },   // row 2
							};
			int result = int.MaxValue;
			for (int row = 0; row < numbers.GetLength(0); row++)
			{
				for (int column = 0; column < numbers.GetLength(1); column++)
				{
					result = GetMin(result, numbers, row, column);
				}
			}
			return result;
		}
		//GetMin 接收目前的 result（目前的最小值）、陣列、以及目前的 row、column，
		//並回傳比較後的較小者。程式中使用了三元運算子?:（簡寫的 if/else）。
		//GetMin 是純函式（pure function）：輸入固定會回傳固定輸出，且不會修改外部狀態，只回傳一個新值。
		//使主迴圈內的程式看起來「比較簡潔」，把"比較兩個數誰小"的責任分離出來。
		private static int GetMin(int result, int[,] numbers, int row, int column)
		{
			return numbers[row, column] < result ? numbers[row, column] : result;
		}
	}
}
