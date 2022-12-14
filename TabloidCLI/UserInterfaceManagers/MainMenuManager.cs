using System;

namespace TabloidCLI.UserInterfaceManagers
{
    public class MainMenuManager : IUserInterfaceManager
    {
        private const string CONNECTION_STRING = 
            @"Data Source=localhost\SQLEXPRESS;Database=TabloidCLI;Integrated Security=True";

        public IUserInterfaceManager Execute()
        {
            Console.WriteLine("       _________");
            Console.WriteLine("      /Hoot!     \\");
            Console.WriteLine("     (       Hoot!)");
            Console.WriteLine("      \\Hi, Friend!/");
            Console.WriteLine("       ---------");
            Console.WriteLine("          )/");
           

            Console.WriteLine("    ,___,");
            Console.WriteLine("    [O.o]");
            Console.WriteLine("    /)__)");
            Console.WriteLine("    -\"--\"-");
            Console.WriteLine();
            Console.WriteLine(" Welcome to the Tabloid720's Blog-Keeper App!");
            Console.WriteLine(" What would you like to do today?");
            Console.WriteLine();





            Console.WriteLine("====Main Menu====");
            Console.WriteLine();

            Console.WriteLine(" 1) Journal Management");
            Console.WriteLine(" 2) Blog Management");
            Console.WriteLine(" 3) Author Management");
            Console.WriteLine(" 4) Post Management");
            Console.WriteLine(" 5) Tag Management");
            Console.WriteLine(" 6) Search by Tag");
            Console.WriteLine(" 7) Change Background");

            Console.WriteLine(" 0) Exit");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {

                case "1": return new JournalManager(this, CONNECTION_STRING);
                case "2": return new BlogManager(this, CONNECTION_STRING);
                case "3": return new AuthorManager(this, CONNECTION_STRING);
                case "4": return new PostManager(this, CONNECTION_STRING);
                case "5": return new TagManager(this, CONNECTION_STRING);
                case "6": return new SearchManager(this, CONNECTION_STRING);
                case "7": return new ColorManager(this, CONNECTION_STRING);
                case "0":
                    Console.WriteLine("Good bye");
                    return null;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }
        }
    }
}
