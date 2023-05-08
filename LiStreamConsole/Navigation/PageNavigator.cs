using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation.Interfaces;

namespace LiStreamConsole.Navigation
{
    public class PageNavigator : IPageNavigator
    {
        private IDictionary<IDisplayablePage, IDisplayablePage> _backMap;

        public PageNavigator(IDictionary<IDisplayablePage, IDisplayablePage> backMap)
        {
            _backMap = backMap;
        }

        public MainMenuOptions GetNavigationOption(IDisplayablePage page, ICursorNavigator cursorNavigator)
        {
            return page.GetSelectedMenuOption();
        }

        public IDisplayablePage GetPageToNavigateTo(IDisplayablePage page, MainMenuOptions menuOption)
        {
            if (menuOption == MainMenuOptions.Back)
            {
                return _backMap[page];
            }

            return null;
        }
    }
}
