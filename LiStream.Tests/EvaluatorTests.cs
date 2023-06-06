namespace LiStream.Tests
{
    [TestClass]
    public class EvaluatorTests
    {
        private Evaluator _evaluator;

        [TestInitialize]
        public void Init()
        {
            _evaluator = new Evaluator();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _evaluator = null;
        }

        [TestMethod]
        public void GetSimilar_ReturnMostSimilarSong()
        {
            #region Arrange
            var songMocks = new List<ISong>(){
                CreateMockSong(new byte[]{1,2,3,4}).Object,
                CreateMockSong(new byte[]{5,6,7,8}).Object,
                CreateMockSong(new byte[]{9,0,1,2}).Object,
                CreateMockSong(new byte[]{1,2,5,8}).Object,
            };

            #endregion

            #region Act
            var result = _evaluator.GetSimilar(songMocks[0], songMocks);
            #endregion

            #region Assert
            Assert.AreEqual(songMocks[3], result);
            #endregion
        }

        [TestMethod]
        public void GetSimilar_ReturnMostSimilarSong_WithEmptyList()
        {
            #region Arrange
            var songMocks = new List<ISong>()
            {
            };
            #endregion
            #region Act
            var result = _evaluator.GetSimilar(CreateMockSong(new byte[] {1,2,3,4}).Object, songMocks);
            #endregion
            #region Assert
            Assert.IsNull(result);
            #endregion
        }

        [TestMethod]
        public void GetSimilarList_ReturnSimilarSongs()
        {
            #region Arrange
            var songMocks = new List<ISong>()
            {
                CreateMockSong(new byte[]{1,2,3,4}).Object,
                CreateMockSong(new byte[]{5,6,7,8}).Object,
                CreateMockSong(new byte[]{9,2,1,2}).Object,
                CreateMockSong(new byte[]{1,2,5,8}).Object,
            };
            #endregion
            #region Act
            var result = _evaluator.GetSimilarList(songMocks[0], songMocks);
            #endregion
            #region Assert
            Assert.IsFalse(result.Contains(songMocks[0]));
            Assert.IsFalse(result.Contains(songMocks[1]));
            Assert.IsTrue(result.Contains(songMocks[2]));
            Assert.IsTrue(result.Contains(songMocks[3]));
            #endregion
        }

        [TestMethod]
        public void GetSimilar_ReturnSimilarArtist()
        {
            #region Arrange
            var artistMocks = new List<IArtistProfile>()
            {
                new Mock<IArtistProfile>().Object,
                new Mock<IArtistProfile>().Object,
                new Mock<IArtistProfile>().Object,
                new Mock<IArtistProfile>().Object,
            };
            #endregion

            #region Act
            var result = _evaluator.GetSimilar(artistMocks[0], artistMocks);
            #endregion

            #region Assert
            Assert.IsFalse(result.Equals(artistMocks[0]));
            Assert.IsTrue(artistMocks.Contains(result));
            #endregion
        }

        [TestMethod]
        public void GetSimilarList_ReturnSimilarArtists()
        {
            #region Arrange
            var artistMocks = new List<IArtistProfile>()
            {                
                new Mock<IArtistProfile>().Object,
                new Mock<IArtistProfile>().Object,
                new Mock<IArtistProfile>().Object,
                new Mock<IArtistProfile>().Object,
            };
            #endregion

            #region Act
            var result = _evaluator.GetSimilarList(artistMocks[0], artistMocks);
            #endregion

            #region Assert
            
            Assert.IsFalse(result.Contains(artistMocks[0]));
            Assert.IsTrue(result.Contains(artistMocks[1]));
            Assert.IsTrue(result.Contains(artistMocks[2]));
            Assert.IsTrue(result.Contains(artistMocks[3]));
            #endregion
        }

        public void GetSimilarList_ReturnSimilarArtistsCountLess3()
        {
            #region Arrange
            var artistMocks = new List<IArtistProfile>()
            {
                new Mock<IArtistProfile>().Object,
                new Mock<IArtistProfile>().Object,
            };
            #endregion

            #region Act
            var result = _evaluator.GetSimilarList(artistMocks[0], artistMocks);
            #endregion

            #region Assert

            Assert.IsFalse(result.Contains(artistMocks[0]));
            Assert.IsTrue(result.Contains(artistMocks[1]));
            Assert.IsTrue(result.Count == 1);
            #endregion
        }

        public void GetSimilarList_ReturnSimilarArtistsEmptyList()
        {
            #region Arrange
            var artistMocks = new List<IArtistProfile>();
            #endregion

            #region Act
            var result = _evaluator.GetSimilarList(new Mock<IArtistProfile>().Object, artistMocks);
            #endregion

            #region Assert
            Assert.IsTrue(result.Count == 0);
            #endregion
        }

        private Mock<ISong> CreateMockSong(byte[] data)
        {
            var mock = new Mock<ISong>();
            mock.SetupGet(m => m.Data).Returns(data);
            return mock;
        }
    }
}
