using LiStream.DataHandler.Interfaces;
using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole;
using LiStreamConsole.Displayables;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class ConsoleMenu2
{
   
    private ConsoleKeyInfo _keyInfo;

    private IDisplayableManger _displayableManager;
    private IDisplayablePage _currentPage;
    private ICursorNavigator _cursorNavigator;
    private IPageNavigator _pageNavigator;

    public ConsoleMenu2(IDisplayableManger displayableManager, ICursorNavigator cursorNavigator, IPageNavigator pageNavigator)
    {
        _displayableManager = displayableManager;
        _cursorNavigator = cursorNavigator;
        _pageNavigator = pageNavigator;
        Console.CursorVisible = false;
    }

    public void MainMenu()
    {
           
        MainMenuOptions option = MainMenuOptions.Main;
        
        do
        {
            _currentPage = _displayableManager.GetDisplayable(_currentPage, option);
            _currentPage.Display();
            option = _displayableManager.GetPageMenuOption(_currentPage);

            var newOption = MenuInput();

            if (newOption != MainMenuOptions.StayCurrent)
                option = newOption;

            if (option == MainMenuOptions.Exit)
                break;

            Console.Clear();
        } while (true);
    }

    private MainMenuOptions MenuInput()
    {
        _keyInfo = Console.ReadKey(false);

        if (_keyInfo.Key == ConsoleKey.Enter)
        {
            var pageOption = _pageNavigator.GetNavigationOption(_currentPage, _cursorNavigator);
            
            if (pageOption == MainMenuOptions.StayCurrent)
            {

            }

            _cursorNavigator.Reset();
            _cursorNavigator.SetCursorColumn(CursorColumn.Left);

            return pageOption;
        }

        _cursorNavigator.HandleKeyEntry(_keyInfo, _currentPage);
        _currentPage.Display();

        return MainMenuOptions.StayCurrent;
    }
}
