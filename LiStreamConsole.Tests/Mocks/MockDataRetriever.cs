using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamConsole.Tests.Mocks
{
    public class MockDataRetriever : IDisplayableDataRetriever
    {
        public IList<IDisplayable> GetDisplayables(MenuOption option)
        {
            throw new NotImplementedException();
        }

        public IList<IDisplayable> GetDisplayables(MenuOption option, IDisplayable displayable)
        {
            throw new NotImplementedException();
        }

        public IList<IDisplayable> GetSimilar(MenuOption option, IDisplayable displayable)
        {
            throw new NotImplementedException();
        }
    }
}
