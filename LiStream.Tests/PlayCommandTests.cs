namespace LiStream.Tests
{
    [TestClass]
    public class PlayCommandTests
    {
        private PlayCommand _playCommand;
        private Mock<IPlayable> _playableMock;

        [TestInitialize]
        public void Init()
        {
            _playableMock = new Mock<IPlayable>();
            _playCommand = new PlayCommand(_playableMock.Object);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _playCommand = null;
            _playableMock = null;
        }

        [TestMethod]
        public void TestExecuted_Success()
        {
            #region Arrange
            #endregion

            #region Act
            _playCommand.Execute();
            #endregion

            #region Assert
            _playableMock.Verify(p => p.Play(), Times.Once());
            #endregion
        }

        [TestMethod]
        public void TestUndo_Success()
        {
            #region Arrange
            #endregion

            #region Act
            _playCommand.Execute();
            _playCommand.Undo();
            #endregion

            #region Assert
            _playableMock.Verify(p => p.Pause(), Times.Once());
            #endregion
        }
    }
}
