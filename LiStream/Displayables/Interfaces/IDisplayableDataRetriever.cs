using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Displayables.Interfaces
{
    public interface IDisplayableDataRetriever
    {
        IList<IDisplayable> GetDisplayables(MenuOptions option);
        IList<IDisplayable> GetDisplayables(MenuOptions option, IDisplayable displayable);
        IList<IDisplayable> GetSimilar(IDisplayable displayable);
    }
}
