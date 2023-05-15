using LiStream.DataHandler.Interfaces;
using LiStream.Displayables.Interfaces;

namespace LiStream.Displayables
{
    public class DisplayableManger : IDisplayableManager
    {
        private IDictionary<MenuOption, IDisplayablePage> _pageMap;

        public DisplayableManger(IDictionary<MenuOption, IDisplayablePage> pageMap, IDataHandler dataHandler)
        {
            _pageMap = pageMap;
        }


        public IDisplayablePage GetDisplayablePage(IDisplayablePage page, MenuOption option)
        {
            if(option == MenuOption.Back)
                return page.GetNavigateBackPage();

            page = _pageMap[option];

            return page;
        }

        public MenuOption GetPageMenuOption(IDisplayablePage page)
        {
            foreach (var item in _pageMap)
            {
                if (item.Value == page)
                    return item.Key;
            }

            return MenuOption.StayCurrent;
        }
    }
}
