using RandomPictureGenLib.PictureGen;
namespace PictureGenTest.RandomPictureGenLib_PictureGen
{
    public class ImageAbstractionTests
    {
        [InlineData(30)]
        [InlineData(300)]
        [Theory]
        public void CreateSquarePicture(int dimension)
        {
            var squarePicture = ImageAbstraction.CreateSquare(dimension);

            Assert.Equal(squarePicture.GetLength(0), dimension);
            Assert.Equal(squarePicture.GetLength(1), dimension);
        }

        [InlineData(-20)]
        [InlineData(0)]
        [Theory]
        public void CreateSquarePictureWithForbiddenDim(int dimension)
        {
            var squarePicture = ImageAbstraction.CreateSquare(dimension);

            Assert.Equal(squarePicture.GetLength(0), 10);
            Assert.Equal(squarePicture.GetLength(1), 10);
        }

        [InlineData(30, 80)]
        [InlineData(15, 100)]
        [Theory]
        public void CreateRectanglePicture(int x_dimension, int y_dimension)
        {
            var squarePicture = ImageAbstraction.CreateRectangle(x_dimension, y_dimension);

            Assert.Equal(squarePicture.GetLength(0), x_dimension);
            Assert.Equal(squarePicture.GetLength(1), y_dimension);
        }

        [InlineData(-50, 0)]
        [InlineData(-30, -20)]
        [Theory]
        public void CreateRectanglePictureWithForbiddenBothDim(int x_dimension, int y_dimension)
        {
            var squarePicture = ImageAbstraction.CreateRectangle(x_dimension, y_dimension);

            Assert.Equal(squarePicture.GetLength(0), 10);
            Assert.Equal(squarePicture.GetLength(1), 10);
        }

        [Fact]
        public void CreateRectanglePictureWithForbiddenOneDim()
        {
            var squarePicture = ImageAbstraction.CreateRectangle(-50, 80);

            Assert.Equal(squarePicture.GetLength(0), 10);
            Assert.Equal(squarePicture.GetLength(1), 80);
        }
    }
}