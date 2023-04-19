using LiStream.DataHandler.Interfaces;
using LiStream.Playables.Interfaces;
using LiStream.User;
using LiStream.User.Interfaces.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler
{
    public class DataHandler : IDataHandler
    {
        public IDataWriter Writer { get; init; }

        public IDataReader Reader { get; init; }

        public DataHandler(IDataWriter writer, IDataReader reader)
        {
            Writer = writer;
            Reader = reader;
        }
    }
}
