
using LiStream.DataHandler;
using LiStream.Playables;
using LiStream.User;
using LiStreamEF;

var factory = new LiStreamContextFactory();

var handler = new DataHandler(new DbDataWriter(factory.CreateDbContext(args)), new DbDataReader(factory.CreateDbContext(args)));

//var x = handler.Reader.GetSong(new Guid("67027542-9DD8-46EC-9D02-44DE5BBCC944"));
//var x = handler.Reader.GetArtistAlbums(new Guid("92788247-575A-4363-8EAC-68CD54FC0D6A"));
var user = handler.Reader.GetUser(new Guid("C3FAAEFD-1C97-41E6-A78A-EBC00B390418"));
//handler.Writer.InsertUser(new User(Guid.NewGuid(), null, null, null, "LX", "lx@xl.lx"));
handler.Writer.InsertSongToPlaylist(new Guid("BFBB037C-B7B2-4A8B-A71C-CBA4C97C380C")
    ,new Guid("1689D42D-0E9E-472E-86CE-407B56AE3FCB")
    ,new Guid( "C3FAAEFD-1C97-41E6-A78A-EBC00B390418"));

Console.ReadLine();