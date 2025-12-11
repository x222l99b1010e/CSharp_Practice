using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _00._020作業2_模擬簡單圖書館
{
	internal class Program
	{
		//建立一個 Book 類別，包含欄位：Title、Author 和 IsBorrowed(布林值)。
		//提供以下方法：
		//Borrow()：將 IsBorrowed 設為 true，並提示「已借出」。
		//Return()：將 IsBorrowed 設為 false，並提示「已歸還」。
		//DisplayInfo()：輸出書籍的資訊和是否已借出。
		static void Main(string[] args)
		{
			// 範例流程
			var book = new Book("精通 C# 程式設計", "作者甲");
			Console.WriteLine(book.DisplayInfo());
			var r1 = book.Borrow("使用者A", loanDays: 21);//輸出借閱結果
			Console.WriteLine(r1);//印出return的結果
			Console.WriteLine($"Borrow result: {r1} => {book.DisplayInfo()}");
			Console.WriteLine("-------------------------------------------------------------------");
			// 嘗試第二次借出（應該失敗）
			var r2 = book.Borrow("使用者B");
			Console.WriteLine($"Borrow result: {r2} => {book.DisplayInfo()}");
			Console.WriteLine("-------------------------------------------------------------------");
			// 歸還
			var r3 = book.Return();
			Console.WriteLine($"Return result: {r3} => {book.DisplayInfo()}");
			Console.WriteLine("-------------------------------------------------------------------");
			// 再次歸還（測試邊界）
			var r4 = book.Return();
			Console.WriteLine($"Return result: {r4} => {book.DisplayInfo()}");
			Console.WriteLine("-------------------------------------------------------------------");
			// 範例：建立書本時直接為已借出（示範建構子）
			var book2 = new Book("範例書", "作者乙", isBorrowed: true, borrower: "某人", borrowDate: DateTime.Today.AddDays(-10), dueDate: DateTime.Today.AddDays(4));
			Console.WriteLine(book2.DisplayInfo());

		}
	}

	/// <summary>
	/// 書本狀態（可擴充）
	/// </summary>
	public enum BookStatus
	{
		Available,   // 可借
		CheckedOut,  // 已借出
		Reserved,    // 被預約 / On hold
		Overdue,     // 逾期
		Lost,        // 遺失
		Damaged      // 損壞
	}

	/// <summary>
	/// 操作回傳結果，讓呼叫端能夠分辨失敗原因（較適合自動化測試）
	/// </summary>
	public enum BookActionResult
	{
		Success,//成功
		AlreadyBorrowed,//已被借走
		NotBorrowed,//尚未借出
		InvalidOperation,//無效操作
		InvalidInput,//無效輸入
	}

	/// <summary>
	/// Book 類別：含 Title, Author, 與借還相關 API。
	/// 設計重點：資料驗證、狀態模型、清楚回傳值與可被測試的 DisplayInfo().
	/// </summary>
	public class Book 
	{
		//這行宣告了 _sync 這個欄位，通常用來當作 鎖（lock）物件，協助在多執行緒環境下做原子性/同步化的程式區段。
		//逐項說明：
		//private：只有此類別內部可以存取，外部無法使用此物件來鎖（這是良好封裝，避免外部無意間鎖到同一物件）。
		//readonly：欄位在建構後其參考不可再變（你不能在其他方法把 _sync = new object() 再指派一次）；
		//但注意 readonly 不等於不可變，這裡的物件本身仍可被當作鎖使用。
		//object：是一個空物件實例，僅用於 lock(_sync)。實務上不建議 lock(this) 或 lock(typeof(SomeType))，
		//因為那會暴露鎖給外部程式，容易造成死結或外部競爭；用私有 object 最安全。
		private readonly object _sync = new object();

		// 基本屬性
		public string Title { get; private set; }
		public string Author { get; private set; }

		//可擴充之狀態(公開屬性)
		public BookStatus Status { get; private set; }

		//便利布林(保持向後相容)
		//這是一個 read-only computed property（唯讀計算屬性），沒有實體欄位來儲存值；每次讀取都會計算 Status 是否為 CheckedOut 或 Overdue，並回傳 true/false。
		//稱它為「便利布林」意思是：它提供一個 方便的布林判斷（方便別的程式碼用 if (book.IsBorrowed) ...），但它不是額外保存狀態，而是依據 Status 計算出的衍生資訊（derived value）。
		//優點：
		//不會導致狀態不一致（不會有兩處儲存相同邏輯的風險）。
		//呼叫端語意清楚（更易讀）。
		public bool IsBorrowed => Status == BookStatus.CheckedOut || Status == BookStatus.Overdue;

		//借閱相關資訊(非必要但實務有)
		public string? Borrower { get; private set;}
		public DateTime? BorrowDate { get; private set; }//這邊一定要加上"?" =>後面borrowDate有null!!!!!!!!!!!!!!!!!!!!
		public DateTime? DueDate { get; private set; }//這邊一定要加上"?" =>後面dueDate有null!!!!!!!!!!!!!!!!!!!!

		/// <summary>
		/// 建構子（預設為 Available）
		/// 預設狀態(如果沒有借閱者)=>只顯示title跟作者，預設isBorrowed:false
		/// </summary>
		// 簡易建構子：直接呼叫下面的中心建構子（預設 isBorrowed = false）
		public Book(string title, string author)
			: this(title, author, isBorrowed: false, borrower: null, borrowDate: null, dueDate: null)
		//this(...) 在 C# 中作**建構子鍊結（constructor chaining）**的語法，用來從一個建構子呼叫同一類別內的另一個建構子，重用初始化邏輯，避免重複程式碼。
		//必須放在建構子簽名後、主體（{ }）前的初始化器位置，
		{
			// 這裡的程式會在被呼叫的建構子執行完後執行（或在其之前？）
			// 這裡可以放「只在此建構子需要的額外邏輯」

			//實作順序：被呼叫的目標建構子會先執行（含其初始化），然後再執行目前建構子的主體（{ ... }）。
			//不能造成無窮遞迴（A 呼叫 B，B 又呼叫 A），編譯器會拒絕。
			//若要呼叫父類別（base class）的建構子，使用 : base(...)；不能同時使用 this(...) 與 base(...)（只能二擇一）。
			//但一個建構子可以透過 this(...) 呼叫另一個，該被呼叫的建構子可再使用 : base(...) 呼叫基底建構子。

			//何時使用
			//當你有多個重載建構子，且希望把共用初始化放在一個 central constructor（中心建構子）時。常見模式：
			//提供「簡易」與「完整」兩種建構子：簡易版呼叫完整版並傳遞預設值。
			//把驗證與欄位初始化只寫在一處（中心建構子），其他建構子只負責提供合理預設並 this(...) 呼叫它。
		}

		/// <summary>
		/// 建構子（允許從資料庫建立時指定"初始"借閱狀態）
		/// </summary>
		// 中心建構子：執行驗證與初始化
		public Book(string title, string author, bool isBorrowed, string? borrower = null, DateTime? borrowDate = null, DateTime? dueDate = null)
		{
			// 基本驗證
			//?? throw 的寫法簡潔，適合只需防止 null 並想以單行賦值方式處理的場合。
			//IsNullOrWhiteSpace（或更嚴格的驗證）則適合你需要拒絕空字串 / 空白的情況（多為使用者輸入驗證）。
			//較短的寫法（C# 8+）：
			Title = string.IsNullOrWhiteSpace(title)
					? throw new ArgumentException("title cannot be null/empty/whitespace", nameof(title))
					: title.Trim();
			Author = string.IsNullOrWhiteSpace(author)
					? throw new ArgumentException("author cannot be null/empty/whitespace", nameof(author))
					: author.Trim();


			if (isBorrowed)//isBorrowed = true  這邊設定狀態、借閱者、日期等
			{
				Status = BookStatus.CheckedOut;
				Borrower = borrower;
				BorrowDate = borrowDate;
				DueDate = dueDate;
			}
			else//isBorrowed = false  這邊設定狀態、借閱者、日期等
			{
				Status = BookStatus.Available;
				Borrower = null;
				BorrowDate = null;
				DueDate = null;
			}
		}
		/// <summary>
		/// 嘗試借書（提供借者名稱與借期天數），回傳操作結果。
		/// - 若已被借出，回傳 AlreadyBorrowed。
		/// - 若成功，設為 CheckedOut 並填入借閱資料，回傳 Success。
		/// </summary>
		public BookActionResult Borrow(string borrower, int loanDays = 14)
		{
			//邊界值=>設定借閱者不能為空
			if (string.IsNullOrWhiteSpace(borrower))
			{
				Console.WriteLine("借閱者不可為空");
				return BookActionResult.InvalidInput;
			}
			//邊界值=>借閱天數需要大於0 或是 小於31天(小於等於30天)
			if (loanDays <= 0 || loanDays > 30)
			{
				Console.WriteLine("借閱天數需大於0(包含)或是小於31天(不包含)");
				return BookActionResult.InvalidInput;
			}
			lock (_sync)
			// 這個區段在一個時間只會有一個執行緒進入
			// 用於保護共享狀態（例如 IsBorrowed、Borrower 等）
			{
				if (Status == BookStatus.CheckedOut || Status == BookStatus.Overdue)
				{
					Console.WriteLine("無法借出：書本已借出。");
					return BookActionResult.AlreadyBorrowed;
				}
				if (Status == BookStatus.Lost || Status == BookStatus.Damaged)
				{
					Console.WriteLine($"無法借出：書本狀態為 {Status}。");
					return BookActionResult.InvalidOperation;
				}

				// 成功借出
				Status = BookStatus.CheckedOut;
				Borrower = borrower;
				BorrowDate = DateTime.Now;
				DueDate = BorrowDate.Value.Date.AddDays(loanDays);//借閱日期+loanDays天數

				//BorrowDate.Value：取出 Nullable<T> 的實際值（DateTime）。
				//前提是 BorrowDate 非 null，否則.Value 會丟 InvalidOperationException。
				//所以在呼叫.Value 前應該確定它有值!!!!!!!!!!!!（例如已在邏輯檢查過或用 BorrowDate.HasValue）。!!!!!!!!!!

				//BorrowDate.Value.Date：Date 屬性會從 DateTime 取得日期部分（時間會被歸零為午夜 00:00:00）。
				//例如 2025 - 12 - 12T14: 23:11 → .Date 變成 2025 - 12 - 12T00: 00:00。
				//這常用於只想以「日期」而非含時分秒做運算或比較的情況。

				//在使用.Value 前最好檢查 BorrowDate.HasValue 或在語境中確定不會是 null。否則改用 BorrowDate!.Value（若你能保證）或更安全：
				//if (!BorrowDate.HasValue) throw new InvalidOperationException("BorrowDate 尚未設定。");
				//DueDate = BorrowDate.Value.Date.AddDays(loanDays);

				//若希望到期時間基於借出時刻（含時分秒），可改用 BorrowDate.Value.AddDays(loanDays)（不取.Date）。
				Console.WriteLine($"{Title}已成功借出");
				return BookActionResult.Success;
			}
		}
		/// <summary>
		/// 嘗試還書。若書本未被借出，回傳 NotBorrowed（或可視需求改為 Success 並忽略）。
		/// 還書時會清除借閱欄位並回到 Available（示例）。
		/// </summary>
		public BookActionResult Return()
		{
			//lock (_sync) { ... }
			//用來在多執行緒（multi - thread）環境中保護臨界區（critical section），
			//確保同一時間只有一個執行緒能執行該區塊內的程式，避免 race condition（競態條件）導致不一致狀態。

			//你貼出的內容是借書前的檢查（如果已借出或狀態不允許借出，則拒絕），
			//把它包在 lock 內是為了確保檢查與狀態改變為原子操作 —— 也就是別的執行緒在你檢查到「尚可借」到你把狀態改為 CheckedOut 之間不會插入另一個借書動作。

			//何時會用到
			//多執行緒程式（例如伺服器同時處理多個請求或應用內多個 thread/ Task），同一資料（物件）會被同時讀取與修改時。
			//範例情境：兩個使用者接近同時呼叫 Borrow()，若沒有同步，兩者可能都看到 Status== Available，結果都成功借走同一本書（錯誤）。

			lock (_sync)
			// 這個區段在一個時間只會有一個執行緒進入
			// 用於保護共享狀態（例如 IsBorrowed、Borrower 等）
			{
				//先設定未借出狀態
				//注意這邊 => "&&"
				//排除 已借出 和 已逾期的 兩種狀態
				//Status只有一種，「若狀態不是 CheckedOut 或（或）不是 Overdue」。
				//這個條件幾乎永遠為真，因為一個 Status 不可能同時等於 CheckedOut 與 Overdue；
				//對任一單一值，至少有一個不等成立。因此用 || 會導致邏輯錯誤。
				if (Status != BookStatus.CheckedOut && Status != BookStatus.Overdue)
				{
					Console.WriteLine("此書目前未借出，無需還書。");
					return BookActionResult.NotBorrowed;
				}
				// 還書流程：這裡僅重置狀態。
				//若逾期，可在此加入罰款邏輯。
				Status = BookStatus.Available;
				Borrower = null;
				BorrowDate = null;
				DueDate = null;
				Console.WriteLine($"已歸還{Title}。");
				return BookActionResult.Success;
				//lock 的語意是：取得 _sync 的互斥鎖，進入後其他嘗試 lock (_sync) 的執行緒會被阻塞，直到目前執行緒離開區塊（釋放鎖）。
			}
			//實務建議與陷阱
			//不要 lock (this)：避免外部鎖住你的物件導致死結或不可預期的行為。使用私有 readonly 物件（像 _sync）是標準作法。
			//不要 lock 字串或公用物件：因為字串會 intern，或物件可能被外部拿到，會引發問題。
			//lock 只適用同步方法：它在同步程式碼中工作良好。如果方法是 async 且會 await，lock 不能在 await 前後保持鎖；若要在 async 環境同步，請使用 SemaphoreSlim 或其他非同步同步原語。
			//lock 範圍要小：只包住需要保護的臨界區，避免長時間持鎖（以減少阻塞與死結風險）。
			//資料庫場景：若系統是分散式（多台伺服器或多程序），程式內的 lock 無法跨 process / 機器同步。此時應在資料庫層面用交易、樂觀鎖（rowversion）或悲觀鎖來保證一致性。
		}
		/// <summary>
		/// 顯示書籍資訊（不直接列印，方便在 UI 或測試中使用）
		/// </summary>
		public string DisplayInfo()
		{
			// 檢查是否逾期（簡單示意：若有到期日且已過，將狀態設為 Overdue）
			//已借出and逾期天數有值and現在時間>到期日期
			if (Status == BookStatus.CheckedOut && DueDate.HasValue && DateTime.Now.Date > DueDate.Value.Date)
			{
				Status = BookStatus.Overdue;
			}

			string statusDesc = Status switch
			{
				BookStatus.Available => "可借（Available）",
				BookStatus.CheckedOut => "已借出（CheckedOut）",
				BookStatus.Reserved => "已預約（Reserved）",
				BookStatus.Overdue => "逾期（Overdue）",
				BookStatus.Lost => "遺失（Lost）",
				BookStatus.Damaged => "損壞（Damaged）",
				_ => Status.ToString()
			};
			//設定借書狀態資訊(包含借閱者、借閱日期、到期日期)
			string borrowerInfo = Borrower != null ?$"借閱者：{Borrower}	" :string.Empty;
			string borrowDateInfo = BorrowDate.HasValue ? $"借出日：{BorrowDate:yyyy-MM-dd}	" : string.Empty;
			string dueDateInfo = DueDate.HasValue ? $"到期日：{DueDate:yyyy-MM-dd}	" : string.Empty;

			return $"書名：{Title}, 作者：{Author}, 狀態：{statusDesc}{borrowerInfo}{borrowDateInfo}{dueDateInfo}。";

		}

		/// <summary>
		/// Debug / log 用的字串
		/// </summary>
		public override string ToString() => DisplayInfo();
	}
}
