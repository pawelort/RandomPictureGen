using RandomPictureGenLib.PictureGenInterfaces;
using System.Drawing;
using System.Drawing.Imaging;
namespace RandomPictureGenLib.PictureGen
{
    public class WindowsPictureSaver : IPictureSaver
    {
        public Bitmap image { private set; get; }
        private string path = Directory.GetCurrentDirectory();
        public string Path
        {
            get => path;
            set
            {
                var invalidPathChars = System.IO.Path.GetInvalidPathChars();
                if (invalidPathChars.Any(value.Contains))
                {
                    path = Directory.GetCurrentDirectory();
                    return;
                }
                path = value;
            }
        }

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

        private void PathHandling(string path)
        {
            var file = new FileInfo(path);
            var directory = file.Directory;
            Directory.CreateDirectory(directory.ToString());
        }
        public void SaveBmp(string path)
        {
            try
            {
                PathHandling(path);
                image.Save(path, ImageFormat.Bmp);
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
                PathHandling(path);
                image.Save(path, ImageFormat.Jpeg);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }
    }
}