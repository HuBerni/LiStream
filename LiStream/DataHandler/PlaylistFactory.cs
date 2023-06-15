using LiStream.DataHandler.Interfaces;
using LiStream.Playables.Interfaces;
using LiStreamData.DTO;

namespace LiStream.DataHandler
{
    public class PlaylistFactory : IDataFactory<IPlaylist, PlaylistDto>
    {
        private readonly IDataHandler _dataHandler;

        public PlaylistFactory(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public bool Create(PlaylistDto dto)
        {
            return _dataHandler.CreatePlaylist(dto);
        }

        public bool Delete(Guid id)
        {
            return _dataHandler.DeletePlaylist(id);
        }

        public IPlaylist Get(Guid id)
        {
            return _dataHandler.GetPlaylist(id);
        }

        public IList<IPlaylist> GetAll()
        {
            return _dataHandler.GetPlaylists();
        }

        public bool Update(PlaylistDto dto)
        {
            return _dataHandler.UpdatePlaylist(dto);
        }
    }
}
