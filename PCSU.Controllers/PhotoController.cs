using PCSU.Models;
using PCSU.Repositories;

namespace PCSU.Controllers
{
    public class PhotoController
    {
        PhotoRepository photoRepository = new();
        public Photo GetPhoto(int photoId)
        {
            return photoRepository.GetPhoto(photoId);
        }

        public void LoadPhotos(string[] filePaths, out List<string> errMsg, out bool isErr)
        {
            isErr = false;
            errMsg = new();
            foreach (var filePath in filePaths)
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

             photoRepository.AddPhoto(new()
                {
                Id = photoRepository.GetCurrentId(),
                DateTaken = photoInfo.CreationTime,
                Name = photoInfo.Name,
                Path = photoInfo.FullName,
                DateModified = photoInfo.LastWriteTime
            });
        }

        public List<Photo> GetAllPhotos()
        {
            List<Photo> r = new();
            for (int i = 0; i < photoRepository.GetCurrentId(); i++)
            {
                r.Add(photoRepository.GetPhoto(i));
            }
            return r;
        }
    }
}