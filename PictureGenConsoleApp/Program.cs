﻿using RandomPictureGenLib.PictureGen;
using PictureGenConsoleApp.Menu;
namespace PictureGenConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                var imgAbstract = ImageAbstraction.CreateRectangle(int.Parse(args[0]), int.Parse(args[1]));
                using var image = PicCreate.CreateImage(imgAbstract);
                PicSave.Path = args[2];
                PicSave.Save(image, PicSave.Path);
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