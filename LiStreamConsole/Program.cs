using LiStream.DataHandler;
using LiStream.DtoHandler;
using LiStream.Evaluator;
using LiStreamConsole;
using LiStreamData.DTO;
using LiStreamEF;
using System.Reflection;

var factory = new LiStreamContextFactory();
var context = factory.CreateDbContext(args);
var menu = new ConsoleMenu();

var dataHandler = new DataHandler(new DataWriter(context), new DataReader(context), new DtoHandler(), new Evaluator());

//var song = dataHandler.GetSong(new Guid("67027542-9DD8-46EC-9D02-44DE5BBCC944"));
//var album = dataHandler.GetAlbum(new Guid("BC70BD89-5857-4736-9A14-B0481E8B4784"));
//var artist = dataHandler.GetArtistProfile(new Guid("92788247-575A-4363-8EAC-68CD54FC0D6A"));
//var artistAlbums = dataHandler.GetArtistAlbums(artist.Id);
//var playlist = dataHandler.GetPlaylist(new Guid("F2D33C7C-4C83-4262-BD18-4CFDE968E6CA"));
//var user = dataHandler.GetUserProfile(new Guid("C3FAAEFD-1C97-41E6-A78A-EBC00B390418"));
//var userFavs = dataHandler.GetFavoriteSongs(user.Id);
//var followedCollections = dataHandler.GetFollowedCollections(user.Id);
//var userPlaylists = dataHandler.GetUserPlaylists(user.Id);

//var similarSong = dataHandler.GetSimilar(song);
//var similarSongs = dataHandler.GetSimilarList(song);

var allSongs = dataHandler.GetSongs();

MainMenuOptions mainMenuOption;

mainMenuOption = menu.MainMenu();

while (true)
{ 
    if (mainMenuOption == MainMenuOptions.Songs)
    {
        var selectedSong = menu.ShowSongs(allSongs);

        if (selectedSong is null)
        {
            mainMenuOption = menu.MainMenu();
            continue;
        }

        PrintObject(selectedSong);
    }

    if (mainMenuOption == MainMenuOptions.Exit)
        break;
}


Console.ReadKey();

static void PrintObject(object obj)
{
    Type type = obj.GetType();
    PropertyInfo[] properties = type.GetProperties();

    Console.WriteLine($"Printing properties for object of type {type.Name}:\n");
    foreach (PropertyInfo prop in properties)
    {
        object value = prop.GetValue(obj);

        if (value is null)
        {
            Console.WriteLine($"{prop.Name}: null");
            continue;
        }

        Console.WriteLine($"{prop.Name}: {value}");
    }

    Console.WriteLine();
}
