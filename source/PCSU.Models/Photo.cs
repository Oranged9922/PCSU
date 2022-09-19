namespace PCSU.Models
{
	public class Photo
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Path { get; set; } = string.Empty;
		public DateTime DateTaken { get; set; }
		public DateTime DateModified { get; set; }

		public override string ToString() => Path;
		public List<(string name, object value)> GetPropertiesList()
		{
			return new()
			{
				("Id",Id),
				("Name",Name),
				("Path",Path),
				("DateTaken",DateTaken),
				("DateModified",DateModified)
			};
		}
	}
}