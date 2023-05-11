using LiStream.DataHandler.Interfaces;
using LiStream.Displayables.Interfaces;

namespace LiStream.Displayables
{
    public class DisplayableManger : IDisplayableManger
    {
        private IDictionary<MenuOptions, IDisplayablePage> _pageMap;

        public DisplayableManger(IDictionary<MenuOptions, IDisplayablePage> pageMap, IDataHandler dataHandler)
        {
            _pageMap = pageMap;
        }


        public IDisplayablePage GetDisplayablePage(IDisplayablePage page, MenuOptions option)
        {
            if(option == MenuOptions.Back)
                return page.GetNavigateBackPage();

            page = _pageMap[option];

            return page;
        }

        public MenuOptions GetPageMenuOption(IDisplayablePage page)
        {
            foreach (var item in _pageMap)
            {
                if (item.Value == page)
                    return item.Key;
            }

            return MenuOptions.StayCurrent;
        }
    }
}
