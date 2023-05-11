using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation.Interfaces;
using System.Runtime.CompilerServices;

namespace LiStreamConsole.Navigation
{
    public class PageNavigator : IPageNavigator
    {
        private IDictionary<IDisplayablePage, IDisplayablePage> _backMap;

        public PageNavigator(IDictionary<IDisplayablePage, IDisplayablePage> backMap)
        {
            _backMap = backMap;
        }

        public MenuOptions GetNavigationOption(IDisplayablePage page, ICursorNavigator cursorNavigator)
        {
            return page.GetSelectedMenuOption();
        }

        public IDisplayablePage GetPageToNavigateTo(IDisplayablePage page, MenuOptions menuOption)
        {
            if (menuOption == MenuOptions.Back)
            {
                return _backMap[page];
            }

            return null;
        }
    }
}
