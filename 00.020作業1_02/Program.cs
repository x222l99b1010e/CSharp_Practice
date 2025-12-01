namespace _00._020作業1_02
{
	internal class Program
	{

		//找出 >= 91 的第一個 7 的倍數
		//列出[13, 100] 中, 7 的倍數
		static void Main(string[] args)
		{
			int result = (91%7 == 0)?91:91+(7-91%7);
			Console.WriteLine(result);


			int result1 = 13 % 7;
			for (int i = 13+(7-result1); i <= 100; i+=7)
			{
				//Console.WriteLine(i);
			}

			int start = (int)(Math.Ceiling(13 / 7.0) * 7);
			for (int i = start; i <= 100; i += 7)
			{
				//Console.WriteLine(i);
			}
		}
	}
}
