namespace ConsoleApp31
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string item = "0123456789";
			string total = "";
			for (int i = 0; i < 1; i++)
			{
				total = total + item;
			}
			Console.WriteLine(total.Length);

			//使用 StringBuilder 來優化字符串連接
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			for (int i = 0; i < 1000; i++) 
			{
				sb.Append(item);
			}
			total= sb.ToString();//無法將類型 'System.Text.StringBuilder' 隱含轉換成 'string'
			Console.WriteLine(total.Length);

		}
	}
}
