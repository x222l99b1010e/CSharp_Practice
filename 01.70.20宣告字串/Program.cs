using System.Text;

namespace _01._70._20宣告字串
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string stars = DeclareString(10);
			//Console.WriteLine(stars);
			Console.WriteLine(DeclareString1(10));

			MakeStars(5);


		}

		static string DeclareString(int a)
		{
			if (a <= 0) return string.Empty;
			string result = new string('*', a);
			return result;
		}

		static string DeclareString1(int a)
		{
			if (a <= 0) return string.Empty;
			StringBuilder sb = new StringBuilder();
			for (int i = 1; i <= a; i++)
			{				
				sb.Append('*');				
			}
			return sb.ToString();
		}

		static void MakeStars(int count)
		{
			string result = "";

			for (int i = 0; i < count; i++)
			{
				result += "*";
			}

			Console.WriteLine(result);
		}
	}
}
