using RandomPictureGenLib.PictureGen;
using RandomPictureGenLib.PictureGenInterfaces;
using PictureGenConsoleApp.Menu;
namespace PictureGenConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var pictureSavers = new List<IPictureSaver>()
                {
                    WindowsPictureFactorySaver.WindowsPictureJpgSaver(),
                    WindowsPictureFactorySaver.WindowsPictureBmpSaver(),
                    WindowsPictureFactorySaver.WindowsPicturePngSaver()
                };
                
                var imageAbstraction = new ImageAbstraction(int.Parse(args[0]), int.Parse(args[1]));
                var picture = new RandomPicture(imageAbstraction, pictureSavers);
                picture.PictureSave(args[2]);

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