using RandomPictureGenLib.PictureGen;
namespace PictureGenConsoleApp.Menu
{
    public class ConsoleMenu
    {
        private MenuType currentMenuDisply;
        string userSelection;
        private string path;
        private int widthSize;
        private int heightSize;

        public ConsoleMenu()
        {
            currentMenuDisply = MenuType.MainMenu;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("************************************************");
            Console.WriteLine("* Welcome in Simple Picture Generator Program *");
            Console.WriteLine("************************************************");
            Console.ForegroundColor = ConsoleColor.White;
        }


        public bool MenuSelection()
        {
            switch (currentMenuDisply)
            {
                case MenuType.MainMenu:
                    MainMenu();
                    return false;
                case MenuType.Path:
                    DestinationPathMenu();
                    return false;
                case MenuType.WidthSize:
                    WidthSizeMenu();
                    return false;
                case MenuType.HeightSize:
                    HeightSizeMenu();
                    return false;
                case MenuType.Exit:
                    return true;
                default: return true;
            }
        }

        private void MainMenu()
        {
            Console.WriteLine("********************");
            Console.WriteLine("* Select an action *");
            Console.WriteLine("********************");

            Console.WriteLine("1: Specify destination path");
            Console.WriteLine("2: Specify width size");
            Console.WriteLine("3: Specify height size");
            Console.WriteLine("4: Generate picture");
            Console.WriteLine("9: Quit program\n");
            userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "1":
                    currentMenuDisply = MenuType.Path;
                    DestinationPathMenu();
                    break;
                case "2":
                    currentMenuDisply = MenuType.WidthSize;
                    WidthSizeMenu();
                    break;
                case "3":
                    currentMenuDisply = MenuType.HeightSize;
                    HeightSizeMenu();
                    break;
                case "4":
                    GeneratePicture();
                    break;
                case "9":
                    currentMenuDisply = MenuType.Exit;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.\n");
                    break;

            }
        }

        private void DestinationPathMenu()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("* Specify destination path *");
            Console.WriteLine("****************************");
            Console.WriteLine("");

            userSelection = Console.ReadLine();
            try
            {
                path = userSelection;
                currentMenuDisply = MenuType.MainMenu;
            }
            catch(Exception pathException)
            {
                Console.WriteLine(pathException.Message);
            }

        }

        private void WidthSizeMenu()
        {
            Console.WriteLine("**********************");
            Console.WriteLine("* Specify width size *");
            Console.WriteLine("**********************");
            Console.WriteLine("");

            userSelection = Console.ReadLine();
            try
            {
                widthSize = int.Parse(userSelection);
                currentMenuDisply = MenuType.MainMenu;
            }
            catch(Exception widthSizeExc)
            {
                Console.WriteLine(widthSizeExc.Message);
            }
        }

        private void HeightSizeMenu()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("* Specify height size *");
            Console.WriteLine("***********************");
            Console.WriteLine("");

            userSelection = Console.ReadLine();
            try
            {
                heightSize = int.Parse(userSelection);
                currentMenuDisply = MenuType.MainMenu;
            }
            catch(Exception heightSizeExc)
            {
                Console.WriteLine(heightSizeExc.Message);
            }
        }
        private void GeneratePicture()
        {
            try
            {
                Image image = new Image(widthSize, heightSize);
                image.SetRandomImg();
                image.SaveImg(path);
            }
            catch (Exception generationExc)
            {
                Console.WriteLine(generationExc.Message);
            }
        }
    }
}