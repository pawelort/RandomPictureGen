using RandomPictureGenLib.PictureGenInterfaces;
namespace RandomPictureGenLib.PictureGen
{
    public struct ImageDTO : IImageDTO
    {

        private const int DefaultWidth = 10;
        private const int DefaultHeight = 10;
        public bool[,] imagePixels { get; set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public ImageDTO(int width, int height)
        {
            var imageWidth = width > 0 ? width : DefaultWidth;
            var imageHeight = height > 0 ? height : DefaultHeight;

            imagePixels = new bool[imageWidth, imageHeight];
            Width = imagePixels.GetLength(0);
            Height = imagePixels.GetLength(1);
        }


        
    }
}