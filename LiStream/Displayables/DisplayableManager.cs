using LiStream.DataHandler.Interfaces;
using LiStream.Displayables.Interfaces;

namespace LiStream.Displayables
{
    public class DisplayableManager : IDisplayableManager
    {
        private IDictionary<MenuOption, IDisplayablePage> _pageMap;

        public DisplayableManager(IDictionary<MenuOption, IDisplayablePage> pageMap)
        {
            _pageMap = pageMap;
        }


        public IDisplayablePage GetDisplayablePage(IDisplayablePage page, MenuOption option)
        {
            if(option == MenuOption.Back)
                return page.GetNavigateBackPage();

            try
            {
                page = _pageMap[option];
            }
            catch (Exception)
            {

            }

            return page;
        }

        public MenuOption GetPageMenuOption(IDisplayablePage page)
        {
            foreach (var item in _pageMap)
            {
                if (item.Value.GetType() == page.GetType())
                    return item.Key;
            }

            return MenuOption.StayCurrent;
        }
    }
}
