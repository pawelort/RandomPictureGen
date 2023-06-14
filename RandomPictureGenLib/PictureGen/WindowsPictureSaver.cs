using RandomPictureGenLib.PictureGenInterfaces;
using System.Drawing;
using System.Drawing.Imaging;
namespace RandomPictureGenLib.PictureGen
{
    public class WindowsPictureSaver : IPictureSaver
    {
        public Bitmap image { private set; get; }

        public void CreatePicture(ImageDTO imageAbstraction)
        {
            image = new Bitmap(imageAbstraction.Width, imageAbstraction.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    if (imageAbstraction.imagePixels[x, y])
                    {
                        image.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        image.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }

        }

        private string PathHandling(string path)
        {
            var invalidPathChars = System.IO.Path.GetInvalidPathChars();
            if (invalidPathChars.Any(path.Contains))
                {
                    path = Directory.GetCurrentDirectory();
                }
            var file = new FileInfo(path);
            var directory = file.Directory;
            Directory.CreateDirectory(directory.ToString());
            return path;
        }
        public void SaveBmp(string path)
        {
            try
            {
                image.Save(PathHandling(path), ImageFormat.Bmp);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }

        public void SaveJpg(string path)
        {
            try
            {
                image.Save(PathHandling(path), ImageFormat.Jpeg);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }
    }
}