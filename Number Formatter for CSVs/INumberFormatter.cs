using System.Threading.Tasks;

namespace NumberFormatterForCSVs
{
    internal interface INumberFormatter
    {
        string FormatPhoneNumbers(string filePath, string internationalCode);
    }
}