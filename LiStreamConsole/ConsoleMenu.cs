using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStream.Playables.Interfaces;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;

public class ConsoleMenu
{
   
    private ConsoleKeyInfo _keyInfo;

    private IDisplayableManger _displayableManager;
    private IDisplayablePage _currentPage;
    private ICursorNavigator _cursorNavigator;
    private IPageNavigator _pageNavigator;
    private IDisplayableDataRetriever _dataRetriever;

    public ConsoleMenu(IDisplayableManger displayableManager, ICursorNavigator cursorNavigator, IPageNavigator pageNavigator, IDisplayableDataRetriever dataRetriever)
    {
        _displayableManager = displayableManager;
        _cursorNavigator = cursorNavigator;
        _pageNavigator = pageNavigator;
        _dataRetriever = dataRetriever;
        Console.CursorVisible = false;
    }

    public void MainMenu()
    {
        var option = MenuOptions.Main;
        
        do
        {
            if (option != MenuOptions.StayCurrent)
            { 
                _currentPage = _displayableManager.GetDisplayablePage(_currentPage, option);
                _currentPage.SetDisplayables(_dataRetriever.GetDisplayables(option));
            }
            
            _currentPage.Display();
            
            option = MenuInput();

            if (option == MenuOptions.Exit)
                break;

            Console.Clear();
        } while (true);
    }

    private MenuOptions MenuInput()
    {
        _keyInfo = Console.ReadKey(false);

        if (_keyInfo.Key == ConsoleKey.Enter)
        {
            var pageOption = _pageNavigator.GetNavigationOption(_currentPage, _cursorNavigator);
            
            if (pageOption == MenuOptions.StayCurrent)
            {
                if (_cursorNavigator.GetCursorColumn() == CursorColumn.Left)
                {
                    PlaySong();
                    NavigateToPage();
                }

                return MenuOptions.StayCurrent;
            }

            _cursorNavigator.Reset();
            _cursorNavigator.SetCursorColumn(CursorColumn.Left);

            return pageOption;
        }

        _cursorNavigator.HandleKeyEntry(_keyInfo, _currentPage);
        _currentPage.Display();

        return MenuOptions.StayCurrent;
    }

    private void PlaySong()
    {
        var displayables = _currentPage.GetDisplayables();

        foreach (var item in displayables.OfType<IPlayable>())
        {
            item.Pause();
        }

        if (displayables[_cursorNavigator.GetCursorRowForColumn(_cursorNavigator.GetCursorColumn())] is IPlayable playable)
        {
            playable.Play();
        }
    }

    private void NavigateToPage()
    {
        var displayables = _currentPage.GetDisplayables();

        if (displayables[_cursorNavigator.GetCursorRowForColumn(_cursorNavigator.GetCursorColumn())] is IPlayableCollection playableCollection)
        {
            _currentPage = _displayableManager.GetDisplayablePage(_currentPage, MenuOptions.Songs);
            _currentPage.SetDisplayables(_dataRetriever.GetDisplayables(MenuOptions.Songs, (IDisplayable)playableCollection));
        }
    }
}
