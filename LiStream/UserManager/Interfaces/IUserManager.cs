using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.UserManager.Interfaces
{
    public interface IUserManager
    {
        string? UserName { get; }
        string? Email { get; }

        void Logout();
        bool ChangePassword(string oldPassword, string newPassword);
    }
}
