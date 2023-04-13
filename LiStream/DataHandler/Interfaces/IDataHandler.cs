using System.Linq.Expressions;

namespace LiStream.DataHandler.Interfaces
{
    public interface IDataHandler
    {
        bool Create<T>(IEnumerable<T> obj);
        bool Create<T>(T obj);
        bool Delete<T>(T obj);
        IEnumerable<T> Get<T>(Expression<Func<T, bool>>? expression = null) where T : class;
        T GetSingle<T>(Expression<Func<T, bool>>? expression) where T : class;
        bool Update<T>(T obj);
    }
}