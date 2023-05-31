using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Displayables;
using LiStreamConsole.Input.Interfaces;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;

public class ConsoleMenu
{
    private IDisplayableManager _displayableManager;
    private IDisplayablePage _currentPage;
    private ICursorNavigator _cursorNavigator;
    private IPageNavigator _pageNavigator;
    private IDisplayableDataRetriever _dataRetriever;
    private IInputHandler _inputHandler;

    public ConsoleMenu(IDisplayableManager displayableManager, ICursorNavigator cursorNavigator, IPageNavigator pageNavigator, IDisplayableDataRetriever dataRetriever, IInputHandler inputHandler)
    {
        _displayableManager = displayableManager;
        _cursorNavigator = cursorNavigator;
        _pageNavigator = pageNavigator;
        _dataRetriever = dataRetriever;
        _inputHandler = inputHandler;

        _inputHandler.OnEnterKeyInput += ProcessPageOption;

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

            option = _inputHandler.HandleInput(_pageNavigator, _currentPage, _cursorNavigator);

            if (option == MenuOption.Exit)
                break;

            Console.Clear();
        } while (true);
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