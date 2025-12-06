namespace ConsoleApp35
{
	internal class Program
	{
		//數值格式化
		static void Main(string[] args)
		{
			double n1 = 0.05;
			double n2 = 0.05665;//這沒有遵守四捨五入!!
			string s1 = n1.ToString("p");//5.00%
			string s2 = n2.ToString("p");//5.00%
			Console.WriteLine(s1);
			s1 = n1.ToString("p1");//5.0%
			Console.WriteLine(s1);
			s1 = n1.ToString("p0");//5%
			Console.WriteLine(s1);
			Console.WriteLine(s2);//!!!!!!!!結果不是5.67%!!!!!!

		}
	}
}
