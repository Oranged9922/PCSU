namespace PCSU.Controllers
{
	using PCSU.Models;

	public class SorterController
	{
		public string StoredSelectedFolderDestination { get; set; } = "C:\\PCSU\\";
		public int BeginNumbering { get; set; } = 0;
		public Dictionary<Options.FileNamingOptionsEnum, string> ExampleFileNamingOptions { get; }
		public SorterController()
		{
			this.ExampleFileNamingOptions = new(){ 
			// for each enum generate accordingly representative string
			{ Options.FileNamingOptionsEnum.ddmm, "1511" },
			{ Options.FileNamingOptionsEnum.ddmmyy, "151122" },
			{ Options.FileNamingOptionsEnum.Document_Name, "_Img5622" },
			{ Options.FileNamingOptionsEnum.document_name, "_img5622" },
			{ Options.FileNamingOptionsEnum.DOCUMENT_NAME, "_IMG5622" },
			{ Options.FileNamingOptionsEnum.empty, "" },
			{ Options.FileNamingOptionsEnum.mmdd, "1115" },
			{ Options.FileNamingOptionsEnum.mmddyy, "111522" },
			{ Options.FileNamingOptionsEnum.SerialLetterabc, "a" },
			{ Options.FileNamingOptionsEnum.SerialLetterABC, "b" },
			{ Options.FileNamingOptionsEnum.SerialNumber1, BeginNumbering.ToString("0") },
			{ Options.FileNamingOptionsEnum.SerialNumber2, BeginNumbering.ToString("01") },
			{ Options.FileNamingOptionsEnum.SerialNumber3, BeginNumbering.ToString("001") },
			{ Options.FileNamingOptionsEnum.SerialNumber4, BeginNumbering.ToString("0001") },
			{ Options.FileNamingOptionsEnum.SerialNumber5, BeginNumbering.ToString("00001") },
			{ Options.FileNamingOptionsEnum.SerialNumber6, BeginNumbering.ToString("000001") },
			{ Options.FileNamingOptionsEnum.yyddmm, "221511" },
			{ Options.FileNamingOptionsEnum.yymmdd, "221115" },
			{ Options.FileNamingOptionsEnum.yyyymmdd, "20221115" }, };
		}

		public static List<string> GetAllFileExtensionsOptions()
		=> Options.FileExtensionsEnumDictionary.Values.ToList();

		// return list of all destination options
		public static List<string> GetAllDestinationOptions()
			=> Options.DestinationOptionsEnumDictionary.Values.ToList();
		public static bool IsSaveInSameLocationSelected(string? selectedItem)
		=> selectedItem == Options.DestinationOptionsEnumDictionary[Options.DestinationOptionsEnum.SaveInSameLocation];
		public static List<string> GetAllSortSubfoldersOptions()
			=> Options.SortSubfoldersOptionsEnumDictionary.Values.ToList();
		public static List<string> GetAllFileNamingOptions()
			=> Options.FileNamingOptionsEnumDictionary.Values.ToList();

		public static Options.FileNamingOptionsEnum GetFileNamingOptionsEnum(string? selectedItem)
		=> Options.FileNamingOptionsEnumDictionary.FirstOrDefault(x => x.Value == selectedItem).Key;
	}
}
