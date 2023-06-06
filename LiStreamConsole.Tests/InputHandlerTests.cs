using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Input;
using LiStreamConsole.Navigation.Interfaces;
using LiStreamConsole.Wrapper.Interfaces;

namespace LiStreamConsole.Tests
{
    [TestClass]
    public class InputHandlerTests
    {
        private Mock<IPageNavigator> _mockPageNavigator;
        private Mock<ICursorNavigator> _mockCursorNavigator;
        private Mock<IDisplayablePage> _mockCurrentPage;
        private Mock<IConsoleWrapper> _mockConsoleWrapper;

        private InputHandler _inputHandler;

        [TestInitialize]
        public void Init()
        {
            _mockPageNavigator = new Mock<IPageNavigator>();
            _mockCursorNavigator = new Mock<ICursorNavigator>();
            _mockCurrentPage = new Mock<IDisplayablePage>();
            _mockConsoleWrapper = new Mock<IConsoleWrapper>();

            _inputHandler = new InputHandler(_mockConsoleWrapper.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _mockPageNavigator = null;
            _mockCursorNavigator = null;
            _mockCurrentPage = null;
            _mockConsoleWrapper = null;
            _inputHandler = null;
        }

        [TestMethod]
        public void HandleInput_NonEnterInput_ReturnsStayCurrent()
        {
            #region Arrange
            _mockConsoleWrapper.Setup(x => x.ReadKey()).Returns(new ConsoleKeyInfo((char)ConsoleKey.DownArrow, ConsoleKey.DownArrow, false, false, false));
            #endregion

            #region Act
            var actualOption = _inputHandler.HandleInput(_mockPageNavigator.Object, _mockCurrentPage.Object, _mockCursorNavigator.Object);
            #endregion

            #region Assert
            Assert.AreEqual(MenuOption.StayCurrent, actualOption);
            #endregion
        }

        [TestMethod]
        public void HandleInput_EnterInput_ExecutesGetNavigationOption()
        {
            #region Arrange
            _mockConsoleWrapper.Setup(x => x.ReadKey(It.IsAny<bool>())).Returns(new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false));
            #endregion

            #region Act
            _inputHandler.HandleInput(_mockPageNavigator.Object, _mockCurrentPage.Object, _mockCursorNavigator.Object);
            #endregion

            #region Assert
            _mockPageNavigator.Verify(x => x.GetNavigationOption(_mockCurrentPage.Object, _mockCursorNavigator.Object), Times.Once);
            #endregion
        }

        [TestMethod]
        public void HandleInput_ReturnsBack_WhenEnterKeyIsPressedAndPageNavigationIsBack()
        {
            #region
            _mockPageNavigator.Setup(x => x.GetNavigationOption(_mockCurrentPage.Object, _mockCursorNavigator.Object)).Returns(MenuOption.Back);
            _mockConsoleWrapper.Setup(x => x.ReadKey(It.IsAny<bool>())).Returns(new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false));
            #endregion

            #region Act
            var result = _inputHandler.HandleInput(_mockPageNavigator.Object, _mockCurrentPage.Object, _mockCursorNavigator.Object);
            #endregion

            #region Assert
            Assert.AreEqual(result, MenuOption.Back);
            #endregion
        }

        [TestMethod]
        public void HandleInput_ReturnsBack_WhenEnterKeyIsPressedAndPageNavigationIsPageOption()
        {
            #region
            _mockPageNavigator.Setup(x => x.GetNavigationOption(_mockCurrentPage.Object, _mockCursorNavigator.Object)).Returns(MenuOption.Songs);
            _mockConsoleWrapper.Setup(x => x.ReadKey(It.IsAny<bool>())).Returns(new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false));
            #endregion

            #region Act
            var result = _inputHandler.HandleInput(_mockPageNavigator.Object, _mockCurrentPage.Object, _mockCursorNavigator.Object);
            #endregion

            #region Assert
            Assert.AreEqual(result, MenuOption.Songs);
            #endregion
        }

        [TestMethod]
        public void HandleInput_ShouldCallOnEnterKeyInputEvent_IfEventExists()
        {
            #region Arrange
            var eventCalled = false;
            _inputHandler.OnEnterKeyInput += (MenuOption m) => { eventCalled = true; return m; };
            _mockConsoleWrapper.Setup(x => x.ReadKey(It.IsAny<bool>())).Returns(new ConsoleKeyInfo((char)ConsoleKey.Enter, ConsoleKey.Enter, false, false, false));
            #endregion

            #region Act
            _inputHandler.HandleInput(_mockPageNavigator.Object, _mockCurrentPage.Object, _mockCursorNavigator.Object);
            #endregion

            #region Assert
            Assert.IsTrue(eventCalled);
            #endregion
        }

        [TestMethod]
        public void HandleInput_NonEnterInput_ShouldCallHandleKeyEntry()
        {
            #region Arrange
            _mockConsoleWrapper.Setup(x => x.ReadKey()).Returns(new ConsoleKeyInfo((char)ConsoleKey.DownArrow, ConsoleKey.DownArrow, false, false, false));
            #endregion

            #region Act
            _inputHandler.HandleInput(_mockPageNavigator.Object, _mockCurrentPage.Object, _mockCursorNavigator.Object);
            #endregion

            #region Assert
            _mockCursorNavigator.Verify(x => x.HandleKeyEntry(It.IsAny<ConsoleKeyInfo>(), _mockCurrentPage.Object), Times.Once);
            #endregion
        }
    }
}
