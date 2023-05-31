using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation.Interfaces;

namespace LiStreamConsole.Input.Interfaces
{
    public interface IInputHandler
    {
        MenuOption HandleInput(IPageNavigator pageNavigator, IDisplayablePage currentPage, ICursorNavigator cursorNavigator);
        delegate MenuOption HandleEnterKeyEventHandler(MenuOption option);
        event HandleEnterKeyEventHandler OnEnterKeyInput;
    }
}
