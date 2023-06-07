namespace RandomPictureGenLib.PictureGenInterfaces
{
    public interface IImageDTO
    {
        int Width { get; }
        int Height { get; }
        bool[,] imagePixels {get; set; }

        public bool IsPixelWhite(int x, int y);
    }
}