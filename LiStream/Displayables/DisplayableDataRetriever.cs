using LiStream.DataHandler.Interfaces;
using LiStream.Displayables.Interfaces;
using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Displayables
{
    public class DisplayableDataRetriever : IDisplayableDataRetriever
    {
        private IDictionary<MenuOptions, Func<IList<IDisplayable>>> _displayableMethodsMap;
        private IDataHandler _dataHandler;

        public DisplayableDataRetriever(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;

            _displayableMethodsMap = new Dictionary<MenuOptions, Func<IList<IDisplayable>>>
            {
                { MenuOptions.Main, () => new List<IDisplayable>() },
                { MenuOptions.Back, () => new List<IDisplayable>() },
                { MenuOptions.Songs, () => dataHandler.GetSongs().OfType<IDisplayable>().ToList() },
                { MenuOptions.Playlists, () => dataHandler.GetPlaylists().OfType<IDisplayable>().ToList() },
                { MenuOptions.Artists, () => dataHandler.GetArtistProfiles().OfType<IDisplayable>().ToList() },
                { MenuOptions.Albums, () => dataHandler.GetAlbums().OfType<IDisplayable>().ToList() }
            };
        }

        public IList<IDisplayable> GetDisplayables(MenuOptions option)
        {
            return _displayableMethodsMap[option].Invoke();
        }

        public IList<IDisplayable> GetDisplayables(MenuOptions option, IDisplayable displayable)
        {
            if (displayable is IArtistProfile artist && option == MenuOptions.Songs)
            {
                return _dataHandler.GetSongs().Where(x => x.Artist.Id == artist.Id).Cast<IDisplayable>().ToList();
            }
            else if (displayable is IArtistProfile artistProfile && option == MenuOptions.Albums)
            {
                return _dataHandler.GetArtistAlbums(artistProfile.Id).Cast<IDisplayable>().ToList();
            }

            if (displayable is IAlbum album)
            {
                return _dataHandler.GetAlbumSongs(album.Id).OfType<IDisplayable>().ToList();
            }

            if (displayable is IPlaylist playlist)
            {
                return _dataHandler.GetPlaylistSongs(playlist.Id).OfType<IDisplayable>().ToList();
            }

            return new List<IDisplayable>();
        }

        public IList<IDisplayable> GetSimilar(IDisplayable displayable)
        {
            switch (displayable)
            {
                case ISong song:
                    IList<ISong> similarSongs = _dataHandler.GetSimilarList(song);
                    return similarSongs.Cast<IDisplayable>().ToList();
                case IArtistProfile artist:
                    IList<IArtistProfile> similarArtists = _dataHandler.GetSimilarList(artist);
                    return similarArtists.Cast<IDisplayable>().ToList();
                case IPlayableCollection collection:
                    IList<IPlayableCollection> similarCollections = _dataHandler.GetSimilarList(collection);
                    return similarCollections.Cast<IDisplayable>().ToList();
                default:
                    return new List<IDisplayable>();
            }
        }

    }
}
