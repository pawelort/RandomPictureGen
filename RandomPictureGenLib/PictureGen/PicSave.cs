using System.Drawing;
using System.Drawing.Imaging;
namespace RandomPictureGenLib.PictureGen
{
    public class PicSave
    {
        private static string path = Directory.GetCurrentDirectory();

        public static string Path
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

        private static void PathHandling(string path)
        {
            var file = new FileInfo(path);
            var directory = file.Directory;
            Directory.CreateDirectory(directory.ToString());
        }

        public static void SaveBmp(Bitmap img, string path)
        {
            try 
            { 
                PathHandling(path);
                img.Save(path, ImageFormat.Bmp);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }

        public static void SaveJpg(Bitmap img, string path)
        {
            try
            {
                PathHandling(path);
                img.Save(path, ImageFormat.Jpeg);
            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }
    }
}