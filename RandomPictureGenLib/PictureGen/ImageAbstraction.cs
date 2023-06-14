using RandomPictureGenLib.PictureGenInterfaces;
namespace RandomPictureGenLib.PictureGen
{
    public class ImageAbstraction : IImageAbstraction
    {
        public int Width { set; get; }
        public int Height { set; get; }

        public ImageAbstraction(int width, int height)
        {
            Width = width;
            Height = height;
        }

        private void SetWhitePixel(ImageDTO imageAbstraction, int x, int y)
        {
            imageAbstraction.imagePixels[x, y] = true;
        }

        private void SetBlackPixel(ImageDTO imageAbstraction, int x, int y)
        {
            imageAbstraction.imagePixels[x, y] = false;
        }

        public ImageDTO CreateImageAbstraction()
        {
            var imageAbstract = new ImageDTO(Width, Height);
            var rand = new Random();
            
            for (int x = 0; x < imageAbstract.Width; x++)
            {
                for (int y = 0; y < imageAbstract.Width; y++)
                {
                    if (rand.Next(0, 2) % 2 == 0)
                    {
                        SetBlackPixel(imageAbstract, x, y);
                    }
                    else
                    {
                        SetWhitePixel(imageAbstract, x, y);
                    }
                }
            }
            return imageAbstract;
        }
    }

}
