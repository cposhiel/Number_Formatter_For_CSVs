using Microsoft.VisualBasic;
using System;
using System.ComponentModel.Design;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace NumberFormatterForCSVs
{
    /*write a program (a console application or a script will do) that reads the CSV
    file, normalizes all phone numbers to an Irish international format (with the prefix +353), and
    saves the result in a different output file.

    ---The following programme works by asynchronously reading a specified csv file, formatting the data according to the requirements
    and asynchronously writing it to a specified location/file. If the data is written to a file that already contains
    data, it will append the data to the end of that file.
     */
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            bool isExit = false;
            do
            {
                MenuOptions option = MenuHandler.GetMenuOption();
                isExit = MenuHandler.HandleOption(option);
                MenuHandler.PrintMenuCompletion(option);
            }
            while (isExit == false);
        }
    }
}
