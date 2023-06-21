using RandomPictureGenLib.PictureGenInterfaces;
using System.Drawing;
using System.Drawing.Imaging;
namespace RandomPictureGenLib.PictureGen
{
    public class WindowsPictureSaver : IPictureSaver
    {

        private Bitmap CreatePicture(ImageDTO imageAbstraction)
        {
            var image = new Bitmap(imageAbstraction.Width, imageAbstraction.Height);
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
            return image;
        }

        private string PathHandling(string path, string defaultName)
        {
            var invalidPathChars = System.IO.Path.GetInvalidPathChars();
            if (invalidPathChars.Any(path.Contains))
                {
                    path = string.Concat(Directory.GetCurrentDirectory().ToString(), @$"\{defaultName}");
                }
            var file = new FileInfo(path);
            var directory = file.Directory;
            Directory.CreateDirectory(directory.ToString());
            return path;
        }
        public void SaveBmp(string path, ImageDTO imageAbstraction)
        {
            try
            {
                using var image = CreatePicture(imageAbstraction);
                image.Save(PathHandling(path, "pic.bmp"), ImageFormat.Bmp);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }

        public void SaveJpg(string path, ImageDTO imageAbstraction)
        {
            try
            {
                using var image = CreatePicture(imageAbstraction);
                image.Save(PathHandling(path, "pic.jpg"), ImageFormat.Jpeg);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }
    }
}