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

        public static void Save(Bitmap img, string path)
        {
            var file = new FileInfo(path);
            var directory = file.Directory;
            var extension = file.Extension;

            var dirInfo = Directory.CreateDirectory(directory.ToString());
            if (extension.Contains("bmp"))
            {
                SaveBmp(img, path);
            }
            else
            {
                SaveJpg(img, path);
            }
        }
        private static void SaveBmp(Bitmap img, string path)
        {
            try { img.Save(path); }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }

        private static void SaveJpg(Bitmap img, string path)
        {
            try{ img.Save(path, ImageFormat.Jpeg); }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }
    }
}