using Moq;

namespace LiStream.Tests
{
    [TestClass]
    public class InvokerTests
    {
        private Invoker _invoker;
        private Mock<ICommand> mockCommand;
        [TestInitialize]
        public void Init()
        {
            _invoker = new Invoker();
            mockCommand = new Mock<ICommand>();
        }
        
        [TestCleanup]
        public void Cleanup() {
            _invoker = null;
        }

        [TestMethod]
        public void TestExecuted_Success()
        {
            #region Arrange
            var mockCommandObject = mockCommand.Object;
            _invoker.SetCommand(mockCommandObject);
            #endregion

            #region Act
            _invoker.Execute();
            #endregion

            #region Assert
            mockCommand.Verify(m => m.Execute(), Times.Once());
            mockCommand.Verify(m => m.Undo(), Times.Never());
            #endregion
        }

        [TestMethod]
        public void TestUndo_Success()
        {
            #region Arrange
            var mockCommandObject = mockCommand.Object;
            _invoker.SetCommand(mockCommandObject);
            #endregion

            #region Act
            _invoker.Undo();
            #endregion

            #region Assert
            mockCommand.Verify(m => m.Execute(), Times.Never);
            mockCommand.Verify(m => m.Undo(), Times.Once);
            #endregion
        }

    }
}