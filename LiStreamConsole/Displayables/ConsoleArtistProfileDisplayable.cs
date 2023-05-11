using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiStreamConsole.Displayables
{
    public class ConsoleArtistProfileDisplayable : ConsoleDisplayable, IDisplayablePage
    {
        private IDisplayable _artist;

        private List<string> _artistMenuOptions = new List<string>();
        private Dictionary<int, MenuOptions> _artistMenuActions = new Dictionary<int, MenuOptions>();

        public ConsoleArtistProfileDisplayable(ICursorNavigator cursorNavigator, IPageNavigator pageNavigator) : base(cursorNavigator, pageNavigator)
        {
            _artistMenuOptions.Add("Songs");
            _artistMenuOptions.Add("Albums");
            _artistMenuOptions.Add("Get Similar");

            _artistMenuActions.Add(0, MenuOptions.Songs);
            _artistMenuActions.Add(1, MenuOptions.Albums);
            _artistMenuActions.Add(2, MenuOptions.GetSimilar);
        }

        public void Display()
        {
            PrintLeftMenu(_artistMenuOptions, "Artist");

            if (_artist?.GetAdditionalInformation().Count > 0)
            {
                List<string> additinalInfo = new();

                foreach (var item in _artist.GetAdditionalInformation())
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
            if (_artist.GetAdditionalInformation().Count > 0)
            {
                return 2;
            }

            return 1;
        }

        public IList<IDisplayable> GetDisplayables()
        {
            return new List<IDisplayable>() { _artist };
        }

        public IDisplayablePage GetNavigateBackPage()
        {
            return PageNavigator.GetPageToNavigateTo(this, MenuOptions.Back);
        }

        public int GetRows()
        {
            return _artistMenuOptions.Count;
        }

        public MenuOptions GetSelectedMenuOption()
        {
            return _artistMenuActions[CursorNavigator.GetCursorRowForColumn(CursorColumn.Middle)];
        }

        public void SetDisplayables(IList<IDisplayable> displayables)
        {
            _artist = displayables[0];
        }
    }
}
