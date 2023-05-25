using System.Drawing;
using RandomPictureGenLib.PictureGen;
namespace PictureGenConsoleApp.PictureSettings
{
    public class PictureGenSettings
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

        public PictureGenSettings(int picture_width, int picture_height)
        {
            width = picture_width;
            height = picture_height;
        }
        public Bitmap Create()
        {
            var imgAbstraction = ImageAbstraction.CreateRectangle(Width, Height);
            return PicCreate.CreateImage(imgAbstraction);
        }
    }
}