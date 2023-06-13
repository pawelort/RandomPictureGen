using System.Drawing;
using RandomPictureGenLib.PictureGenInterfaces;
namespace RandomPictureGenLib.PictureGen
{
    public class PicCreate : IPicCreate
    {

        Bitmap image;
        public void CreateImage(ImageDTO imageAbstrac)
        {
            var image = new Bitmap(imageAbstrac.Width, imageAbstrac.Height);

            for (int x = 0; x < imageAbstrac.Width; x++)
            {
                for (int y = 0; y < imageAbstrac.Height; y++)
                {
                    if (imageAbstrac.imagePixels[x, y] == false)
                    {
                        image.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        image.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }
                }
            }

        }
    }
}