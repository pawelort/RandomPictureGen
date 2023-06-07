using RandomPictureGenLib.PictureGenInterfaces;
namespace RandomPictureGenLib.PictureGen
{
    public class ImageAbstraction : IImageAbstraction
    {
        private IImageDTO imageAbstraction;

        public ImageAbstraction(IImageDTO imageAbstraction)
        {
            this.imageAbstraction = imageAbstraction;
            CreateImageAbstraction();
        }

        private void SetWhitePixel(int x, int y)
        {
            imageAbstraction.imagePixels[x, y] = true;
        }

        private void SetBlackPixel(int x, int y)
        {
            imageAbstraction.imagePixels[x, y] = false;
        }

        public void CreateImageAbstraction()
        {

            var rand = new Random();
            
            for (int x = 0; x < imageAbstraction.Width; x++)
            {
                for (int y = 0; y < imageAbstraction.Width; y++)
                {
                    if (rand.Next(0, 2) % 2 == 0)
                    {
                        SetBlackPixel(x, y);
                    }
                    else
                    {
                        SetWhitePixel(x, y);
                    }
                }
            }

        }
    }

}

