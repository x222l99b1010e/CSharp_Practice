namespace ConsoleApp23
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Type intType = typeof(int); // intType 的值為 System.Int32
			Console.WriteLine(intType);

			int? x = 5;
			int? y = 10;

			x = x ?? y; // x 的值為 5，因為 x 已經被初始化
			Console.WriteLine(x);

			int? z = null;
			z = z ?? y; // z 的值為 10，因為 z 沒有被初始化
			Console.WriteLine(z);
			int z2 = (z.HasValue) ? z.Value : y.Value;
			Console.WriteLine(z2);


		}
	}
}
