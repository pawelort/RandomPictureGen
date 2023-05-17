using RandomPictureGenLib.PictureGen;
namespace PictureGenConsoleApp.Menu
{
    public class ConsoleMenu
    {
        private MenuType currentMenuDisply;
        private string userSelection;
        private Image image;
        public ConsoleMenu()
        {
            currentMenuDisply = MenuType.MainMenu;
            image = Image.CreateSquare(10);
            userSelection = "";

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
            Console.WriteLine("4: Show current settings");
            Console.WriteLine("5: Generate picture");
            Console.WriteLine("9: Quit program");

            ReadConsoleLine();

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
                    ShowSettings();
                    break;
                case "5":
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

            ReadConsoleLine();


            PicSave.Path = userSelection;
            if (PicSave.Path != "")
            {
                currentMenuDisply = MenuType.MainMenu;
            }

        }

        private void WidthSizeMenu()
        {
            Console.WriteLine("**********************");
            Console.WriteLine("* Specify width size *");
            Console.WriteLine("**********************");

            ReadConsoleLine();
            try
            {
                image.Width = int.Parse(userSelection);
                currentMenuDisply = MenuType.MainMenu;
            }
            catch (FormatException widthSizeExc)
            {
                Console.WriteLine(widthSizeExc.Message);
            }
        }

        private void HeightSizeMenu()
        {
            Console.WriteLine("***********************");
            Console.WriteLine("* Specify height size *");
            Console.WriteLine("***********************");

            ReadConsoleLine();
            try
            {
                image.Height = int.Parse(userSelection);
                currentMenuDisply = MenuType.MainMenu;
            }
            catch (FormatException heightSizeExc)
            {
                Console.WriteLine(heightSizeExc.Message);
            }
        }
        private void GeneratePicture()
        {
            try
            {
                var picture = image.CreateImage();
                PicSave.Save(picture, PicSave.Path);
            }
            catch (Exception generationExc)
            {
                Console.WriteLine(generationExc.Message);
            }
        }

        private void ShowSettings()
        {   
            Console.WriteLine($"Width of picture is set to {image.Width}");
            Console.WriteLine($"Height of picture is set to {image.Height}");
            Console.WriteLine($"Picture will be generated to {PicSave.Path}");
            Console.WriteLine("");
        }
        private void ReadConsoleLine()
        {
            Console.WriteLine("");
            userSelection = Console.ReadLine();
            Console.WriteLine("");
        }
    }
}