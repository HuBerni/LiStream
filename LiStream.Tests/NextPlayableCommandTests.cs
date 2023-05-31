using Moq;

namespace LiStream.Tests
{
    [TestClass]
    public class NextPlayableCommandTests
    {

        private NextPlayableCommand _nextPlayableCommand;


        [TestCleanup] 
        public void Cleanup()
        {
            _nextPlayableCommand = null;
        }

        [TestMethod]
        public void Execute_WhenIndexIsOutOfBounds()
        {
            #region Arange
            var playablesMock = new List<IPlayable>
            {
                CreateMockPlayable(false).Object,
                CreateMockPlayable(false).Object,
                CreateMockPlayable(true).Object,
            };

            _nextPlayableCommand = new NextPlayableCommand(playablesMock);
            #endregion

            #region Act
            _nextPlayableCommand.Execute();
            #endregion

            #region Assert
            Assert.IsTrue(playablesMock.Take(playablesMock.Count - 1).All(p => !p.IsPlaying));
            Assert.IsTrue(playablesMock.Last().IsPlaying);
            #endregion
        }

        [TestMethod]
        public void Execute_WhenIndexIsWithinBounds()
        {
            #region Arange
            var playablesMock = new List<IPlayable>
            {
                CreateMockPlayable(false).Object,
                CreateMockPlayable(true).Object,
                CreateMockPlayable(false).Object,
            };

            _nextPlayableCommand = new NextPlayableCommand(playablesMock);

            int currentlyPlayingIndex = playablesMock.FindIndex(x => x.IsPlaying);
            #endregion

            #region Act
            _nextPlayableCommand.Execute();
            #endregion

            #region Assert
            Assert.IsFalse(playablesMock[0].IsPlaying);
            Assert.IsFalse(playablesMock[1].IsPlaying);
            Assert.IsTrue(playablesMock[2].IsPlaying);
            #endregion
        }

        [TestMethod]
        public void Undo_WhenIndexIsOutOfBounds()
        {
            #region Arange
            var playablesMock = new List<IPlayable>
            {
                CreateMockPlayable(true).Object,
                CreateMockPlayable(false).Object,
                CreateMockPlayable(false).Object,
            };

            _nextPlayableCommand = new NextPlayableCommand(playablesMock);
            #endregion

            #region Act
            _nextPlayableCommand.Undo();
            #endregion

            #region Assert
            Assert.IsTrue(playablesMock.First().IsPlaying);
            Assert.IsTrue(playablesMock.Skip(1).All(p => !p.IsPlaying));
            #endregion
        }

        [TestMethod]
        public void Undo_WhenIndexIsWithinBounds()
        {
            #region Arange
            var playablesMock = new List<IPlayable>
            {
                CreateMockPlayable(false).Object,
                CreateMockPlayable(true).Object,
                CreateMockPlayable(false).Object,
            };

            _nextPlayableCommand = new NextPlayableCommand(playablesMock);

            int currentlyPlayingIndex = playablesMock.FindIndex(x => x.IsPlaying);
            #endregion

            #region Act
            _nextPlayableCommand.Undo();
            #endregion

            #region Assert
            for (int i = 0; i < playablesMock.Count; i++)
            {
                if (i != currentlyPlayingIndex - 1)
                {
                    Assert.IsFalse(playablesMock[i].IsPlaying);
                }
            }

            Assert.IsTrue(playablesMock[currentlyPlayingIndex - 1].IsPlaying);
            #endregion
        }

        [TestMethod]
        public void Execute_NoPlayableIsPlaying()
        {
            #region Arange
            var playablesMock = new List<IPlayable>
            {
                CreateMockPlayable(false).Object,
                CreateMockPlayable(false).Object,
                CreateMockPlayable(false).Object,
            };

            _nextPlayableCommand = new NextPlayableCommand(playablesMock);
            #endregion

            #region Act
            _nextPlayableCommand.Execute();
            #endregion

            #region Assert
            Assert.IsFalse(playablesMock.Any(x => x.IsPlaying));
            #endregion
        }

        [TestMethod]
        public void Undo_NoPlayableIsPlaying()
        {
            #region Arange
            var playablesMock = new List<IPlayable>
            {
                CreateMockPlayable(false).Object,
                CreateMockPlayable(false).Object,
                CreateMockPlayable(false).Object,
            };

            _nextPlayableCommand = new NextPlayableCommand(playablesMock);
            #endregion

            #region Act
            _nextPlayableCommand.Undo();
            #endregion

            #region Assert
            Assert.IsFalse(playablesMock.Any(x => x.IsPlaying));
            #endregion
        }

        private Mock<IPlayable> CreateMockPlayable(bool isPlaying)
        {
            var mock = new Mock<IPlayable>();
            mock.SetupGet(m => m.IsPlaying).Returns(isPlaying);
            mock.Setup(m => m.Play()).Callback(() => { mock.SetupGet(x => x.IsPlaying).Returns(true); });
            mock.Setup(m => m.Pause()).Callback(() => { mock.SetupGet(x => x.IsPlaying).Returns(false); });
            return mock;
        }
    }
}
