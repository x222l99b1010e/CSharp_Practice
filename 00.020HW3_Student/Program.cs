namespace _00._020HW3_Student
{
	internal class Program
	{
		//開一個新專案, 宣告一個類別 Student
		//具備 Name, Chinese, English properties
		//將檢查各科分數(只能介於[0, 100] 的規則)的程式抽離成一支 private method ,供以下2個屬性共同叫用
		//國文(Chinese)成績
		//英文(English)成績
		//而不是在二個屬性裡重複撰寫檢查程式
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			var allen = new Student();
			allen.English = -20;
			Console.WriteLine(allen.English);
		}
	}

	public class Student
	{
		// 1. 宣告私有欄位來儲存實際資料
		private int _chinese;
		private int _english;
		private string _name;
		public string Name
		{
			get { return _name.ToUpper(); } // 拿出來時自動變大寫
			set { _name = value; }
		}

		// 2. 核心：抽離出來的檢查方法 (private method)
		private int ValidateScore(int value)
		{
			if (value < 0 || value > 100)
			{
				throw new Exception("分數要介於0~100之間");
			}
			return value;
		}
		// 3. 國文屬性
		public int Chinese
		{
			get { return _chinese; }
			set { _chinese = ValidateScore(value); }
		}

		// 4. 英文屬性
		public int English
		{
			get { return _english; }
			set { _english = ValidateScore(value); }
		}
	}
}
