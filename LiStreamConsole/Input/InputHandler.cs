using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Input.Interfaces;
using LiStreamConsole.Navigation.Interfaces;
using LiStreamConsole.Wrapper.Interfaces;
using static LiStreamConsole.Input.Interfaces.IInputHandler;

namespace LiStreamConsole.Input
{
    public class InputHandler : IInputHandler
    {
        public event HandleEnterKeyEventHandler OnEnterKeyInput;

        private IConsoleWrapper _consoleWrapper;

        public InputHandler(IConsoleWrapper consoleWrapper)
        {
            _consoleWrapper = consoleWrapper;
        }

        public MenuOption HandleInput(IPageNavigator pageNavigator, IDisplayablePage currentPage, ICursorNavigator cursorNavigator)
        {
            var keyInfo = _consoleWrapper.ReadKey(false);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                var pageOption = pageNavigator.GetNavigationOption(currentPage, cursorNavigator);

                if (pageOption == MenuOption.Back)
                    return pageOption;

                pageOption = OnEnterKeyInput.Invoke(pageOption);

                return pageOption;
            }

            HandleNonEnterKeyInput(cursorNavigator, keyInfo, currentPage);

            return MenuOption.StayCurrent;
        }

        private void HandleNonEnterKeyInput(ICursorNavigator cursorNavigator, ConsoleKeyInfo keyInfo, IDisplayablePage currentPage)
        {
            cursorNavigator.HandleKeyEntry(keyInfo, currentPage);
            currentPage.Display();
        }
    }
}
