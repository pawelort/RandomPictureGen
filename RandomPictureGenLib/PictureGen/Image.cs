using System.Drawing;
namespace RandomPictureGenLib.PictureGen
{
    public class Image
    {
        private Bitmap image;
        Random rand = new Random();

        public Image(int x, int y)
        {
            image = new Bitmap(x, y);
        }

        public Image(int x)
        {
            image = new Bitmap(x, x);
        }

        private void SetRandomBWPixel(int x, int y)
        {
            if (rand.Next(0,2) % 2 == 0)
            {
                image.SetPixel(x, y, Color.FromArgb(0, 0, 0));
            }
            else
            {
                image.SetPixel(x, y, Color.FromArgb(255, 255, 255));
            }
        }

        public void SetRandomImg()
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    SetRandomBWPixel(x, y);
                }
            }
        }

        public void SaveImg(string path)
        {
            image.Save(path);
        }
    }
    
}
