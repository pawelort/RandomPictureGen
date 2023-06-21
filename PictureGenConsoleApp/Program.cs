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
                var pictureSaver = new WindowsPictureSaver();
                var imageAbstraction = new ImageAbstraction(int.Parse(args[0]), int.Parse(args[1]));
                var picture = new RandomPicture(imageAbstraction, pictureSaver);
                picture.PictureSaveToBmp(args[2]);
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