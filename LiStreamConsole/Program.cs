using LiStream.Commands;
using LiStream.DataHandler;
using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStream.DtoHandler;
using LiStream.Evaluator;
using LiStream.Playables;
using LiStream.Playables.Interfaces;
using LiStreamConsole;
using LiStreamConsole.Displayables;
using LiStreamConsole.Navigation;
using LiStreamData.DTO;
using LiStreamEF;
using System.Reflection;

var factory = new LiStreamContextFactory();
var context = factory.CreateDbContext(args);

var dataHandler = new DataHandler(new DataWriter(context), new DataReader(context), new DtoHandler(), new Evaluator());
var menuOptions = new Dictionary<MainMenuOptions, IDisplayablePage>();
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

menuOptions.Add(MainMenuOptions.Main, mainMenu);
menuOptions.Add(MainMenuOptions.Songs, songsMenu);
menuOptions.Add(MainMenuOptions.Playlists, playlistsMenu);
menuOptions.Add(MainMenuOptions.Artists, artistsMenu);
menuOptions.Add(MainMenuOptions.Albums, albumsMenu);

var menu = new ConsoleMenu2(new DisplayableManger(menuOptions, dataHandler), cursorNavigator, pageNavigator);
menu.MainMenu();