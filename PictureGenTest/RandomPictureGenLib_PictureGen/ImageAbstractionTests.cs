using RandomPictureGenLib.PictureGen;
namespace PictureGenTest.RandomPictureGenLib_PictureGen
{
    public class ImageAbstractionTests
    {
        [InlineData(30, 80)]
        [InlineData(15, 100)]
        [Theory]
        public void CreateRectanglePicture(int x_dimension, int y_dimension)
        {
            var imgAbstract = new ImageAbstraction(x_dimension, y_dimension);
            var picture = imgAbstract.CreateImageAbstraction();

            Assert.Equal(x_dimension, picture.Width);
            Assert.Equal(y_dimension, picture.Height);
            Assert.IsType<ImageDTO>(picture);
        }

        [InlineData(-50, 0)]
        [InlineData(-30, -20)]
        [Theory]
        public void CreateRectanglePictureWithForbiddenBothDim(int x_dimension, int y_dimension)
        {
            var imgAbstract = new ImageAbstraction(x_dimension, y_dimension);
            var picture = imgAbstract.CreateImageAbstraction();

            Assert.Equal(10, picture.Width);
            Assert.Equal(10, picture.Height);
        }

        [Fact]
        public void CreateRectanglePictureWithForbiddenOneDim()
        {
            var imgAbstract = new ImageAbstraction(-50, 80);
            var picture = imgAbstract.CreateImageAbstraction();

            Assert.Equal(10, picture.Width);
            Assert.Equal(80, picture.Height);
        }
    }
}