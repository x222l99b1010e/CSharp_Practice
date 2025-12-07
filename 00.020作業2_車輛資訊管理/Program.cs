namespace _00._020作業2_車輛資訊管理
{
	internal class Program
	{

		//建立一個 Car 類別，包含欄位：Brand(字串)、Model(字串)、Speed(整數)。
		//提供以下方法：
		//Accelerate(int amount)：加速，將速度增加指定數值。
		//Brake(int amount)：減速，將速度降低指定數值（速度不可小於 0）。
		//DisplayInfo()：輸出品牌、型號和速度。
		static void Main(string[] args)
		{
			var c1 = new Car("Benz", "E300", maxSpeed: 400, initialSpeed: 120);
			Console.WriteLine(c1); // 應該顯示 120/400

			c1.Accelerate(int.MaxValue);
			Console.WriteLine(c1); // 應該顯示 400/400（而不是亂數或負數）

			c1.Brake(9999);
			Console.WriteLine(c1); // 應該顯示 0/400
		}
	}

	public class Car
	{
		// 改為 property：對外可讀，只有類別內能改 (建議用 private set)
		public string Brand { get; }
		public string Model { get; }
		public int Speed { get; private set; }

		private readonly int MaxSpeed; // 建構後不可變（更安全）

		//public string Brand;
		//public string Model;
		//public int Speed;
		//private readonly int MaxSpeed; // 建構後不可變（更安全）

		// 類別層級的車輛最高速
		//目前程式沒有實作「單次加速上限」與「車輛總上限」不同的概念。
		//若你有這需求，需要把兩者分開
		//（例如 const int MaxSpeed = 400; const int MaxSingleAccelerate = 200;
		//並在 Accelerate 檢查 amount <= MaxSingleAccelerate）。

		public Car(string brand, string model, int maxSpeed = 400, int initialSpeed = 0)
		{
			Brand = brand ?? throw new ArgumentNullException(nameof(brand));
			Model = model ?? throw new ArgumentNullException(nameof(model));
			if (maxSpeed <= 0) throw new ArgumentOutOfRangeException(nameof(maxSpeed), "maxSpeed 必須為正數。");

			MaxSpeed = maxSpeed; // 先指派 MaxSpeed！

			if (initialSpeed < 0) throw new ArgumentOutOfRangeException(nameof(initialSpeed), "初始速度不可為負數。");
			Speed = Math.Min(initialSpeed, MaxSpeed); // 用已設定的 MaxSpeed 來夾初始速度
			//注意!!!限制最高初始速度

		}
		/// <summary>
		/// 加速(假設能達大最大速度為400)
		/// </summary>
		/// <param name="amount"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public int Accelerate(int amount)
		{
			if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "加速量不可為負數。");
			long newSpeed = (long)Speed + amount;      // 使用 long 避免整數溢位
			Speed = (int)Math.Min(newSpeed, MaxSpeed);
			return Speed;
		}

		public int Brake(int amount)
		{
			if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount), "煞車量不可為負數。");
			Speed = Math.Max(Speed - amount, 0);
			return Speed;
		}

		public string DisplayInfo()
		{
			return $"品牌：{Brand}, 型號：{Model}, 目前車速/車速上限：{Speed}/{MaxSpeed}";
		}

		public override string ToString()
		{
			return $"品牌：{Brand}, 型號：{Model}, 目前車速/車速上限：{Speed}/{MaxSpeed}";
		}
	}
}
