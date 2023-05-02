using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamConsole
{
    public enum MainMenuOptions
    {
        Songs,
        Playlists,
        Artists,
        Albums,
        Exit,
    }

    public enum SongMenuOptions
    {
        Idle,
        Play,
        Pause,
        Restart,
        AddToPlaylist,
        GoToArtist,
        GetSimilar,
        GoToAlbum,
        GoBack
    }
}
