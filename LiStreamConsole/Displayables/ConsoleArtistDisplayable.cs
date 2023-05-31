using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;

namespace LiStreamConsole.Displayables
{
    internal class ConsoleArtistDisplayable : ConsoleDisplayable, IDisplayablePage
    {
        private IList<IDisplayable> _displayables;
        private IList<string> _artistOptions = new List<string>();
        private IDictionary<int, MenuOption> _artistActions;

        public ConsoleArtistDisplayable(ICursorNavigator cursorNavigator, IPageNavigator pageNavigator) : base(cursorNavigator, pageNavigator)
        {
            _artistActions = new Dictionary<int , MenuOption>()
            {
                { 0, MenuOption.Songs },
                { 1, MenuOption.Albums },
                { 2, MenuOption.GetSimilar }
            };
        }

        public void Display()
        {
            List<string> names = new();

            foreach (var item in _displayables)
            {
                names.Add(item.GetDisplayableName());
            }

            PrintLeftMenu(names, "Artists");
            if (CursorNavigator.GetCursorRowForColumn(Navigation.CursorColumn.Left) >= _displayables.Count)
                return;

            if (_displayables[CursorNavigator.GetCursorRowForColumn(CursorColumn.Left)]?.GetAdditionalInformation().Count > 0)
            {
                List<string> additinalInfo = new();


                if (CursorNavigator.GetCursorRowForColumn(CursorColumn.Left) >= _displayables.Count)
                    return;

                _artistOptions = new List<string>()
                {
                    "Songs",
                    "Albums",
                    "Get Similar"
                };

                PrintMiddleMenu(_artistOptions, "Artist Options");


                foreach (var item in _displayables[CursorNavigator.GetCursorRowForColumn(CursorColumn.Left)].GetAdditionalInformation())
                {
                    additinalInfo.Add($"{item.Header}: {item.Information}");
                }

                PrintRightMenu(additinalInfo, "Info");
            }
        }

        public int GetColumns()
        {
            return 3;
        }

        public int GetColumsForItem(int index)
        {
            if (_displayables[index].GetAdditionalInformation().Count > 0)
            {
                return 3;
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

            if (CursorNavigator.GetCursorColumn() == CursorColumn.Middle)
                return _artistOptions.Count -1;

            return _displayables[0].GetAdditionalInformation().Count - 1
                ;
        }

        public MenuOption GetSelectedMenuOption()
        {
            if (CursorNavigator.GetCursorColumn() == CursorColumn.Middle)
                return _artistActions[CursorNavigator.GetCursorRowForColumn(CursorColumn.Middle)];

            return CursorNavigator.GetCursorRowForColumn(Navigation.CursorColumn.Left) >= _displayables.Count ? MenuOption.Back : MenuOption.StayCurrent;
        }

        public void SelectedAction(MenuOption pageOption, int selectedIndex)
        {
        }

        public void SetDisplayables(IList<IDisplayable> displayables)
        {
            _displayables = displayables;
        }
        public string Title()
        {
            return "Console Artists";
        }
    }
}
