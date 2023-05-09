using RandomPictureGenLib.PictureGen;
namespace PictureGenConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string path = @"E:\dotnet projects\PictureGen\picture2\new.bmp";
            //Image image = new Image(100, 100);
            Image image = new Image(int.Parse(args[0]), int.Parse(args[1]));
            image.SetRandomImg();
            image.SaveImg(args[2]);

        }
    }
}