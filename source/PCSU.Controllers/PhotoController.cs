
namespace PCSU.Controllers
{
	using PCSU.Models;
	using PCSU.Repositories;
	public class PhotoController
	{
		private readonly PhotoRepository _photoRepository = new();
		public Photo GetPhoto(int photoId)
		{
			return this._photoRepository.GetPhoto(photoId);
		}

		public void LoadPhotos(string[] filePaths, out List<string> errMsg, out bool isErr)
		{
			isErr = false;
			errMsg = new();
			foreach (string? filePath in filePaths)
			{
				try
				{
					LoadPhoto(filePath);
				}
				catch (Exception e)
				{
					isErr = true;
					errMsg.Add(filePath + "\nreason: " + e.Message);
				}
			}
		}

		public void LoadPhoto(string filePath)
		{
			FileInfo photoInfo = new(filePath);
			var p = new Photo()
			{
				Id = this._photoRepository.GetCurrentId(),
				DateTaken = photoInfo.CreationTime,
				Name = photoInfo.Name,
				Path = photoInfo.FullName,
				DateModified = photoInfo.LastWriteTime,
				Extension = photoInfo.Extension
			};
			if (_photoRepository.IsDuplicate(p, out string duplicateWith)) {
				throw new Exception($"Duplicate with {duplicateWith}");
			}
			this._photoRepository.AddPhoto(p);
			;
		}

		public void RemovePhoto(Photo photo)
		{
			this._photoRepository.RemovePhoto(photo.Id);
		}

		public List<Photo> GetAllPhotos()
		{
			List<Photo> r = new();
			for (int i = 0; i < this._photoRepository.GetCurrentId(); i++)
			{
				r.Add(this._photoRepository.GetPhoto(i));
			}
			return r;
		}
	}
}