namespace _00._020HW3_ResizeTarget
{
	internal class Program
	{
		//有一個按比例縮圖的method, 
		//static void ResizeImage(string fileName, int maxWidth, int maxHeight)
		//請你新增一個 ResizeTarget class, 內含 MaxWidth, MaxHeight property, 然後將上述 method 的第2,3個參數刪除, 改用一個 ResizeTarget 型別的參數
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");

			// 實作方式：先建立物件，再傳入 method
			ResizeTarget target = new ResizeTarget { MaxWidth = 800, MaxHeight = 600 };
			ResizeImage("photo.jpg", target);

		}
		//static void ResizeImage(string fileName, int maxWidth, int maxHeight)
		//{

		//}


		// 題目要求：刪除原本的 int 參數，改用 ResizeTarget 型別的單一參數
		static void ResizeImage(string fileName, ResizeTarget target)
		{
			// 在 method 內部，你可以透過 target.MaxWidth 取得數值
			Console.WriteLine($"縮放檔案: {fileName} 至 {target.MaxWidth}x{target.MaxHeight}");
		}
	}
	class ResizeTarget
	{
		public int MaxWidth {  get; set; }
		public int MaxHeight { get; set; }
	}

}
