using LiStream.DataHandler.Interfaces;
using LiStream.User.Interfaces.Profile;
using LiStreamData.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler
{
    public class ArtistHandler : IDataItemHandler<IArtistProfile, ArtistDto>
    {
        private readonly IDataHandler _dataHandler;

        public ArtistHandler(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public bool Create(ArtistDto dto)
        {
            return _dataHandler.CreateArtist(dto);
        }

        public bool Delete(Guid id)
        {
            return _dataHandler.DeleteArtist(id);
        }

        public IArtistProfile Get(Guid id)
        {
            return _dataHandler.GetArtistProfile(id);
        }

        public IList<IArtistProfile> GetAll()
        {
            return _dataHandler.GetArtistProfiles();
        }

        public bool Update(ArtistDto dto)
        {
            return _dataHandler.UpdateArtist(dto);
        }
    }
}
