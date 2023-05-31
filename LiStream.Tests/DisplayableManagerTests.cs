using Moq;

namespace LiStream.Tests
{
    [TestClass]
    public class DisplayableManagerTests
    {
        private DisplayableManager _displayableManager;
        private IDictionary<MenuOption, IDisplayablePage> _pageMapMock;
        private Mock<IDisplayablePage> _mockDisplayablePageMain;
        private Mock<IDisplayablePage> _mockDisplayablePageSongs;
        private Mock<IDisplayablePage> _mockDisplayablePageArtists;
        private Mock<IDisplayablePage> _mockDisplayablePagePodcasts;

        [TestInitialize]
        public void Init()
        {
            _mockDisplayablePageMain = new Mock<IDisplayablePage>();
            _mockDisplayablePageSongs = new Mock<IDisplayablePage>();
            _mockDisplayablePageArtists = new Mock<IDisplayablePage>();
            _mockDisplayablePagePodcasts = new Mock<IDisplayablePage>();

            _pageMapMock = new Dictionary<MenuOption, IDisplayablePage>()
            {
                { MenuOption.Main, _mockDisplayablePageMain.Object },
                { MenuOption.Songs, _mockDisplayablePageSongs.Object },
                { MenuOption.Artists, _mockDisplayablePageArtists.Object}
            };

            _displayableManager = new DisplayableManager(_pageMapMock);
        }

        [TestCleanup] 
        public void Cleanup() 
        { 
            _displayableManager = null;
            _pageMapMock = null;
        }

        [TestMethod]
        public void GetDisplayablePage_ReturnsCorrectPage()
        {
            #region Arrange
            var pageMock = _mockDisplayablePageMain;
            _mockDisplayablePageSongs.Setup(m => m.Title()).Returns("Mock Songs");
            #endregion

            #region Act
            var result = _displayableManager.GetDisplayablePage(pageMock.Object, MenuOption.Songs);
            #endregion

            #region Assert
            Assert.AreEqual("Mock Songs", result.Title());
            #endregion
        }

        [TestMethod]
        public void GetDisplayablePage_ReturnBackValue()
        {
            #region Arrange
            _mockDisplayablePageSongs.Setup(m => m.Title()).Returns("Mock Songs");
            _mockDisplayablePageSongs.Setup(m => m.GetNavigateBackPage()).Returns(_mockDisplayablePageMain.Object);
            _mockDisplayablePageMain.Setup(m => m.Title()).Returns("Mock Main");
            #endregion

            #region Act
            var result = _displayableManager.GetDisplayablePage(_mockDisplayablePageSongs.Object, MenuOption.Back);
            #endregion

            #region Assert
            Assert.AreEqual("Mock Main", result.Title());
            #endregion
        }

        [TestMethod]
        public void GetPageMenuOption_ReturnsCorrectOption()
        {
            #region Arrange
            _mockDisplayablePageMain.Setup(m => m.GetSelectedMenuOption()).Returns(MenuOption.Main);
            #endregion

            #region Act
            var result = _displayableManager.GetPageMenuOption(_mockDisplayablePageMain.Object);
            #endregion

            #region Assert
            Assert.AreEqual(MenuOption.Main, result);
            #endregion
        }

        public void GetPageMenuOption_OptionNotInList()
        {
            #region Arrange
            _mockDisplayablePagePodcasts = new Mock<IDisplayablePage>();
            #endregion

            #region Act
            var result = _displayableManager.GetPageMenuOption(_mockDisplayablePagePodcasts.Object);
            #endregion

            #region Assert
            Assert.AreEqual(MenuOption.StayCurrent, result);
            #endregion
        }
    }
}
