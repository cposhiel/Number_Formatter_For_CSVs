
namespace NumberFormatterForCSVs
{ 
    /// <summary>
    /// Takes in a prefix to format a number to its internationalequivalent.
    /// </summary>
    internal class InternationalCodeNumberFormatter  : INumberFormatter
    {       
        public string FormatPhoneNumbers(string number, string prefix)
        {
            number = number.Trim(); //To remove whitespace before and after the strings.
            if (number.StartsWith("0") && int.TryParse(number, out int ignored)) //TryParse incase another data field (Email, Postcode, address etc.) starts with 0).
            {
               number = prefix + number.Substring(1);               
            }
            return number;
        }
    }
}
