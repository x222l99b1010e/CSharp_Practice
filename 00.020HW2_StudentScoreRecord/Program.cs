namespace _00._020HW2_StudentScoreRecord
{
	internal class Program
	{
		//學生分數記錄：
		//建立一個 Student 類別，包含欄位 Name 和 Score(整數)。
		//提供以下方法：
		//IsPass()：回傳是否及格(及格分數為 60 分)。
		//DisplayInfo()：輸出學生姓名和分數。
		static void Main(string[] args)
		{
			//---------------------Student------------------
			Student allen = new Student{Name = "Allen", Score = 78 };
			string scoreResult = allen.IsPass();
			string studentInfo = allen.DisplayInfo();
			Console.WriteLine(scoreResult);
			Console.WriteLine(studentInfo);

			//---------------------Student1------------------
			// 單一學生示範
			var allen1 = new Student1("Allen", 78);
			Console.WriteLine(allen1); 
			//會呼叫 ToString()
			//直接覆寫原本ToString();改變輸出
			//但是會跟題目要求的方法名稱不一樣
			Console.WriteLine(allen1.IsPass() ? "及格" : "不及格");
			Console.WriteLine();

			// ===== 使用 while 迴圈輸入多位學生範例 =====
			var students = new List<Student1>();
			while (true)
			{
				Console.Write("輸入學生姓名（按 Enter 結束）: ");
				string? name = Console.ReadLine()?.Trim();
				if (string.IsNullOrEmpty(name))
				{
					// 空姓名 -> 結束輸入
					break;
				}

				Console.Write("輸入分數（0~100）: ");
				string? scoreText = Console.ReadLine()?.Trim();

				if (!int.TryParse(scoreText, out int score))
				{
					Console.WriteLine("分數格式錯誤，請輸入整數。");
					continue; // 回到 while 開始（允許重新輸入該學生）
				}

				try
				{
					var s = new Student1(name, score);
					students.Add(s);
					Console.WriteLine("已加入：" + s);
				}
				catch (ArgumentOutOfRangeException ex)
				{
					Console.WriteLine("錯誤：" + ex.Message);
					// 可選：continue 讓使用者重新輸入
				}

				Console.WriteLine(); // 空行
			}

			// 輸入結束後，列印所有學生與狀態
			Console.WriteLine("===== 學生列表 =====");
			foreach (var s in students)
			{
				Console.WriteLine($"{s.Name}：{s.Score} 分 — {(s.IsPass() ? "及格" : "不及格")}");
			}
		}
	}

	public class Student {
		public string? Name;
		public int Score;

		public string IsPass() {

			string scoreStatus = "";
			if (Score > 100 || Score < 0) scoreStatus = "輸入成績有誤";

			else if (Score >= 60) scoreStatus = "及格";

			else scoreStatus = "不及格";

			return scoreStatus;
		}

		public string DisplayInfo() {
			string studentInfo = $"學生姓名：{Name},學生成績{Score}"; 
			return studentInfo;
		}
	
	
	}

	public class Student1
	{
		// 及格分數常數，方便維護
		public const int PassingScore = 60;

		// 屬性，公開讀取/寫入（可依需求改為 private set）
		public string Name { get; }
		public int Score { get; }

		// 建構子：建立時即驗證資料
		public Student1(string name, int score)
		{
			//nameof 是 C# 的一個運算子（operator），編譯時會把括號內的識別子名稱轉成字串。
			//string s1 = nameof(score); // s1 == "score"
			//string s2 = nameof(Name);  // s2 == "Name"

			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("姓名不可為空", nameof(name));

			if (score < 0 || score > 100)
				throw new ArgumentOutOfRangeException(nameof(score), "分數必須介於 0 到 100。");

			Name = name;
			Score = score;
		}

		// 回傳是否及格（純邏輯）
		public bool IsPass()
		{
			return Score >= PassingScore;
		}

		// 覆寫 ToString() 方便印出
		//因為預設的 ToString() 只會回傳類別名稱：
		//Console.WriteLine(new Student());
		// 預設輸出： _00._020作業2_學生分數記錄.Student
		//不太好看、不易讀也不實用。
		//所以我們會** 覆寫（override）**成自己想要的格式：
		public override string ToString()
		{
			return $"學生姓名：{Name}，學生成績：{Score}";
		}
	}
}
