using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;

namespace LiStreamConsole.Displayables
{
    internal class ConsolePlaylistDisplayable : ConsoleDisplayable, IDisplayablePage
    {
        private IList<IDisplayable> _displayables;

        public ConsolePlaylistDisplayable(ICursorNavigator cursorNavigator, IPageNavigator pageNavigator) : base(cursorNavigator, pageNavigator)
        {
        }

        public void Display()
        {
            List<string> names = new();

            foreach (var item in _displayables)
            {
                names.Add(item.GetDisplayableName());
            }

            PrintLeftMenu(names, "Playlists");
            if (CursorNavigator.GetCursorRowForColumn(Navigation.CursorColumn.Left) >= _displayables.Count)
                return;

            if (_displayables[CursorNavigator.GetCursorRowForColumn(Navigation.CursorColumn.Left)]?.GetAdditionalInformation().Count > 0)
            {
                List<string> additinalInfo = new();

                foreach (var item in _displayables[CursorNavigator.GetCursorRowForColumn(Navigation.CursorColumn.Left)].GetAdditionalInformation())
                {
                    additinalInfo.Add($"{item.Header}: {item.Information}");
                }

                PrintMiddleMenu(additinalInfo, "Info");
            }
        }

        public int GetColumns()
        {
            return 2;
        }

        public int GetColumsForItem(int index)
        {
            if (_displayables[index].GetAdditionalInformation().Count > 0)
            {
                return 2;
            }

            return 1;
        }

        public IList<IDisplayable> GetDisplayables()
        {
            return _displayables;
        }

        public IDisplayablePage GetNavigateBackPage()
        {
            return PageNavigator.GetPageToNavigateTo(this, MenuOption.Back);
        }

        public int GetRows()
        {
            if (CursorNavigator.GetCursorColumn() == CursorColumn.Left)
                return _displayables.Count;

            return _displayables[0].GetAdditionalInformation().Count - 1;
        }

        public MenuOption GetSelectedMenuOption()
        {
            return CursorNavigator.GetCursorRowForColumn(Navigation.CursorColumn.Left) >= _displayables.Count ? MenuOption.Back : MenuOption.StayCurrent;
        }

        public void SetDisplayables(IList<IDisplayable> displayables)
        {
            _displayables = displayables;
        }
    }
}
