namespace ConsoleApp39
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Member.Name = "Allen";
			Member.Email = "Allen@gmail.com";
			Console.WriteLine(Member.GetInfo());//就算class不是static 只要方法是static就可以這樣呼叫

			Member allen = new Member();
			allen.GetInfoB();

			Console.WriteLine(Member.GetInfoA());
		}
	}

	//static=>一些共用(公用)功能或是單一功能  例如刪除檔案複製檔案 縮圖 計算營業稅寄送信件
	//如果要存取類別裡面相關資訊才會湊出資料就不要用static
	//如果使用了static class 裡面所有成員或方法都要是static
	//如果沒有static  那可以選擇加不加static


	class Member
	{
		// Class, 類別
		//static 靜態類別在整份程式裡面只有一份，因此不能用new
		//=> Member allen = new Member();
		//只能直接叫用，只有一份不能new很多實例
		public static string Name;//Field, 欄位
		public static string Email;

		private static int age;//私有的,小寫

		public static string GetInfo()
		{
			string message = $"{Name}的Email：{Email}";
			return message;
		}
		public static string GetInfoA()
		{
			return "AAAAA";
		}
		public string GetInfoB()
		{
			return "BBBBB";
		}
	}
}
