using LiStream.DataHandler;
using LiStream.DataHandler.DBDataHandler;
using LiStream.DataHandler.Interfaces;
using LiStreamEF;
using LiStreamEF.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

var factory = new LiStreamContextFactory();
//IDataHandler dataHandler = new DataHandler(new DBDataWriter(factory.CreateDbContext(args)), new DBDataReader(factory.CreateDbContext(args)));

//var artists = dataHandler.Get<Artist>().ToList();
//var singleArtist = dataHandler.GetSingle<Artist>(x => x.Name.Contains("L"));

//var uid = dataHandler.GetSingle<User>(u => u.Name == "Berni").UserId;


//var album = context.Albums
//    .Where(a => a.Name == "Meteora")
//    .Include(s => s.Songs)
//    .ThenInclude(a => a.Genres)
//    .Include(a => a.ArtistNavigation)
//    .FirstOrDefault();

//var playlist = context.Playlists
//    .Where(p => p.Name == "Random")
//    .Include(p => p.PlaylistItems)
//    .ThenInclude(s => s.Song)
//    .ThenInclude(a => a.Album)
//    .FirstOrDefault();


//var favCollections = context.UserFollowedPlayableCollections
//    .Where(f => f.UserId == uid)
//    .Include(p => p.Playlist)
//    .ThenInclude(p => p.PlaylistItems)
//    .ThenInclude(s => s.Song)
//    .ThenInclude(a => a.Album)
//    .Include(a => a.Album)
//    .ToList();
