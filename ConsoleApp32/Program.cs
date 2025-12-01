namespace ConsoleApp32
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int sum = Add(5, 10);
			Console.WriteLine(sum);

			sum = Calculate(1, 100);
			Console.WriteLine(sum);
			
		}

		/// <summary>
		/// 傳回begin 到 end 總和
		/// </summary>
		/// <param name="begin">數列起始值</param>
		/// <param name="end">數列結束值</param>
		/// <returns>數列的總和</returns>
		static int Calculate(int begin, int end)
		{
			return (begin + end) * (end - begin + 1)/2;
		}


		static int Add(int a, int b)
		{
			return a + b;
		}
	}
}
