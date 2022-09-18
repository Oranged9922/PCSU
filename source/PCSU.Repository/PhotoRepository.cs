using PCSU.Models;

namespace PCSU.Repositories
{
    public class PhotoRepository
    {

        Dictionary<int, Photo> _photos = new();
        int _id = 0;


        public void AddPhoto(Photo photo)
        {
            _photos[photo.Id] = photo;
            _id++;
        }

        public Photo GetPhoto(int photoId)
        {
            return _photos[photoId];
        }

        public void RemovePhoto(int photoId)
        {
            throw new NotImplementedException();
        }

        public int GetCurrentId()
        {
            return _id;
        }
    }
}