using LiStream.DataHandler.Interfaces;
using LiStream.Playables.Interfaces;
using LiStreamData.DTO;

namespace LiStream.DataHandler
{
    public class SongHandler : IDataItemHandler<ISong, SongDto>
    {
        private readonly IDataHandler _dataHandler;

        public SongHandler(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public bool Create(SongDto dto)
        {
            return _dataHandler.CreateSong(dto);
        }

        public bool Delete(Guid id)
        {
            return _dataHandler.DeleteSong(id);
        }

        public ISong Get(Guid id)
        {
            return _dataHandler.GetSong(id);
        }

        public IList<ISong> GetAll()
        {
            return _dataHandler.GetSongs();
        }

        public bool Update(SongDto dto)
        {
            return _dataHandler.UpdateSong(dto);
        }

        public IList<ISong> GetSongsByAlbum(Guid albumId)
        {
            return _dataHandler.GetSongsByAlbum(albumId);
        }

        public IList<ISong> GetSongsByArtist(Guid artistId)
        {
            return _dataHandler.GetSongsByArtist(artistId);
        }

        public IList<ISong> GetSongsByPlaylist(Guid playlistId)
        {
            return _dataHandler.GetSongsByPlaylist(playlistId);
        }

        public IList<ISong> GetUsersFavouriteSongs(Guid userId)
        {
            return _dataHandler.GetUsersFavouriteSongs(userId);
        }

        public bool InsertSongToAlbum(Guid songId, Guid albumId)
        {
            return _dataHandler.InsertSongToAlbum(songId, albumId);
        }

        public bool InsertSongToPlaylist(Guid songId, Guid playlistId, Guid userId)
        {
            return _dataHandler.InsertSongToPlaylist(songId, playlistId, userId);
        }

        public bool InsertSongToUserFavorites(Guid songId, Guid userId)
        {
            return _dataHandler.InsertSongToUserFavorites(songId, userId);
        }

        public bool DeleteSongFromAlbum(Guid id)
        {
            return _dataHandler.DeleteSongFromAlbum(id);
        }

        public bool DeleteSongFromPlaylist(Guid songId, Guid playlistId)
        {
            return _dataHandler.DeleteSongFromPlaylist(songId, playlistId);
        }
    }
}
