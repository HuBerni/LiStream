using LiStream.Displayables;
using LiStream.Displayables.Interfaces;

namespace LiStreamConsole.Navigation.Interfaces
{
    public interface IPageNavigator
    {
        
        MainMenuOptions GetNavigationOption(IDisplayablePage page, ICursorNavigator cursorNavigator);
        IDisplayablePage GetPageToNavigateTo(IDisplayablePage page, MainMenuOptions menuOption);
    }
}
