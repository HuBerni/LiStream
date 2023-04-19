
using LiStream.DataHandler;
using LiStreamEF;

var factory = new LiStreamContextFactory();

var handler = new DataHandler(new DbDataWriter(factory.CreateDbContext(args)), new DbDataReader(factory.CreateDbContext(args)));

//var x = handler.Reader.GetSong(new Guid("67027542-9DD8-46EC-9D02-44DE5BBCC944"));
var y = handler.Reader.GetArtistAlbums(new Guid("92788247-575A-4363-8EAC-68CD54FC0D6A"));

Console.ReadLine();