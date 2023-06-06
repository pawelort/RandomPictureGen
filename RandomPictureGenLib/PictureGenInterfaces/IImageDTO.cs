namespace RandomPictureGenLib.PictureGenInterfaces
{
    public interface IImageDTO
    {
        int Width { get; }
        int Height { get; }
        bool[,] imagePixels {get; set; }
    }
}