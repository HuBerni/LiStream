using LiStream.User.Interfaces;
using LiStream.UserManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.UserManager
{
    public class UserManager : IUserManager, IUserService
    {
        public string UserName { get; private set; }

        public string Email { get; private set; }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public IArtistUser LoginArtist(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IUser LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public IArtistUser RegisterArtist(string username, string password)
        {
            throw new NotImplementedException();
        }

        public IUser RegisterUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
