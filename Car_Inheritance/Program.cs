//題目一：Car Inheritance（汽車繼承）
//在一個程式中，已經定義好一個抽象類別 Car，包含下列成員：
//受保護欄位：isSedan: bool、seats: string
//建構子：Car(bool isSedan, string seats)
//已實作方法：getIsSedan(): bool、getSeats(): string
//抽象方法：getMileage(): string
//方法 printCar(string name) 會輸出：
//A {name} is { not} Sedan, is { seats } - seater, and has a mileage of around {mileage}.
//請你在 C# 中完成以下工作：
//宣告三個繼承自 Car 的類別：WagonR、HondaCity、InnovaCrysta。
//每個類別都有一個建構子，參數為整數 mileage，代表油耗。
//在建構子中呼叫基底類別建構子設定 isSedan 與 seats：
//WagonR：不是 sedan，4 座。
//HondaCity：是 sedan，4 座。
//InnovaCrysta：不是 sedan，6 座。
//在三個子類別中實作 getMileage()，回傳格式為 "<mileage> kmpl"。
namespace Car_Inheritance
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
		}
	}
	abstract class Car
	{
		protected bool isSedan;
		protected string seats;

		public Car() { }

		public Car(bool isSedan, string seats)
		{
			this.isSedan = isSedan;
			this.seats = seats;
		}


		public bool getIsSedan()
		{
			return this.isSedan;
		}


		public string getSeats()
		{
			return this.seats;
		}


		abstract public string getMileage();


		public void printCar(string name)
		{
			Console.WriteLine("A {0} is{1} Sedan, is {2}-seater, and has a mileage of around {3}.",
			name,
			this.getIsSedan() ? "" : " not",
			this.getSeats(),
			this.getMileage());
		}
	}

	class WagonR : Car
	{
		private int mileage;

		public WagonR(int mileage) : base(false, "4")   // 不是 sedan，4 人座
		{
			this.mileage = mileage;
		}

		public override string getMileage()
		{
			return $"{mileage} kmpl";
		}
	}

	class HondaCity : Car
	{
		private int mileage;

		public HondaCity(int mileage) : base(true, "4") // 是 sedan，4 人座
		{
			this.mileage = mileage;
		}

		public override string getMileage()
		{
			return $"{mileage} kmpl";
		}
	}

	class InnovaCrysta : Car
	{
		private int mileage;

		public InnovaCrysta(int mileage) : base(false, "6") // 不是 sedan，6 人座
		{
			this.mileage = mileage;
		}

		public override string getMileage()
		{
			return $"{mileage} kmpl";
		}
	}

}
