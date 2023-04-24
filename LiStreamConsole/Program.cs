using LiStream.DataHandler;
using LiStream.DtoHandler;
using LiStream.Evaluator;
using LiStreamData.DTO;
using LiStreamEF;

var factory = new LiStreamContextFactory();
var context = factory.CreateDbContext(args);

var dataHandler = new DataHandler(new DataWriter(context), new DataReader(context), new DtoHandler(), new Evaluator());

var song = dataHandler.GetSong(new Guid("67027542-9DD8-46EC-9D02-44DE5BBCC944"));
//var album = dataHandler.GetAlbum(new Guid("BC70BD89-5857-4736-9A14-B0481E8B4784"));
//var artistAlbums = dataHandler.GetArtistAlbums(new Guid("92788247-575A-4363-8EAC-68CD54FC0D6A"));
//var playlist = dataHandler.GetPlaylist(new Guid("F2D33C7C-4C83-4262-BD18-4CFDE968E6CA"));
//var userPlaylists = dataHandler.GetUserPlaylists(new Guid("C3FAAEFD-1C97-41E6-A78A-EBC00B390418"));
//var artist = dataHandler.GetArtistProfile(new Guid("92788247-575A-4363-8EAC-68CD54FC0D6A"));
//var user = dataHandler.GetUserProfile(new Guid("C3FAAEFD-1C97-41E6-A78A-EBC00B390418"));
//var userFavs = dataHandler.GetFavoriteSongs(new Guid("C3FAAEFD-1C97-41E6-A78A-EBC00B390418"));
//var followedCollections = dataHandler.GetFollowedCollections(new Guid("C3FAAEFD-1C97-41E6-A78A-EBC00B390418"));

//byte[] data = { 0x00, 0x01, 0x02, 0x03, 0x04 };
//var songDto = new SongDto
//{
//    Name = "Insert",
//    Data = data,
//    Lenght = new TimeSpan(0, 0, 42),
//    Artist = new ArtistDto
//    {
//        Id = new Guid("92788247-575A-4363-8EAC-68CD54FC0D6A")
//    },
//};

//dataHandler.InsertSong(songDto);

var similarSong = dataHandler.GetSimilar(song);
var similarSongs = dataHandler.GetSimilarList(song);


Console.ReadKey();