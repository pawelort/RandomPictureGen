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
                Image image = Image.CreateRectangle(int.Parse(args[0]), int.Parse(args[1]));
                var picture = image.CreateImage();
                PicSave.Path = args[2];
                PicSave.Save(picture, PicSave.Path);
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