using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabloidCLI.Models;

namespace TabloidCLI.UserInterfaceManagers
{
    internal class ColorManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;
        private string _connectionString;

        public ColorManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;
            _connectionString = connectionString;
        }

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Color Menu");
            Console.WriteLine("Select a color:");
            Console.WriteLine(" 1) Red");
            Console.WriteLine(" 2) Yellow");
            Console.WriteLine(" 3) Green");
            Console.WriteLine(" 4) Blue");
            Console.WriteLine(" 5) Fuchsia");
            Console.WriteLine(" 6) White");
            Console.WriteLine(" 7) Gray");
            Console.WriteLine(" 8) Default");

            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.BackgroundColor = ConsoleColor.Red;
                    return this;
                case "2":
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    return this;
                case "3":
                    Console.BackgroundColor = ConsoleColor.Green;
                    return this;
                case "4":
                    Console.BackgroundColor = ConsoleColor.Blue;
                    return this;
                case "5":
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    return this;
                case "6":
                    Console.BackgroundColor = ConsoleColor.White;
                    return this;
                case "7":
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    return this;
                case "8":
                    Console.ResetColor();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}
