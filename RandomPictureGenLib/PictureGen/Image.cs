using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace RandomPictureGenLib.PictureGen
{
    public static class Image
    {
        private const int DefaultWidth = 10;
        private const int DefaultHeight = 10;

        public static Bitmap CreateRectangle(int x, int y)
        {
            return CreateImage(x, y);
        }

        public static Bitmap CreateSquare(int x)
        {
            return CreateImage(x, x);
        }

        private static Bitmap CreateImage(int width, int height)
        {
            var image_width = width > 0 ? width : DefaultWidth;
            var image_height = height > 0 ? height : DefaultHeight;

            var image = new Bitmap(image_width, image_height);
            var rand = new Random();

            for (int x = 0; x < image_width; x++)
            {
                for (int y = 0; y < image_height; y++)
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