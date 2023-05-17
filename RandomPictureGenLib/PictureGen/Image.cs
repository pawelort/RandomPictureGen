using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace RandomPictureGenLib.PictureGen
{
    public class Image
    {
        private const int DefaultWidth = 10;
        private const int DefaultHeight = 10;
        private int width;
        private int height;



        public int Width
        {
            get => width;
            set => width = value > 0 ? value : DefaultWidth;
        }

        public int Height
        {
            get => height;
            set => height = value > 0 ? value : DefaultHeight;
        }

        public static Image CreateRectangle(int x, int y)
        {
            return new Image(x, y);
        }

        public static Image CreateSquare(int x)
        {
            return new Image(x, x);
        }

        public Image(int x, int y)
        {
            Width = x;
            height = y;
        }

        public Bitmap CreateImage()
        {
            using var image = new Bitmap(width, height);
            var rand = new Random();

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

            return image;
        }

    }

}


//TODO: oddzielić zapisywanie obrazka od tworzenia obrazka
//TODO: zrobić unit testy
//TODO: pomyśleć nad innym sposobem zamodelowania obrazka (dwuwymiarowy array z pixelami?)