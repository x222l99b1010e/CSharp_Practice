namespace ConsoleApp33
{
	internal class Program
	{
		static void Main(string[] args)
		{
			float n100 = 100.5F;
			decimal n101 = 100.5M;
			Console.WriteLine($"{n100} and {n101}");
			int intg  = 9 / 5;
			Console.WriteLine(intg);//1

			decimal n4 = 10 / 4.0m;
			decimal n1 = 10.0m / 4;
			decimal n2 = 10 / 4;
			Console.WriteLine(n4);//2.5
			Console.WriteLine(n1);//2.5
			Console.WriteLine(n2);//2

			double n5 = 9.0d / 4.0D;
			Console.WriteLine(n5);//2.5

			int num1 = 10, num2 = 4;
			n5 = num1 / num2;
			Console.WriteLine(n5);//2
			n5 = (double)num1 / num2;
			Console.WriteLine(n5);//2.5
			n5 = num1 / (double)num2;
			Console.WriteLine(n5);//2.5
			n5 = ((double)num1 / (double) num2);//2.5
			Console.WriteLine(n5);
		}
	}
}
