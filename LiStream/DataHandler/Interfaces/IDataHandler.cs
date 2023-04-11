using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler.Interfaces
{
    public interface IDataHandler
    {
        bool Create<T>(T obj);
        T Get<T>(Guid id);
        bool Update<T>(T obj);
        bool Delete<T>(Guid id);
    }
}
