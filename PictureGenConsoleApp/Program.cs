using RandomPictureGenLib.PictureGen;
using PictureGenConsoleApp.Menu;
namespace PictureGenConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                //string path = @"E:\dotnet projects\PictureGen\picture2\new.bmp";
                //Image image = new Image(100, 100);
                Image image = new Image(int.Parse(args[0]), int.Parse(args[1]));
                image.SetRandomImg();
                image.SaveImg(args[2]);
            }
            else
            {
                ConsoleMenu menu = new ConsoleMenu();
                bool exitMenu = false;
                while (exitMenu != true)
                {
                    exitMenu = menu.MenuSelection();
                }
            }
            
        }
    }
}