namespace ConsoleApp40
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Student allen = new Student("allen");
			allen.Name = "Allen Kuo";
			//裡面的 allen 是前面的變數名稱，而不是建構子。這行程式碼的作用是：
			//找到名為 allen 的變數所指向的那個 Student 物件，並將其內部的 Name 欄位的值重新設定為 "Allen Kuo"。
	}

		class Student
		{
			public string Name;
			public string Email;

			public Student(string name)//建構子(Constructor,建構函數
			{
				Name = name;
			}

			public string GetInfo()
			{
				return $"{Name} 的Email：{Email}";
			}
		}

	}
}
