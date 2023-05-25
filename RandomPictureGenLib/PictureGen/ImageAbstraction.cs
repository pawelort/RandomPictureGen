using System.Drawing;
namespace RandomPictureGenLib.PictureGen
{
    public static class ImageAbstraction
    {
        private const int DefaultWidth = 10;
        private const int DefaultHeight = 10;

        public static Color[,] CreateRectangle(int x, int y)
        {
            return CreateImageAbstraction(x, y);
        }

        public static Color[,] CreateSquare(int x)
        {
            return CreateImageAbstraction(x, x);
        }

        private static Color[,] CreateImageAbstraction(int width, int height)
        {
            var imageWidth = width > 0 ? width : DefaultWidth;
            var imageHeight = height > 0 ? height : DefaultHeight;

            var imageAbstraction = new Color[imageWidth, imageHeight];
            var rand = new Random();
            
            for (int x = 0; x < imageWidth; x++)
            {
                for (int y = 0; y < imageHeight; y++)
                {
                    if (rand.Next(0, 2) % 2 == 0)
                    {
                        imageAbstraction[x, y] = Color.FromArgb(0, 0, 0);
                    }
                    else
                    {
                        imageAbstraction[x, y] = Color.FromArgb(255, 255, 255);
                    }
                }
            }

            return imageAbstraction;
        }
    }

}


//TODO: oddzielić zapisywanie obrazka od tworzenia obrazka
//TODO: zrobić unit testy
//TODO: pomyśleć nad innym sposobem zamodelowania obrazka (dwuwymiarowy array z pixelami?)