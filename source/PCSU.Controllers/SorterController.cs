namespace PCSU.Controllers
{
	using PCSU.Models;

	public class SorterController
	{
		private string StoredSelectedFolderDestination { get; set; } = "C:\\PCSU\\";
		// return list of all destination options
		public List<string> GetAllDestinationOptions()
			=> DestinationOptions.DestinationOptionsEnumDictionary.Values.ToList();
		public bool IsSaveInSameLocationSelected(string? selectedItem)
		=> selectedItem == DestinationOptions.DestinationOptionsEnumDictionary[DestinationOptions.DestinationOptionsEnum.SaveInSameLocation];
		public string GetSelectedFolder() => StoredSelectedFolderDestination;
	}
}
