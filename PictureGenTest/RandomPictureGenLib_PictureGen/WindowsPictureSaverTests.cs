using System.Drawing;
using RandomPictureGenLib.PictureGen;
namespace PictureGenTest.RandomPictureGenLib_PictureGen
{
    public class PathTests : IDisposable
    {
        string? directoryToCreatePath;
        string? testPictureFullName;
        [InlineData(@"C:|dotnet projects")]
        [Theory]
        public void IncorrectPathTest(string path)
        {
            // arrange
            testPictureFullName = string.Concat(Directory.GetCurrentDirectory(), @"\pic.bmp");
            var imageAbstract = new ImageAbstraction(30, 30);
            var imageSaver = new WindowsPictureSaver();

            // act
            imageSaver.CreatePicture(imageAbstract.CreateImageAbstraction());
            imageSaver.SaveBmp(path);
            using var createdImage = new Bitmap(testPictureFullName);

            // assert
            Assert.True(File.Exists(testPictureFullName));
            Assert.Equal(imageSaver.image.Width, createdImage.Width);
            Assert.Equal(imageSaver.image.Height, createdImage.Height);
        }

        public void Dispose()
        {
            File.Delete(testPictureFullName);
        }
    }

    public class SaveBmpTests : IDisposable
    {
        string? directoryToCreatePath;
        string? testPictureFullName;

        [InlineData(@"\new_BMP_picture\", "pic.bmp", 100, 80)]
        [InlineData(@"\pictures_BMP\", "temp.bmp", 50, 30)]
        [Theory]
        public void SaveBmpPictureTest(string dirPath, string fileName, int picWidth, int picHeight)
        {
            // arrange
            directoryToCreatePath = string.Concat(Directory.GetCurrentDirectory(), dirPath);
            testPictureFullName = string.Concat(directoryToCreatePath, fileName);
            var imageAbstract = new ImageAbstraction(picWidth, picHeight);
            var imageSaver = new WindowsPictureSaver();

            // act
            imageSaver.CreatePicture(imageAbstract.CreateImageAbstraction());
            imageSaver.SaveBmp(testPictureFullName);
            using var createdImage = new Bitmap(testPictureFullName);

            // assert
            Assert.True(Directory.Exists(directoryToCreatePath));
            Assert.True(File.Exists(testPictureFullName));
            Assert.Equal(imageSaver.image.Width, createdImage.Width);
            Assert.Equal(imageSaver.image.Height, createdImage.Height);
        }

        public void Dispose()
        {
            File.Delete(testPictureFullName);
            Directory.Delete(directoryToCreatePath);
        }
    }


    public class SaveJpgTests : IDisposable
    {
        string? directoryToCreatePath;
        string? testPictureFullName;

        [InlineData(@"\new_JPG_picture\", "pic.jpg", 100, 70)]
        [InlineData(@"\pictures_JPG\", "temp.jpg", 30, 50)]
        [Theory]
        public void SaveBmpPictureTest(string dirPath, string fileName, int picWidth, int picHeight)
        {
            // arrange
            directoryToCreatePath = string.Concat(Directory.GetCurrentDirectory(), dirPath);
            testPictureFullName = string.Concat(directoryToCreatePath, fileName);
            var imageAbstract = new ImageAbstraction(picWidth, picHeight);
            var imageSaver = new WindowsPictureSaver();

            // act
            imageSaver.CreatePicture(imageAbstract.CreateImageAbstraction());
            imageSaver.SaveJpg(testPictureFullName);
            using var createdImage = new Bitmap(testPictureFullName);

            // assert
            Assert.True(Directory.Exists(directoryToCreatePath));
            Assert.True(File.Exists(testPictureFullName));
            Assert.Equal(imageSaver.image.Width, createdImage.Width);
            Assert.Equal(imageSaver.image.Height, createdImage.Height);
        }

        public void Dispose()
        {
            File.Delete(testPictureFullName);
            Directory.Delete(directoryToCreatePath);
        }
    }

    
}
