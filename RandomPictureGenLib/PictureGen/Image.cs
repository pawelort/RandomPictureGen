using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace RandomPictureGenLib.PictureGen
{
    public class Image
    {
        private int _width;
        private int _height;
        private string _path;


        public int width
        {
            get { return _width; }
            set
            {
                if (value > 0)
                {
                    _width = value;
                }
                else
                {
                    _width = 10;
                }
            }
        }

        public int height
        {
            get { return _height; }
            set
            {
                if (value > 0)
                {
                    _height = value;
                }
                else
                {
                    _height = 10;
                }
            }
        }

        public string path
        {
            get { return _path; }
            set
            {
                char[] invalidPathChars = Path.GetInvalidPathChars();
                foreach (char forbiddenSymbol in invalidPathChars)
                {
                    if (value.Contains(forbiddenSymbol))
                    {
                        _path = "";
                        return;
                    }
                }
                _path = value;
            }

        }
    

    public Image(int x, int y, string picture_path)
    {
        width = x;
        height = y;
        path = picture_path;
    }

    public Image(int x, string picture_path)
    {
        width = x;
        height = x;
        path = picture_path;
    }

    public void CreateImage()
    {
        Bitmap image = new Bitmap(width, height);
        Random rand = new Random();

        for (int x = 0; x < image.Width; x++)
        {
            for (int y = 0; y < image.Height; y++)
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
        }
        try
        {
            string[] folderPath = path.Split('\\');
            string extension = folderPath[^1];
            DirectoryInfo dirInfo = Directory.CreateDirectory(String.Join('\\', folderPath[0..^1]));
            if (extension.Contains("bmp"))
            {
                image.Save(path);
            }
            else
            {
                image.Save(path, ImageFormat.Jpeg);
            }
        }
        catch (Exception exc)
        {
            Console.WriteLine($"{exc.Message}");
        }


    }

}

}
