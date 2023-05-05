using PictureGenConsoleApp.PictureGen;
namespace PictureGenConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\dotnet projects\PictureGen\picture\new.bmp";
            BmpImg image = new BmpImg(int.Parse(args[0]), int.Parse(args[1]));
            image.SetRandomImg();
            image.SaveImg(path);

        }
    }
}