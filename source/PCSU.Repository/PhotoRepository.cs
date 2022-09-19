
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
			_photos.Remove(photoId);
			var editedkvp = _photos.Where(x => x.Value.Id > photoId).ToList();
			editedkvp.ForEach(x => x.Value.Id--);
			_photos.Remove(--_id);
			editedkvp.ForEach(x => _photos[x.Key - 1] = x.Value);
		}

		public int GetCurrentId()
		{
			return this._id;
		}
	}
}