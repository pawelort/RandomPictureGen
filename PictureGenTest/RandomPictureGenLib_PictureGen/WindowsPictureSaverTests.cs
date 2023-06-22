using System.Drawing;
using RandomPictureGenLib.PictureGen;
using RandomPictureGenLib.PictureGenInterfaces;
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
            testPictureFullName = string.Concat(Directory.GetCurrentDirectory(), @"\pic.Bmp");
            var picWidth = 30;
            var picHeight = 30;
            var imageAbstract = new ImageAbstraction(picWidth, picHeight);
            var imageSaver = WindowsPictureFactorySaver.WindowsPictureBmpSaver();

            // act
            imageSaver.Save(path, imageAbstract.CreateImageAbstraction());
            using var createdImage = new Bitmap(testPictureFullName);

            // assert
            Assert.True(File.Exists(testPictureFullName));
            Assert.Equal(picWidth, createdImage.Width);
            Assert.Equal(picHeight, createdImage.Height);
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

        [InlineData(@"\new_BMP_picture\", "pic.Bmp", 100, 80)]
        [InlineData(@"\pictures_BMP\", "pic.Bmp", 50, 30)]
        [Theory]
        public void SaveBmpPictureTest(string dirPath, string fileName, int picWidth, int picHeight)
        {
            // arrange
            directoryToCreatePath = string.Concat(Directory.GetCurrentDirectory(), dirPath);
            testPictureFullName = string.Concat(directoryToCreatePath, fileName);
            var imageAbstract = new ImageAbstraction(picWidth, picHeight);
            var imageSaver = WindowsPictureFactorySaver.WindowsPictureBmpSaver();

            // act
            imageSaver.Save(directoryToCreatePath, imageAbstract.CreateImageAbstraction());
            using var createdImage = new Bitmap(testPictureFullName);

            // assert
            Assert.True(Directory.Exists(directoryToCreatePath));
            Assert.True(File.Exists(testPictureFullName));
            Assert.Equal(picWidth, createdImage.Width);
            Assert.Equal(picHeight, createdImage.Height);
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

        [InlineData(@"\new_JPG_picture\", "pic.Jpeg", 100, 70)]
        [InlineData(@"\pictures_JPG\", "pic.Jpeg", 30, 50)]
        [Theory]
        public void SaveBmpPictureTest(string dirPath, string fileName, int picWidth, int picHeight)
        {
            // arrange
            directoryToCreatePath = string.Concat(Directory.GetCurrentDirectory(), dirPath);
            testPictureFullName = string.Concat(directoryToCreatePath, fileName);
            var imageAbstract = new ImageAbstraction(picWidth, picHeight);
            var imageSaver = WindowsPictureFactorySaver.WindowsPictureJpgSaver();

            // act
            imageSaver.Save(directoryToCreatePath, imageAbstract.CreateImageAbstraction());
            using var createdImage = new Bitmap(testPictureFullName);

            // assert
            Assert.True(Directory.Exists(directoryToCreatePath));
            Assert.True(File.Exists(testPictureFullName));
            Assert.Equal(picWidth, createdImage.Width);
            Assert.Equal(picHeight, createdImage.Height);
        }

        public void Dispose()
        {
            File.Delete(testPictureFullName);
            Directory.Delete(directoryToCreatePath);
        }
    }

    public class CreateWholeBlackPicture : IDisposable
    {
        string? directoryToCreatePath;
        string? testPictureFullName;

        [Fact]
        public void SaveBmpPictureTest()
        {
            // arrange
            Mock<IImageAbstraction> createWhiteImageDTO = new Mock<IImageAbstraction>();
            var picWidth = 20;
            var picHeight = 20;
            createWhiteImageDTO.Setup(x => x.CreateImageAbstraction()).Returns(new ImageDTO(picWidth, picHeight));

            testPictureFullName = string.Concat(Directory.GetCurrentDirectory(), @"\pic.Bmp");
            var imageSaver = WindowsPictureFactorySaver.WindowsPictureBmpSaver();

            // act
            imageSaver.Save(Directory.GetCurrentDirectory(), createWhiteImageDTO.Object.CreateImageAbstraction());
            using var createdImage = new Bitmap(testPictureFullName);

            // assert
            Assert.True(File.Exists(testPictureFullName));
            Assert.Equal(picWidth, createdImage.Width);
            Assert.Equal(picHeight, createdImage.Height);
            
            for (int x = 0; x < createdImage.Width; x++)
            {
                for (int y = 0; y < createdImage.Height; y++)
                {
                    Assert.Equal(Color.FromArgb(0, 0, 0), createdImage.GetPixel(x, y));
                }
            }
        }

        public void Dispose()
        {
            File.Delete(testPictureFullName);
        }
    }
    
}
