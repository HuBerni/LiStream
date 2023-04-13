using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler.Interfaces
{
    public interface IDataReader
    {
        T ReadFirstData<T>(Expression<Func<T, bool>> expression) where T : class;
        IEnumerable<T> ReadData<T>(Expression<Func<T, bool>> expression) where T : class;
    }
}
