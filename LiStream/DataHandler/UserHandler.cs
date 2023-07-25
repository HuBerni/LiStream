using LiStream.DataHandler.Interfaces;
using LiStream.User.Interfaces.Profile;
using LiStreamData.DTO;

namespace LiStream.DataHandler
{
    public class UserHandler : IDataItemHandler<IUserProfile, UserDto>
    {
        private readonly IDataHandler _dataHandler;

        public UserHandler(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public bool Create(UserDto dto)
        {
            return _dataHandler.CreateUser(dto);
        }

        public bool Delete(Guid id)
        {
            return _dataHandler.DeleteUser(id);
        }

        public IUserProfile Get(Guid id)
        {
            return _dataHandler.GetUserProfile(id);
        }

        public IList<IUserProfile> GetAll()
        {
            return _dataHandler.GetUserProfiles();
        }

        public IUserProfile GetUserByEmail(string email)
        {
            return _dataHandler.GetUserByEmail(email);
        }

        public bool Update(UserDto dto)
        {
            return _dataHandler.UpdateUserProfile(dto);
        }
    }
}
