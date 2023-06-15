using LiStream.DataHandler.Interfaces;
using LiStream.Playables.Interfaces;
using LiStreamData.DTO;

namespace LiStream.DataHandler
{
    public class SongFactory : IDataFactory<ISong, SongDto>
    {
        private readonly IDataHandler _dataHandler;

        public SongFactory(IDataHandler dataHandler)
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
    }
}
