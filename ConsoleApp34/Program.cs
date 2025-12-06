namespace ConsoleApp34
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int price = 210;
			double tax = (int)Math.Round(price * 0.05);//其實是四捨六入五成雙
			double tax2 = Math.Round(price * 0.05);			
			double tax1 = price * 5 / 100;
			Console.WriteLine(tax);
			Console.WriteLine(tax1);//無條件捨去//floor
			Console.WriteLine(tax2);//10.5四捨五入=>不是11=>靠近10=>偶數//10

			int tax3 = (int)Math.Round(price * 0.05,MidpointRounding.AwayFromZero);
			Console.WriteLine(tax3);//遠離0//11

			decimal num3 = Math.Round(6.5m);
			Console.WriteLine(num3);

			float float1 = 10.0f / 3.0f;
			float float2 = float1 * 3;
			Console.WriteLine(float1 * 3);
			Console.WriteLine(float2);
		}
	}
}
