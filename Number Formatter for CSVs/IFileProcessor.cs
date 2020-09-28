
using System.Threading.Tasks;

namespace NumberFormatterForCSVs
{
    /// <summary>
    /// Interface to allow another FileProcessing system to plug in instead of current ones.
    /// </summary>
    internal interface IFileProcessor
    {
        string FormatTextFile(string filePath, string destPath);       
    }
}