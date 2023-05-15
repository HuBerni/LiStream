using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStream.Displayables.Interfaces
{
    public interface IDisplayableDataRetriever
    {
        IList<IDisplayable> GetDisplayables(MenuOption option);
        IList<IDisplayable> GetDisplayables(MenuOption option, IDisplayable displayable);
        IList<IDisplayable> GetSimilar(MenuOption option, IDisplayable displayable);
    }
}
