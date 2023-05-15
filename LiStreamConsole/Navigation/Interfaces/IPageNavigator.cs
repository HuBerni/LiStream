using LiStream.Displayables;
using LiStream.Displayables.Interfaces;

namespace LiStreamConsole.Navigation.Interfaces
{
    public interface IPageNavigator
    {
        
        MenuOption GetNavigationOption(IDisplayablePage page, ICursorNavigator cursorNavigator);
        IDisplayablePage GetPageToNavigateTo(IDisplayablePage page, MenuOption menuOption);
    }
}
