using System.Drawing;
using System.Drawing.Imaging;
using RandomPictureGenLib.PictureGenInterfaces;
namespace RandomPictureGenLib.PictureGen
{
    public class PicSave : IPicSave
    {
        private string path = Directory.GetCurrentDirectory();
        private Bitmap image;
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

        public PicSave(Bitmap img)
        {
            image = img;
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