namespace ConsoleApp37
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int begin = 205, end = 100;
			//要讓小的數值在前面
			if (begin > end) 
			{
				int temp;
				temp = begin;
				begin = end;
				end = temp;
			}
			string message = $"{begin} ~ {end}";
			Console.WriteLine(message);

			string result = "abc" + 123;//abc123
			Console.WriteLine(result);
			result = "abc" + (12 + 3).ToString();//abc15
			Console.WriteLine(result);
			result = "abc" + 12.ToString() + 3.ToString();//abc123
			Console.WriteLine(result);
			result = "abc" + 12 + 3;//盲猜abc123?????
			Console.WriteLine(result);
		}
	}
}
