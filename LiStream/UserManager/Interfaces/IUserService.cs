using LiStream.User.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.UserManager.Interfaces
{
    public interface IUserService
    {
        string UserName { get; }
        string Email { get; }
        
        IUser LoginUser(string username, string password);
        IArtistUser LoginArtist(string username, string password);
        IUser RegisterUser(string username, string password);
        IArtistUser RegisterArtist(string username, string password);
    }
}
