using LiStream.Commands;
using LiStream.DataHandler;
using LiStream.DtoHandler;
using LiStream.Evaluator;
using LiStream.Playables;
using LiStream.Playables.Interfaces;
using LiStreamConsole;
using LiStreamData.DTO;
using LiStreamEF;
using System.Reflection;

var factory = new LiStreamContextFactory();
var context = factory.CreateDbContext(args);

var dataHandler = new DataHandler(new DataWriter(context), new DataReader(context), new DtoHandler(), new Evaluator());

var menu = new ConsoleMenu(dataHandler, new MusicPlayerInvoker());
menu.MainMenu();