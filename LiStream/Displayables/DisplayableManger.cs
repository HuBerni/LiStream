using LiStream.DataHandler.Interfaces;
using LiStream.Displayables.Interfaces;

namespace LiStream.Displayables
{
    public class DisplayableManger : IDisplayableManger
    {
        private IDictionary<MainMenuOptions, IDisplayablePage> _pageMap;
        private IDictionary<MainMenuOptions, Func<IList<IDisplayable>>> _displayableMethodsMap;

        public DisplayableManger(IDictionary<MainMenuOptions, IDisplayablePage> pageMap, IDataHandler dataHandler)
        {
            _pageMap = pageMap;

            _displayableMethodsMap = new Dictionary<MainMenuOptions, Func<IList<IDisplayable>>>
            {
                { MainMenuOptions.Main, () => new List<IDisplayable>() },
                { MainMenuOptions.Back, () => new List<IDisplayable>() },
                { MainMenuOptions.Songs, () => dataHandler.GetSongs().Cast<IDisplayable>().ToList() },
                { MainMenuOptions.Playlists, () => dataHandler.GetPlaylists().Cast<IDisplayable>().ToList() },
                { MainMenuOptions.Artists, () => dataHandler.GetArtistProfiles().Cast<IDisplayable>().ToList() },
                { MainMenuOptions.Albums, () => dataHandler.GetAlbums().Cast<IDisplayable>().ToList() }
            };
        }


        public IDisplayablePage GetDisplayable(IDisplayablePage page, MainMenuOptions option)
        {
            if(option == MainMenuOptions.Back)
                return page.GetNavigateBackPage();

            page = _pageMap[option];
            page.SetDisplayables(_displayableMethodsMap[option].Invoke());

            return page;
        }

        public MainMenuOptions GetPageMenuOption(IDisplayablePage page)
        {
            foreach (var item in _pageMap)
            {
                if (item.Value == page)
                    return item.Key;
            }

            return MainMenuOptions.StayCurrent;
        }
    }
}
