using System.Drawing;
namespace RandomPictureGenLib.PictureGen
{
    public static class PicCreate
    {
        public static Bitmap CreateImage(Color[,] imageAbstrac)
        {
            var imageWidth = imageAbstrac.GetLength(0);
            var imageHeight = imageAbstrac.GetLength(1);
            var image = new Bitmap(imageWidth, imageHeight);
            var rand = new Random();

            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
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