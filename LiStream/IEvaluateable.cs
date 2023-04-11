using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream
{
    public interface IEvaluateable<T>
    {
        T getSimilar();
        T getSimilarList();
    }
}
