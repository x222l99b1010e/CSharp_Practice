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
		public int Age
		{
			get
			{
				return DateTime.Today.Year - _dateOfBirth.Year;
			}
		}
	}
}
