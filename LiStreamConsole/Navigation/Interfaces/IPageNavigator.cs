using LiStream.Displayables;
using LiStream.Displayables.Interfaces;

namespace LiStreamConsole.Navigation.Interfaces
{
    public interface IPageNavigator
    {
        
        MenuOptions GetNavigationOption(IDisplayablePage page, ICursorNavigator cursorNavigator);
        IDisplayablePage GetPageToNavigateTo(IDisplayablePage page, MenuOptions menuOption);
    }
}
