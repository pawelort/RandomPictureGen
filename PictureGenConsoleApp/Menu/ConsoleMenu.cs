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
            Console.WriteLine("************************************************");
            Console.WriteLine("* Welcome in Simple Picture Generator Program *");
            Console.WriteLine("************************************************");
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
            Console.WriteLine("9: Quit program");
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
                case "9":
                    currentMenuDisply = MenuType.Exit;
                    break;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;

            }
        }

        private void DestinationPathMenu()
        {

        }

        private void WidthSizeMenu()
        {

        }

        private void HeightSizeMenu()
        {

        }
    }
}