using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace RandomPictureGenLib.PictureGen
{
    public class Image
    {
        private Bitmap image;
        Random rand = new Random();

        public Image(int x, int y)
        {
            image = new Bitmap(x, y);
        }

        public Image(int x)
        {
            image = new Bitmap(x, x);
        }

        private void SetRandomBWPixel(int x, int y)
        {
            if (rand.Next(0, 2) % 2 == 0)
            {
                image.SetPixel(x, y, Color.FromArgb(0, 0, 0));
            }
            else
            {
                image.SetPixel(x, y, Color.FromArgb(255, 255, 255));
            }
        }

        public void SetRandomImg()
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    SetRandomBWPixel(x, y);
                }
            }
        }

        private void SaveBmp(string path)
        {        
            image.Save(path);
        }
        private void SaveJpg(string path)
        {
            image.Save(path, ImageFormat.Jpeg);
        }

        public void SaveImg(string path)
        {
            try
            {
                string[] folderPath = path.Split('\\');
                string extension = folderPath[^1];
                DirectoryInfo dirInfo = Directory.CreateDirectory(String.Join('\\', folderPath[0..^1]));
                if (extension.Contains("bmp"))
                {
                    SaveBmp(path);
                }
                else
                {   
                    SaveJpg(path);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"{exc.Message}");
            }


        }

    }

}
