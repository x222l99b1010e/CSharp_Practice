using System.ComponentModel.DataAnnotations;

namespace ConsoleApp38
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Member allen = new Member();
			allen.Name = "Allen";
			allen.Email = "Allen@gmail.com";

			string message = $"{allen.Name}的Email：{allen.Email}";
			Console.WriteLine(message);
			Console.WriteLine("---------------------------------------");

			Console.WriteLine(allen.GetInfo());

			Member simon = new Member();
			simon.Name = "Simon";
			simon.Email = "Simon.gmail.com";
			message = $"{simon.Name}的Email：{simon.Email}";
			Console.WriteLine(message);
		}
	}

	class Member {
		// Class, 類別
		public string? Name;//Field, 欄位
		public string? Email;

		private int age;//私有的,小寫

		public string GetInfo() {
			string message = $"{Name}的Email：{Email}";
			return message;
		}
	}
}
