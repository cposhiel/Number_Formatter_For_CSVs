using System;
using System.IO;
using System.Threading.Tasks;

namespace NumberFormatterForCSVs
{
    /// <summary>
    /// This class takes in a file and formats the numbers.Then saves it to another file.
    /// </summary>
    internal class FileProcessor : IFileProcessor
    {
        private string prefix = "+353";
        public INumberFormatter NumberFormatter { get; }       
        public FileProcessor(INumberFormatter numberFormatter)
        {
            NumberFormatter = numberFormatter;
        }
        /// <summary>
        /// Asynchronously reads text from a file and returns it as a string.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>string</returns>
        public async Task<string> FormatTextFile(string filePath, string destPath)
        {
            int i = 0;
            string line = null;            
            try
            {
                if (File.Exists(filePath))
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using (BufferedStream bs = new BufferedStream(fs))
                    using (StreamReader sr = new StreamReader(bs))
                    {
                        do
                        {
                            line = await sr.ReadLineAsync();
                            await FormatLineAndSave(sr, line, destPath);
                            //The following is just to show progress on the console.
                            i++;
                            if (i % 1000 == 0)
                            {
                                Console.WriteLine($"Formatted {i}");
                            }
                        }
                        while (line != null);
                    };
                    return "done";
                }
                else
                {
                    throw new FileNotFoundException();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        ///  Asynchronously reads through a new file and writes the data to the end.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="newFilePath"></param>
        private async Task<string> WriteFile(string file, string newFilePath)
        {
            try
            {
                using (FileStream fs = new FileStream(newFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (TextWriter tw = new StreamWriter(bs))
                {

                    fs.Seek(0, SeekOrigin.End); //Seek is used over append to prevent the file from becoming WriteOnly.
                    await tw.WriteAsync(file + "\n");                   
                }
                return "done";
            }
            catch (Exception e)
            {
                throw e;
            }            
        }  
        /// <summary>
        /// T
        /// </summary>
        /// <param name="line"></param>
        /// <param name="destPath"></param>
        private async Task<bool> FormatLineAndSave(StreamReader sr, string line,string destPath)
        {
            bool isComplete = false;
            string data = null;
            if (line != null)
            {
                string[] csvValues = line.Split(',');                
                foreach (var field in csvValues)
                {
                    data += " " + NumberFormatter.FormatPhoneNumbers(field, prefix) + ",";
                }
                await WriteFile(data, destPath);
                isComplete = true;
            }
            return isComplete;
            
        }
    }
    
}
