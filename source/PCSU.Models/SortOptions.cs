namespace PCSU.Models
{

	public static class DestinationOptions
	{
		public enum DestinationOptionsEnum
		{
			SaveInSameLocation = 10,
			SaveInNewLocation = 20,
		}

		public static readonly Dictionary<DestinationOptionsEnum, string> DestinationOptionsEnumDictionary = new()
		{
			{DestinationOptionsEnum.SaveInSameLocation,"Save in same location"},
			{DestinationOptionsEnum.SaveInNewLocation,"Save in new location"},
		};
	}
}
