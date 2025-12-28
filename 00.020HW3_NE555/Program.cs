using System.Diagnostics.Metrics;

namespace _00._020HW3_NE555
{
	internal class Program
	{
		//設計一個 class NE555 它有一個建構函數, 可以傳入一個參數
		//public NE555(int count) , 例如傳入 6, 寫成 var obj = new NE555(6)
		//然後, 為它新增一支method pubilc int Ping() , 每次叫用它時, 會回傳加1, 直到6時, 下次又會回傳1
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			var helper = new NE555(2); // 會循環回傳 1 ~ 6
			Console.WriteLine(helper.Ping()); // "1"
			Console.WriteLine(helper.Ping()); // "2"
			Console.WriteLine(helper.Ping()); // "1"
			helper.Reset();
			helper.Reset(3);
			Console.WriteLine(helper.Ping()); // "1"
			Console.WriteLine(helper.Ping()); // "2"
			Console.WriteLine(helper.Ping()); // "3"
		}
	}
	class NE555
	{
		private int _count;
		private int _current;
		/// <summary>
		/// NE555建構函數
		/// </summary>
		/// <param name="count">傳入循環數字(預設是6)</param>
		public NE555(int count = 6)
		{
			if (count == 0)	{throw new Exception("不能輸入數字0");	}
			if (count < 0)	{count = Math.Abs(count);	}
			_count = count;
			_current = 0;
		}
		public int Ping()
		{
			//這會讓current一直長大直到 = 6
			//_current = (_current % _count) + 1;

			//========================================
			int result = _current + 1;       // 先計算要回傳的結果 (1~6)
			_current = (_current + 1) % _count; // 讓 _current 在 0~5 之間循環
			return result;

			//_current++;
			//if (_current > _count)
			//{
			//	_current = 1;
			//}
			//return _current;
		}
		public void Reset()
		{
			_current = 0;
		}
		public void Reset(int newCount = 8)
		{
			// 1. 先處理數字安全性（像建構函數那樣）
			if (newCount <= 0) throw new Exception("上限必須大於 0");
			if (newCount < 0){newCount = Math.Abs(newCount);}
			// 2. 更新上限
			_count = newCount;
			// 3. 直接呼叫原本的 Reset() 來歸零
			Reset();
		}
	}
}
