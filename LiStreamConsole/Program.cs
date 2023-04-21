using LiStream.DataHandler;
using LiStream.DtoHandler;
using LiStreamEF;

var factory = new LiStreamContextFactory();
var context = factory.CreateDbContext(args);

var dataHandler = new DataHandler(new DataWriter(context), new DataReader(context), new DtoHandler());

//var song = dataHandler.GetSong(new Guid("67027542-9DD8-46EC-9D02-44DE5BBCC944"));
//var album = dataHandler.GetAlbum(new Guid("BC70BD89-5857-4736-9A14-B0481E8B4784"));
//var playlist = dataHandler.GetPlaylist(new Guid("F2D33C7C-4C83-4262-BD18-4CFDE968E6CA"));
//var artist = dataHandler.GetArtistProfile(new Guid("92788247-575A-4363-8EAC-68CD54FC0D6A"));
//var user = dataHandler.GetUserProfile(new Guid("C3FAAEFD-1C97-41E6-A78A-EBC00B390418"));


Console.ReadKey();