namespace ConsoleApp26
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<string> students1 = new List<string>();//小括號可省略 =>()
			students1.Add("Bob");
			students1.Add("Allen");
			foreach (string student1 in students1)
			{ 
				Console.WriteLine(student1.ToUpper());
			}

			List<string> students2 = new List<string>//沒有小括號 =>() 
			{
				"123",
				"456"
			};
			for (int i = 0; i < students2.Count; i++)
			{
				Console.WriteLine(students2[i]);
			}

			List<string> students3 = new List<string>() { "789", "012" };

			List<int> scores = new List<int>() { 70,80,90};
			scores.Add(100);//事後可增減元素
			for (int i = 0; i < scores.Count; i++) 
			{
				Console.WriteLine(scores[i]);
			}


		}
	}
}
