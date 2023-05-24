using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Displayables;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;

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
                ResetCursorNavigator();
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

            if (pageOption == MenuOption.Back)
                return pageOption;

            pageOption = ProcessPageOption(pageOption);

            return pageOption;
        }

        HandleNonEnterKeyInput();

        return MenuOption.StayCurrent;
    }

    private MenuOption ProcessPageOption(MenuOption pageOption)
    {
        if (pageOption == MenuOption.GetSimilar)
        {
            GetSimilar();
            ResetCursorNavigator();
            return MenuOption.StayCurrent;
        }
        else if (_currentPage is ConsoleSongDisplayable)
        {
            _currentPage.SelectedAction(pageOption, _cursorNavigator.GetCursorRowForColumn(CursorColumn.Left));
            return MenuOption.StayCurrent;
        }
        else if (pageOption == MenuOption.StayCurrent && _cursorNavigator.GetCursorColumn() == CursorColumn.Left)
        {
            NavigateToPage(MenuOption.Songs);
            ResetCursorNavigator();
        }
        else if ((pageOption == MenuOption.Songs || pageOption == MenuOption.Albums) && _currentPage is ConsoleArtistDisplayable)
        {
            NavigateToPage(pageOption);
            ResetCursorNavigator();
            return MenuOption.StayCurrent;
        }

        return pageOption;
    }

    private void HandleNonEnterKeyInput()
    {
        _cursorNavigator.HandleKeyEntry(_keyInfo, _currentPage);
        _currentPage.Display();
    }

    private void ResetCursorNavigator()
    {
        _cursorNavigator.Reset();
        _cursorNavigator.SetCursorColumn(CursorColumn.Left);
    }

    private void NavigateToPage(MenuOption pageOption)
    {
        var displayable = _currentPage.GetDisplayables()[_cursorNavigator.GetCursorRowForColumn(_cursorNavigator.GetCursorColumn())];

        _currentPage = _displayableManager.GetDisplayablePage(_currentPage, pageOption);
        _currentPage.SetDisplayables(_dataRetriever.GetDisplayables(pageOption, displayable));
    }

    private void GetSimilar()
    {
        var displayable = _currentPage.GetDisplayables()[_cursorNavigator.GetCursorRowForColumn(CursorColumn.Left)];
        _currentPage.SetDisplayables(_dataRetriever.GetSimilar(_displayableManager.GetPageMenuOption(_currentPage), displayable));
    }
}