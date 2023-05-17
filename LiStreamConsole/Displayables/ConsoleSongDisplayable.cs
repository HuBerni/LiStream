using LiStream.Commands;
using LiStream.Commands.Interfaces;
using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;

namespace LiStreamConsole.Displayables
{
    public class ConsoleSongDisplayable : ConsoleDisplayable, IDisplayablePage
    {
        private IList<IDisplayable> _displayables;
        private IList<string> _songOptions = new List<string>();
        private IDictionary<int, MenuOption> _songActions = new Dictionary<int, MenuOption>();
        private readonly IMusicPlayer _musicPlayer = new MusicPlayer();

        public ConsoleSongDisplayable(ICursorNavigator cursorNavigator, IPageNavigator pageNavigator) : base(cursorNavigator, pageNavigator)
        {
            _songActions.Add(0, MenuOption.Play);
            _songActions.Add(1, MenuOption.Restart);
            _songActions.Add(2, MenuOption.Next);
            _songActions.Add(3, MenuOption.Previous);
            _songActions.Add(4, MenuOption.GetSimilar);
        }

        public void Display()
        {
            List<string> names = new();

            foreach (var item in _displayables)
            {
                if (item.IsPlaying())
                { 
                    names.Add($">> {item.GetDisplayableName()}");
                    continue;
                }
                  
                names.Add(item.GetDisplayableName());
            }

            PrintLeftMenu(names, "Songs");
            if (CursorNavigator.GetCursorRowForColumn(CursorColumn.Left) >= _displayables.Count)
                return;

            _songOptions = new List<string>()
                {
                    _displayables[CursorNavigator.GetCursorRowForColumn(CursorColumn.Left)].IsPlaying() ? "Pause" : "Play",
                    "Restart",
                    "Next",
                    "Previous",
                    "Get Similar",
                };

            PrintMiddleMenu(_songOptions, "Song Options");

            if (_displayables[CursorNavigator.GetCursorRowForColumn(CursorColumn.Left)]?.GetAdditionalInformation().Count > 0)
            {
                List<string> additinalInfo = new();

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
            if(CursorNavigator.GetCursorColumn() == CursorColumn.Left)
                return _displayables.Count;

            return _displayables[0].GetAdditionalInformation().Count - 1;
        }

        public MenuOption GetSelectedMenuOption()
        {
            if (CursorNavigator.GetCursorColumn() == CursorColumn.Middle)
                return _songActions[CursorNavigator.GetCursorRowForColumn(CursorColumn.Middle)];

            return CursorNavigator.GetCursorRowForColumn(CursorColumn.Left) >= _displayables.Count ? MenuOption.Back : MenuOption.StayCurrent; 
        }

        public void SetDisplayables(IList<IDisplayable> displayables)
        {
            _displayables = displayables;
        }
    }
}
