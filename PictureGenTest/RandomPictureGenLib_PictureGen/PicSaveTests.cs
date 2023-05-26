using System.Drawing;
using RandomPictureGenLib.PictureGen;
namespace PictureGenTest.RandomPictureGenLib_PictureGen
{
    public class PathTests
    {
        [InlineData(@"C:|dotnet projects")]
        [Theory]
        public void IncorrectPathTest(string path)
        {
            PicSave.Path = path;
            
            Assert.NotEmpty(PicSave.Path);
            Assert.Equal(Directory.GetCurrentDirectory(), PicSave.Path);
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
            directoryToCreatePath = string.Concat(Directory.GetCurrentDirectory(), dirPath);
            testPictureFullName = string.Concat(directoryToCreatePath, fileName);
            using var BmpPicture = new Bitmap(picWidth, picHeight);

            PicSave.SaveBmp(BmpPicture, testPictureFullName);

            Assert.True(Directory.Exists(directoryToCreatePath));
            Assert.True(File.Exists(testPictureFullName));
            //Assert.Equal(BmpPicture.Width, new Bitmap(testPictureFullName).Width);
            //Assert.Equal(BmpPicture.Height, new Bitmap(testPictureFullName).Height);
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
            directoryToCreatePath = string.Concat(Directory.GetCurrentDirectory(), dirPath);
            testPictureFullName = string.Concat(directoryToCreatePath, fileName);
            using var JpgPicture = new Bitmap(picWidth, picHeight);

            PicSave.SaveJpg(JpgPicture, testPictureFullName);

            Assert.True(Directory.Exists(directoryToCreatePath));
            Assert.True(File.Exists(testPictureFullName));
            //Assert.Equal(JpgPicture.Width, new Bitmap(testPictureFullName).Width);
            //Assert.Equal(JpgPicture.Height, new Bitmap(testPictureFullName).Height);
        }

        public void Dispose()
        {
            File.Delete(testPictureFullName);
            Directory.Delete(directoryToCreatePath);
        }
    }

    
}

// TODO: sprawdzić dlaczego wywala 'The process cannot access the file because it is being used by another process' przy testach
// TODO: dodać dziedziczenie do klas SaveBmpTests i SaveJpgTests