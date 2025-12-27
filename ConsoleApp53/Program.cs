namespace ConsoleApp53
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			int sum = Add(1, 2, 3, 4, 5, 6);
			Console.WriteLine(sum);
		}
		static int Add(int a, int b)
		{
			return a + b;
		}
		static int Add(int a, int b, params int[] others)
		{
			int sum = a + b;
			foreach (int i in others)
			{
				sum += i;
			}
			return sum;
		}
	}
	
}
