using LiStream.DataHandler;
using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStream.DtoHandler;
using LiStream.Evaluator;
using LiStream.Playables.Interfaces;
using LiStream.User.Interfaces.Profile;
using LiStreamConsole.Displayables;
using LiStreamConsole.Navigation;
using LiStreamEF;

var factory = new LiStreamContextFactory();
var context = factory.CreateDbContext(args);

var dataHandler = new DataHandler(new DataWriter(context), new DataReader(context), new DtoHandler(), new Evaluator());
var menuOptions = new Dictionary<MenuOption, IDisplayablePage>();
var backMap = new Dictionary<IDisplayablePage, IDisplayablePage>();
var cursorNavigator = new CursorNavigator();
var pageNavigator = new PageNavigator(backMap);

var mainMenu = new ConsoleMainMenuDisplayable(cursorNavigator, pageNavigator);
var songsMenu = new ConsoleSongDisplayable(cursorNavigator, pageNavigator);
var playlistsMenu = new ConsolePlaylistDisplayable(cursorNavigator, pageNavigator);
var artistsMenu = new ConsoleArtistDisplayable(cursorNavigator, pageNavigator);
var albumsMenu = new ConsoleAlbumDisplayable(cursorNavigator, pageNavigator);

backMap.Add(mainMenu, songsMenu);
backMap.Add(songsMenu, mainMenu);
backMap.Add(playlistsMenu, mainMenu);
backMap.Add(artistsMenu, mainMenu);
backMap.Add(albumsMenu, mainMenu);

menuOptions.Add(MenuOption.Main, mainMenu);
menuOptions.Add(MenuOption.Songs, songsMenu);
menuOptions.Add(MenuOption.Playlists, playlistsMenu);
menuOptions.Add(MenuOption.Artists, artistsMenu);
menuOptions.Add(MenuOption.Albums, albumsMenu);

var displayAllMethodMap = new Dictionary<MenuOption, Func<IList<IDisplayable>>>
{
    { MenuOption.Main, () => new List<IDisplayable>() },
    { MenuOption.Back, () => new List<IDisplayable>() },
    { MenuOption.Songs, () => dataHandler.GetSongs().OfType<IDisplayable>().ToList() },
    { MenuOption.Playlists, () => dataHandler.GetPlaylists().OfType<IDisplayable>().ToList() },
    { MenuOption.Artists, () => dataHandler.GetArtistProfiles().OfType<IDisplayable>().ToList() },
    { MenuOption.Albums, () => dataHandler.GetAlbums().OfType<IDisplayable>().ToList() }
};

var displayableMethodsMap = new Dictionary<MenuOption, Func<IDisplayable, IList<IDisplayable>>>
{
    { MenuOption.Songs, displayable =>
        displayable switch
        {
            IPlaylist playlist => dataHandler.GetPlaylistSongs(playlist.Id).OfType<IDisplayable>().ToList(),
            IAlbum album => dataHandler.GetAlbumSongs(album.Id).OfType<IDisplayable>().ToList(),
            IArtistProfile artist => dataHandler.GetArtistSongs(artist.Id).OfType<IDisplayable>().ToList(),
            _ => new List<IDisplayable>()
        }
    },
    { MenuOption.Albums, displayable =>
        displayable switch
        {
          IArtistProfile artist => dataHandler.GetArtistAlbums(artist.Id).OfType<IDisplayable>().ToList(),
          _ => new List<IDisplayable>()
        }
    }
};

var displayableSimilarMethodMap = new Dictionary<MenuOption, Func<IDisplayable, IList<IDisplayable>>>
{
    { MenuOption.Songs, displayable => dataHandler.GetSimilarList((ISong)displayable).Cast<IDisplayable>().ToList() },
    { MenuOption.Artists, displayable => dataHandler.GetSimilarList((IArtistProfile)displayable).Cast<IDisplayable>().ToList() },
};

var menu = new ConsoleMenu(
    new DisplayableManger(menuOptions, dataHandler),
    cursorNavigator,
    pageNavigator,
    new DisplayableDataRetriever(displayAllMethodMap, displayableMethodsMap, displayableSimilarMethodMap));

menu.MainMenu();