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
        private Dictionary<int, MenuOptions> _mainMenuActions = new Dictionary<int, MenuOptions>();
        

        public ConsoleMainMenuDisplayable(ICursorNavigator cursorNavigator, IPageNavigator pageNavigator) : base(cursorNavigator, pageNavigator)
        {
            _mainMenuOptions.Add("Songs");
            _mainMenuOptions.Add("Playlists");
            _mainMenuOptions.Add("Artists");
            _mainMenuOptions.Add("Albums");
            _mainMenuOptions.Add("Exit");

            _mainMenuActions.Add(0, MenuOptions.Songs);
            _mainMenuActions.Add(1, MenuOptions.Playlists);
            _mainMenuActions.Add(2, MenuOptions.Artists);
            _mainMenuActions.Add(3, MenuOptions.Albums);
            _mainMenuActions.Add(4, MenuOptions.Exit);
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
            return null;
        }

        public IDisplayablePage GetNavigateBackPage()
        {
            return PageNavigator.GetPageToNavigateTo(this, MenuOptions.Back);
        }

        public int GetRows()
        {
            return _mainMenuOptions.Count;
        }

        public MenuOptions GetSelectedMenuOption()
        {
            return _mainMenuActions[CursorNavigator.GetCursorRowForColumn(CursorColumn.Middle)];
        }

        public void SetDisplayables(IList<IDisplayable> displayables)
        {
        }
    }
}
