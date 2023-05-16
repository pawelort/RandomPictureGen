using System.Drawing;
using System.Drawing.Imaging;
namespace RandomPictureGenLib.PictureGen
{
    public class PicSave
    {
        private static string path = Directory.GetCurrentDirectory();

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

        public static void Save(Bitmap img, string path = Path)
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
        private void SaveBmp(Bitmap img, string path)
        {
            try { img.Save(path); }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }

        private void SaveJpg(Bitmap img, string path)
        {
            try{ img.Save(path, ImageFormat.Jpeg); }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }
        }
    }
}