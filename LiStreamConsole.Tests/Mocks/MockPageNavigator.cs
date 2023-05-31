using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamConsole.Tests.Mocks
{
    public class MockPageNavigator : IPageNavigator
    {
        public MenuOption GetNavigationOption(IDisplayablePage page, ICursorNavigator cursorNavigator)
        {
            throw new NotImplementedException();
        }

        public IDisplayablePage GetPageToNavigateTo(IDisplayablePage page, MenuOption menuOption)
        {
            throw new NotImplementedException();
        }
    }
}
