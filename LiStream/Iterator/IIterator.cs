using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Iterator
{
    public interface IIterator<T>
    {
        T First();
        T Next();
        bool IsDone();
        T CurrentItem();
    }
}
