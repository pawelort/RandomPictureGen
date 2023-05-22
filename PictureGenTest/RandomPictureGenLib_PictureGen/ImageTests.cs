using RandomPictureGenLib.PictureGen;
namespace PictureGenTest.RandomPictureGenLib_PictureGen
{
    public class ImageTests
    {

        [Fact]
        public void CreateSquarePicture()
        {
            var squarePicture = Image.CreateSquare(-20);

            Assert.Equal(squarePicture.Height, 10);
            Assert.Equal(squarePicture.Width, 10);
        }
    }
}