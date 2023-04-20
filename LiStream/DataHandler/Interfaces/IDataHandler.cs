using System.Linq.Expressions;

namespace LiStream.DataHandler.Interfaces
{
    public interface IDataHandler
    {
        IDataWriter Writer { get; }
        IDataReader Reader { get; }
    }
}