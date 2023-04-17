using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.User.Interfaces.Profile
{
    public interface IProfile
    {
        Guid Id { get; }
        string DisplayName { get; }
        string Email { get; }
    }
}
