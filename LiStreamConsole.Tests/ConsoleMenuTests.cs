using LiStream.Displayables.Interfaces;
using LiStreamConsole.Input.Interfaces;
using LiStreamConsole.Navigation.Interfaces;
using Moq;

namespace LiStreamConsole.Tests
{
    [TestClass]
    public class ConsoleMenuTests
    {
        private ConsoleMenu _consoleMenu;
        private Mock<IDisplayableManager> _displayableManagerMock;
        private Mock<ICursorNavigator> _cursorNavigatorMock;
        private Mock<IPageNavigator> _pageNavigatorMock;
        private Mock<IDisplayableDataRetriever> _dataRetrieverMock;
        private Mock<IDisplayablePage> _displayablePageMock;
        private Mock<IInputHandler> _inputHandlerMock;

        [TestInitialize]
        public void Init()
        {
            _displayableManagerMock = new Mock<IDisplayableManager>();
            _cursorNavigatorMock = new Mock<ICursorNavigator>();
            _pageNavigatorMock = new Mock<IPageNavigator>();
            _dataRetrieverMock = new Mock<IDisplayableDataRetriever>();
            _displayablePageMock = new Mock<IDisplayablePage>();
            _inputHandlerMock = new Mock<IInputHandler>();

            _consoleMenu = new ConsoleMenu(
                _displayableManagerMock.Object,
                _cursorNavigatorMock.Object,
                _pageNavigatorMock.Object,
                _dataRetrieverMock.Object,
                _inputHandlerMock.Object
            );
        }

        [TestCleanup]
        public void Cleanup()
        {
            _consoleMenu = null;
            _displayableManagerMock = null;
            _pageNavigatorMock = null;
            _cursorNavigatorMock = null;
            _dataRetrieverMock = null;
        }
    }
}