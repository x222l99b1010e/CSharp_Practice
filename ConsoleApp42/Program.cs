namespace ConsoleApp42
{
	internal class Program
	{

		//計算長方形面積與周長：
		//建立一個 Rectangle 類別，包含兩個欄位：Length 和 Width。
		//提供以下方法：
		//GetArea()：回傳長方形面積。
		//GetPerimeter()：回傳長方形周長。
		static void Main(string[] args)
		{
			Rectangle rectangle1 = new Rectangle(30, 60);
			//如果類別裡面一堆方法都要用到長寬，那可以用這方法，設定一次長寬就能用一堆方法，
			//不用每呼叫一次方法都還要輸入一次參數
			Console.WriteLine(rectangle1.GetArea());
			Console.WriteLine(rectangle1.GetPerimeter());
			rectangle1.Length = 45;
			rectangle1.Width = 45;//要用新長方形還要重新設定長寬，比較麻煩
			Console.WriteLine(rectangle1.GetArea());
			Console.WriteLine(rectangle1.GetPerimeter());

			RectangleB rectangleB = new RectangleB();
			//如果臨時叫用而且方法不多，不太需要常用到長寬可以用這方式
			Console.WriteLine(rectangleB.GetArea(40,50));
			Console.WriteLine(rectangleB.GetPerimeter(40,50));
			Console.WriteLine(rectangleB.GetArea(44,46));
			Console.WriteLine(rectangleB.GetPerimeter(44,46));


			//最方便的是static，直接呼叫就好
			//不需要new一個新的長方形，因為面積公式都是固定，
			//不需要像存取一堆個別用戶這種資訊，只要給長寬參數(就是=>公用程式)
			Console.WriteLine(RectangleC.GetArea(43, 47));
			Console.WriteLine(RectangleC.GetPerimeter(43, 47));
		}
	}
	public class RectangleC{
		public static int GetArea(int length, int width)
		{
			return length * width;
		}
		public static int GetPerimeter(int length, int width)
		{
			return 2 * (length + width);
		}
	}
	public class RectangleB{
		public int GetArea(int length, int width)
		{
			return length * width;
		}
		public int GetPerimeter(int length, int width)
		{
			return 2 * (length + width);
		}
	}
	public class Rectangle{
		public int Length;
		public int Width;
		public Rectangle(int length, int width)
		{
			Length = length;
			Width = width;			
		}

		public int GetArea() {
			return Length * Width;
		}
		public int GetPerimeter() {
			return 2*(Length + Width);
		}
	}
}
