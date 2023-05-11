using LiStream.DataHandler;
using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStream.DtoHandler;
using LiStream.Evaluator;
using LiStreamConsole.Displayables;
using LiStreamConsole.Navigation;
using LiStreamEF;

var factory = new LiStreamContextFactory();
var context = factory.CreateDbContext(args);

var dataHandler = new DataHandler(new DataWriter(context), new DataReader(context), new DtoHandler(), new Evaluator());
var menuOptions = new Dictionary<MenuOptions, IDisplayablePage>();
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

menuOptions.Add(MenuOptions.Main, mainMenu);
menuOptions.Add(MenuOptions.Songs, songsMenu);
menuOptions.Add(MenuOptions.Playlists, playlistsMenu);
menuOptions.Add(MenuOptions.Artists, artistsMenu);
menuOptions.Add(MenuOptions.Albums, albumsMenu);

var menu = new ConsoleMenu(new DisplayableManger(menuOptions, dataHandler), cursorNavigator, pageNavigator, new DisplayableDataRetriever(dataHandler));
menu.MainMenu();