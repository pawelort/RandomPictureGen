using System.Drawing;
using RandomPictureGenLib.PictureGen;
namespace PictureGenTest.RandomPictureGenLib_PictureGen
{
    public class PicCreateTests
    {
        [InlineData(30)]
        [InlineData(300)]
        [Theory]
        public void CreateSquarePicture(int dimension)
        {
            var pictureArr = new Color[dimension, dimension];
            
            var squarePicture = PicCreate.CreateImage(pictureArr);

            Assert.Equal(squarePicture.Width, dimension);
            Assert.Equal(squarePicture.Height, dimension);
        }

        [InlineData(20, 50)]
        [InlineData(10, 30)]
        [Theory]
        public void CreateRectanglePicture(int x_dimension, int y_dimension)
        {
            var pictureArr = new Color[x_dimension, y_dimension];
            
            var squarePicture = PicCreate.CreateImage(pictureArr);

            Assert.Equal(squarePicture.Width, x_dimension);
            Assert.Equal(squarePicture.Height, y_dimension);
        }
    }
}
