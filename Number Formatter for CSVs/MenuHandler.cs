using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NumberFormatterForCSVs
{
    enum MenuOptions
    {
        Format = 1,
        Exit,
        InvalidOption
    }
    internal class MenuHandler
    {
        /// <summary>
        /// Gets and parses the enum.
        /// </summary>                      
        /// <returns></returns>             
        internal static MenuOptions GetMenuOption()
        {
            PrintMenu();
            string choice = Console.ReadLine();
            MenuOptions option = Enum.TryParse(choice, out option) ? option : MenuOptions.InvalidOption;
            return option;
        }
        /// <summary>
        /// Handles the options for the menu.
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        internal static bool HandleOption(MenuOptions option)
        {
            bool isExit = false;

                switch (option)
                {
                    case MenuOptions.Format:
                    try
                    {
                        IFileProcessor csvFormatter = 
                            Factory.InstantiateFileProcessor(Factory.InstantiateNumberFormatter());
                        string[] paths = GetPaths();
                        string done = csvFormatter.FormatTextFile(paths[0], paths[1]);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;                  
                    case MenuOptions.Exit:
                        isExit = true;
                        break;
                    case MenuOptions.InvalidOption:
                        break;
                }
            return isExit;
        }
        /// <summary>
        /// Prints the Menu Options.
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("\n********************************");
            Console.WriteLine("Please select a valid option:");
            Console.WriteLine("Press 1 to format a CSV file.");
            Console.WriteLine("Press 2 to exit.");
            Console.Write(":> ");
        }
        /// <summary>
        /// Informs user of task completion before allowing them to return to the menu.
        /// </summary>
        /// <param name="option"></param>
        internal static void PrintMenuCompletion(MenuOptions option)
        {
            if (option != MenuOptions.InvalidOption)
            {
                Console.WriteLine($"Press any key to return to the menu.");                
            }
            else
            {
                Console.WriteLine("Option invalid. Press any key to return to the menu.");
            }
            Console.ReadKey();
        }
        /// <summary>
        /// Gets the source file and the destination file paths.
        /// </summary>
        /// <returns></returns>
        private static string[] GetPaths()
        {
            Console.WriteLine("Please input file path.");
            string[] filePaths = new string[2];
            filePaths[0] = Console.ReadLine();
            Console.WriteLine("Please input destination path.");
            filePaths[1] = Console.ReadLine();
            return filePaths;
        }
    }
}
