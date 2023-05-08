using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStream.Playables;
using LiStream.Playables.Interfaces;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;

namespace LiStreamConsole.Displayables
{
    public class ConsoleMainMenuDisplayable : ConsoleDisplayable, IDisplayablePage
    {
        private List<string> _mainMenuOptions = new List<string>();
        private Dictionary<int, MainMenuOptions> _mainMenuActions = new Dictionary<int, MainMenuOptions>();
        

        public ConsoleMainMenuDisplayable(ICursorNavigator cursorNavigator, IPageNavigator pageNavigator) : base(cursorNavigator, pageNavigator)
        {
            _mainMenuOptions.Add("Songs");
            _mainMenuOptions.Add("Playlists");
            _mainMenuOptions.Add("Artists");
            _mainMenuOptions.Add("Albums");
            _mainMenuOptions.Add("Exit");

            _mainMenuActions.Add(0, MainMenuOptions.Songs);
            _mainMenuActions.Add(1, MainMenuOptions.Playlists);
            _mainMenuActions.Add(2, MainMenuOptions.Artists);
            _mainMenuActions.Add(3, MainMenuOptions.Albums);
            _mainMenuActions.Add(4, MainMenuOptions.Exit);
        }

        public void Display()
        {
            CursorNavigator.SetCursorColumn(Navigation.CursorColumn.Middle);
            PrintMiddleMenu(_mainMenuOptions, "Main Menu");
        }

        public int GetColumns()
        {
            throw new NotImplementedException();
        }

        public int GetColunsForItem(int index)
        {

            return 1;
        }

        public IList<IDisplayable> GetDisplayables()
        {
            return null;
        }

        public IDisplayablePage GetNavigateBackPage()
        {
            return PageNavigator.GetPageToNavigateTo(this, MainMenuOptions.Back);
        }

        public int GetRows()
        {
            return _mainMenuOptions.Count;
        }

        public MainMenuOptions GetSelectedMenuOption()
        {
            return _mainMenuActions[CursorNavigator.GetCursorRowForColumn(Navigation.CursorColumn.Middle)];
        }

        public void SetDisplayables(IList<IDisplayable> displayables)
        {
        }
    }
}
