using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamConsole.Tests.Mocks
{
    public class MockDisplayableManager : IDisplayableManager
    {
        public IDisplayablePage GetDisplayablePage(IDisplayablePage page, MenuOption option)
        {
            throw new NotImplementedException();
        }

        public MenuOption GetPageMenuOption(IDisplayablePage page)
        {
            throw new NotImplementedException();
        }
    }
}
