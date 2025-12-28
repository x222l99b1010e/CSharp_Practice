using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp51
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			var allen = new Student();
			allen.Email = "allen@gmail.com";
			Console.WriteLine(allen.Email);
			allen.DateOfBirth = new DateTime(1968,2,2);
			Console.WriteLine(allen.Age);//只能get年紀  用扣的取得年紀，這邊沒有直接設定年紀
			//allen.Age = 18;//無法指派為屬性或索引子 'Student.Age' -- 其為唯讀
		}
	}

	class Student
	{
		public string _name;//欄位  小寫 私有 _name
		private string _email;//field 私有的
		public string Address { get; set; }
		public int Height { get; set; }
		public string Email//可讀可寫  可唯讀可唯寫 可驗證
		{
			get { return _email; }
			set {
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("Email 不能是null 或是 空字串");
				}
				if (value.IndexOf("@") < 0)
				{
					throw new Exception("Email 格式有錯誤");
				}
				_email = value;
			}
		}
		private DateTime _dateOfBirth;
		public DateTime DateOfBirth
		{ 
			get { return _dateOfBirth; }
			set { _dateOfBirth = value; }
		}
		//資料一致性（Data Integrity）： 如果 Age 可以被隨意設定，萬一有人寫 DateOfBirth = 1990年 但 Age = 80，
		//這份資料就產生了矛盾。只讓 Age 透過 get 計算，能確保年齡永遠跟著生日走。

		//節省儲存空間： 在資料庫中，我們通常只存「生日」，不存「年齡」。
		//因為年齡每一秒都在變，存死資料沒有意義。透過 get，我們可以在程式執行時才動態算出最新結果。

		//封裝邏輯： 對外部使用者（例如你的 Main 方法）來說，
		//他不需要知道年齡是怎麼算的（是用西元、民國，還是有沒有扣掉閏年），
		//他只需要說「給我 Age」，你的類別就負責把結果吐出來。
		public int Age
		{
			//對於這種「只有 get 且只有一行」的屬性，現代 C# 有一種更簡潔的寫法：
			// 這行跟你的 Age 寫法效果一模一樣，但更帥一點
			//public int Age => DateTime.Today.Year - _dateOfBirth.Year;
		get
			{
				return DateTime.Today.Year - _dateOfBirth.Year;
			}
		}
	}
}
