using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStream.Playables.Interfaces;
using LiStreamConsole.Displayables;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;
using System;

public class ConsoleMenu
{
    private ConsoleKeyInfo _keyInfo;

    private IDisplayableManager _displayableManager;
    private IDisplayablePage _currentPage;
    private ICursorNavigator _cursorNavigator;
    private IPageNavigator _pageNavigator;
    private IDisplayableDataRetriever _dataRetriever;

    public ConsoleMenu(IDisplayableManager displayableManager, ICursorNavigator cursorNavigator, IPageNavigator pageNavigator, IDisplayableDataRetriever dataRetriever)
    {
        _displayableManager = displayableManager;
        _cursorNavigator = cursorNavigator;
        _pageNavigator = pageNavigator;
        _dataRetriever = dataRetriever;
        Console.CursorVisible = false;
    }

    public void MainMenu()
    {
        var option = MenuOption.Main;

        do
        {
            if (option != MenuOption.StayCurrent)
            {
                _currentPage = _displayableManager.GetDisplayablePage(_currentPage, option);
                _currentPage.SetDisplayables(_dataRetriever.GetDisplayables(option));
            }

            _currentPage.Display();

            option = MenuInput();

            if (option == MenuOption.Exit)
                break;

            Console.Clear();
        } while (true);
    }

    private MenuOption MenuInput()
    {
        _keyInfo = Console.ReadKey(false);

        if (_keyInfo.Key == ConsoleKey.Enter)
        {
            var pageOption = _pageNavigator.GetNavigationOption(_currentPage, _cursorNavigator);

            if (pageOption == MenuOption.StayCurrent)
            {
                if (_cursorNavigator.GetCursorColumn() == CursorColumn.Left && _currentPage is ConsoleSongDisplayable songPage)
                {
                    songPage.PlayPauseSong(_cursorNavigator.GetCursorRowForColumn(CursorColumn.Left));
                    NavigateToPage(MenuOption.Songs);
                }

                pageOption = MenuOption.StayCurrent;
            }

            if (pageOption == MenuOption.GetSimilar)
            {
                GetSimilar();
                pageOption = MenuOption.StayCurrent;
            }

            _cursorNavigator.Reset();
            _cursorNavigator.SetCursorColumn(CursorColumn.Left);

            return pageOption;
        }

        _cursorNavigator.HandleKeyEntry(_keyInfo, _currentPage);
        _currentPage.Display();

        return MenuOption.StayCurrent;
    }

    private void NavigateToPage(MenuOption pageOption)
    {
        var displayables = _currentPage.GetDisplayables();

        if (displayables[_cursorNavigator.GetCursorRowForColumn(_cursorNavigator.GetCursorColumn())] is IPlayableCollection playableCollection)
        {
            _currentPage = _displayableManager.GetDisplayablePage(_currentPage, pageOption);
            _currentPage.SetDisplayables(_dataRetriever.GetDisplayables(pageOption, (IDisplayable)playableCollection));
        }
    }

    private void GetSimilar()
    {
        var displayable = _currentPage.GetDisplayables()[_cursorNavigator.GetCursorRowForColumn(CursorColumn.Left)];
        _currentPage.SetDisplayables(_dataRetriever.GetSimilar(_displayableManager.GetPageMenuOption(_currentPage), displayable));
    }
}
