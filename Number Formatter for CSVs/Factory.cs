using System;
using System.Collections.Generic;
using System.Text;

namespace NumberFormatterForCSVs
{
    /// <summary>
    /// Standard factory class to new up instances.
    /// </summary>
    internal class Factory
    {
        internal static IFileProcessor InstantiateFileProcessor(INumberFormatter numberFormatter)
        {
            return new FileProcessor(numberFormatter);
        }
        internal static INumberFormatter InstantiateNumberFormatter()
        {
            return new InternationalCodeNumberFormatter();
        } 
    }
}
