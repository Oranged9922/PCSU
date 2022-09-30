namespace PCSU.Models
{

	public static class Options
	{
		public enum DestinationOptionsEnum
		{
			SaveInSameLocation = 10,
			SaveInNewLocation = 20,
		}

		public enum SortSubfoldersOptionsEnum
		{
			YYYY_MMDD = 10,
			YYYY_MM = 20,
			YYYY_MM_DD = 30,
		}

		public enum FileNamingOptionsEnum
		{
			Document_Name = 10,
			document_name = 20,
			DOCUMENT_NAME = 30,
			SerialNumber1 = 40,
			SerialNumber2 = 50,
			SerialNumber3 = 60,
			SerialNumber4 = 70,
			SerialNumber5 = 80,
			SerialNumber6 = 90,
			SerialLetterabc = 100,
			SerialLetterABC = 110,
			mmddyy = 120,
			mmdd = 130,
			yyyymmdd = 140,
			yymmdd = 150,
			yyddmm = 160,
			ddmmyy = 170,
			ddmm = 180,
			empty = 190
		}

		public enum FileExtensionsEnum
		{
			jpg = 10,
		}

		public static readonly Dictionary<DestinationOptionsEnum, string> DestinationOptionsEnumDictionary = new()
		{
			{DestinationOptionsEnum.SaveInSameLocation,"Save in same location as file"},
			{DestinationOptionsEnum.SaveInNewLocation,"Save in new location"},
		};

		public static readonly Dictionary<SortSubfoldersOptionsEnum, string> SortSubfoldersOptionsEnumDictionary = new()
		{
			{SortSubfoldersOptionsEnum.YYYY_MMDD,"Date created; YYYY\\MMDD"},
			{SortSubfoldersOptionsEnum.YYYY_MM,"Date created; YYYY\\MM"},
			{SortSubfoldersOptionsEnum.YYYY_MM_DD,"Date created; YYYY\\MM\\DD"},
		};
		public static readonly Dictionary<FileNamingOptionsEnum, string> FileNamingOptionsEnumDictionary = new()
		{
			{FileNamingOptionsEnum.Document_Name,"Document name"},
			{FileNamingOptionsEnum.document_name,"document name"},
			{FileNamingOptionsEnum.DOCUMENT_NAME,"DOCUMENT NAME"},
			{FileNamingOptionsEnum.SerialNumber1,"1 Digit Serial Number"},
			{FileNamingOptionsEnum.SerialNumber2,"2 Digit Serial Number"},
			{FileNamingOptionsEnum.SerialNumber3,"3 Digit Serial Number"},
			{FileNamingOptionsEnum.SerialNumber4,"4 Digit Serial Number"},
			{FileNamingOptionsEnum.SerialNumber5,"5 Digit Serial Number"},
			{FileNamingOptionsEnum.SerialNumber6,"6 Digit Serial Number"},
			{FileNamingOptionsEnum.SerialLetterabc,"Serial Letter (a, b, c...)"},
			{FileNamingOptionsEnum.SerialLetterABC,"Serial Letter (A, B, C...)"},
			{FileNamingOptionsEnum.mmddyy,"mmddyy (date)"},
			{FileNamingOptionsEnum.mmdd,"mmdd (date)"},
			{FileNamingOptionsEnum.yyyymmdd,"yyyymmdd (date)"},
			{FileNamingOptionsEnum.yymmdd,"yymmdd (date)"},
			{FileNamingOptionsEnum.yyddmm,"yyddmm (date)"},
			{FileNamingOptionsEnum.ddmmyy,"ddmmyy (date)"},
			{FileNamingOptionsEnum.ddmm,"ddmm (date)"},
			{FileNamingOptionsEnum.empty,"" },
		};

		public static readonly Dictionary<FileExtensionsEnum, string> FileExtensionsEnumDictionary = new()
		{
			{ FileExtensionsEnum.jpg, ".jpg" },
		};
	}
}