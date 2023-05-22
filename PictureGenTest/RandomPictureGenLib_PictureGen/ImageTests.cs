using RandomPictureGenLib.PictureGen;
namespace PictureGenTest.RandomPictureGenLib_PictureGen
{
    public class ImageTests
    {
        [InlineData(30)]
        [InlineData(300)]
        [Theory]
        public void CreateSquarePicture(int dimension)
        {
            var squarePicture = Image.CreateSquare(dimension);

            Assert.Equal(squarePicture.Height, dimension);
            Assert.Equal(squarePicture.Width, dimension);
        }

        [InlineData(-20)]
        [InlineData(0)]
        [Theory]
        public void CreateSquarePictureWithForbiddenDim(int dimension)
        {
            var squarePicture = Image.CreateSquare(dimension);

            Assert.Equal(squarePicture.Height, 10);
            Assert.Equal(squarePicture.Width, 10);
        }

        [InlineData(30, 80)]
        [InlineData(15, 100)]
        [Theory]
        public void CreateRectanglePicture(int x_dimension, int y_dimension)
        {
            var squarePicture = Image.CreateRectangle(x_dimension, y_dimension);

            Assert.Equal(squarePicture.Height, y_dimension);
            Assert.Equal(squarePicture.Width, x_dimension);
        }

        [InlineData(-50, 0)]
        [InlineData(-30, -20)]
        [Theory]
        public void CreateRectanglePictureWithForbiddenBothDim(int x_dimension, int y_dimension)
        {
            var squarePicture = Image.CreateRectangle(x_dimension, y_dimension);

            Assert.Equal(squarePicture.Height, 10);
            Assert.Equal(squarePicture.Width, 10);
        }

        [Fact]
        public void CreateRectanglePictureWithForbiddenOneDim()
        {
            var squarePicture = Image.CreateRectangle(-50, 80);

            Assert.Equal(squarePicture.Height, 80);
            Assert.Equal(squarePicture.Width, 10);
        }
    }
}