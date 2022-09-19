
namespace PCSU.Repositories
{
	using PCSU.Models;

	public class PhotoRepository
	{

		private readonly Dictionary<int, Photo> _photos = new();
		int _id = 0;

		public void AddPhoto(Photo photo)
		{
			this._photos[photo.Id] = photo;
			this._id++;
		}

		public Photo GetPhoto(int photoId)
		{
			return this._photos[photoId];
		}

		public void RemovePhoto(int photoId)
		{
			throw new NotImplementedException();
		}

		public int GetCurrentId()
		{
			return this._id;
		}
	}
}