
namespace PCSU.Repositories
{
	using PCSU.Models;
	using System;

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

		public bool IsDuplicate(Photo p, out string duplicateWith)
		{
			duplicateWith = String.Empty;
			Photo? inRepo = 
			_photos.Values.Where
			(x => x.DateTaken == p.DateTaken).FirstOrDefault();
			if (inRepo is null)
			{
				return false;
			}
			else
			{
				var fSizeNew = new System.IO.FileInfo(p.Path).Length;
				var fExisting = new System.IO.FileInfo(inRepo.Path).Length;
				if (fSizeNew == fExisting)
				{
					duplicateWith = inRepo.Path;
					return true;
				}
				return false;
			}

		}
	}
}