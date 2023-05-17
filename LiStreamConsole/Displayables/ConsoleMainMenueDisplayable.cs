using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;

namespace LiStreamConsole.Displayables
{
    public class ConsoleMainMenuDisplayable : ConsoleDisplayable, IDisplayablePage
    {
        private List<string> _mainMenuOptions = new List<string>();
        private Dictionary<int, MenuOption> _mainMenuActions = new Dictionary<int, MenuOption>();
        

        public ConsoleMainMenuDisplayable(ICursorNavigator cursorNavigator, IPageNavigator pageNavigator) : base(cursorNavigator, pageNavigator)
        {
            _mainMenuOptions.Add("Songs");
            _mainMenuOptions.Add("Playlists");
            _mainMenuOptions.Add("Artists");
            _mainMenuOptions.Add("Albums");
            _mainMenuOptions.Add("Exit");

            _mainMenuActions.Add(0, MenuOption.Songs);
            _mainMenuActions.Add(1, MenuOption.Playlists);
            _mainMenuActions.Add(2, MenuOption.Artists);
            _mainMenuActions.Add(3, MenuOption.Albums);
            _mainMenuActions.Add(4, MenuOption.Exit);
        }

        public void Display()
        {
            CursorNavigator.SetCursorColumn(CursorColumn.Middle);
            PrintMiddleMenu(_mainMenuOptions, "Main Menu");
        }

        public int GetColumns()
        {
            return 1;
        }

        public int GetColumsForItem(int index)
        {

            return 1;
        }

        public IList<IDisplayable> GetDisplayables()
        {
            return new List<IDisplayable>();
        }

        public IDisplayablePage GetNavigateBackPage()
        {
            return PageNavigator.GetPageToNavigateTo(this, MenuOption.Back);
        }

        public int GetRows()
        {
            return _mainMenuOptions.Count - 1;
        }

        public MenuOption GetSelectedMenuOption()
        {
            return _mainMenuActions[CursorNavigator.GetCursorRowForColumn(CursorColumn.Middle)];
        }

        public void SetDisplayables(IList<IDisplayable> displayables)
        {
        }
    }
}
