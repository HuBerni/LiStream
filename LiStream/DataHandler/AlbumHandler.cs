using LiStream.DataHandler.Interfaces;
using LiStream.Playables.Interfaces;
using LiStreamData.DTO;

namespace LiStream.DataHandler
{
    public class AlbumHandler : IDataItemHandler<IAlbum, AlbumDto>
    {
        private readonly IDataHandler _dataHandler;

        public AlbumHandler(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public IList<IAlbum> GetAll()
        {
            return _dataHandler.GetAlbums();
        }

        public IAlbum Get(Guid id)
        {
            return _dataHandler.GetAlbum(id);
        }

        public bool Create(AlbumDto albumDto)
        {
            return _dataHandler.CreateAlbum(albumDto);
        }

        public bool Update(AlbumDto albumDto)
        {
            return _dataHandler.UpdateAlbum(albumDto);
        }

        public bool Delete(Guid id)
        {
            return _dataHandler.DeleteAlbum(id);
        }

        public IList<IAlbum> GetAlbumsByArtist(Guid artistId)
        {
            return _dataHandler.GetAlbumsByArtist(artistId);
        }
    }
}
