using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.DataHandler.Interfaces
{
    public interface IDataWriter
    {
        bool WriteData<T>(T obj);
        bool WriteData<T>(IEnumerable<T> obj);
        bool UpdateData<T>(T obj);
        bool DeleteData<T>(T obj);
    }
}
