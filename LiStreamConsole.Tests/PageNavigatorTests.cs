using LiStream.Displayables;
using LiStream.Displayables.Interfaces;
using LiStreamConsole.Navigation;
using LiStreamConsole.Navigation.Interfaces;
using Moq;

namespace LiStreamTests.Navigation
{
    [TestClass]
    public class PageNavigatorTests
    {
        private PageNavigator _pageNavigator;
        private Mock<IDictionary<IDisplayablePage, IDisplayablePage>> _backMapMock;
        private Mock<ICursorNavigator> _cursorNavigatorMock;

        [TestInitialize]
        public void Initialize()
        {
            _backMapMock = new Mock<IDictionary<IDisplayablePage, IDisplayablePage>>();
            _cursorNavigatorMock = new Mock<ICursorNavigator>();
            _pageNavigator = new PageNavigator(_backMapMock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _pageNavigator = null;
            _backMapMock = null;
            _cursorNavigatorMock = null;
        }

        [TestMethod]
        public void GetNavigationOption_WithValidPage_ReturnsValidMenuOption()
        {
            #region Arrange
            var mockPage = new Mock<IDisplayablePage>();
            mockPage.Setup(x => x.GetSelectedMenuOption()).Returns(MenuOption.Main);
            #endregion

            #region Act
            var result = _pageNavigator.GetNavigationOption(mockPage.Object, _cursorNavigatorMock.Object);
            #endregion

            #region Assert
            Assert.AreEqual(MenuOption.Main, result);
            #endregion
        }

        [TestMethod]
        public void GetPageToNavigateTo_WithMenuOptionBack_ReturnsValidPage()
        {
            #region Arrange
            var mockPage = new Mock<IDisplayablePage>();
            var mockBackPage = new Mock<IDisplayablePage>();
            var menuOptionBack = MenuOption.Back;

            _backMapMock.Setup(x => x[mockPage.Object]).Returns(mockBackPage.Object);
            #endregion

            #region Act
            var result = _pageNavigator.GetPageToNavigateTo(mockPage.Object, menuOptionBack);
            #endregion

            #region Assert
            Assert.AreEqual(mockBackPage.Object, result);
            #endregion
        }

        [TestMethod]
        public void GetPageToNavigateTo_WithMenuOptionNotBack_ReturnsNull()
        {
            #region Arrange
            var mockPage = new Mock<IDisplayablePage>();
            var menuOption = MenuOption.Main;
            #endregion

            #region Act
            var result = _pageNavigator.GetPageToNavigateTo(mockPage.Object, menuOption);
            #endregion

            #region Assert
            Assert.IsNull(result);
            #endregion
        }
    }
}
