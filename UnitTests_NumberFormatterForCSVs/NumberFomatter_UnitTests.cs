using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using NumberFormatterForCSVs;

namespace UnitTests_NumberFormatterForCSVs
{
    [TestClass]
    public class NumberFomatter_UnitTests
    {
        //These three tests prove the use cases required for the Number Formatter.
        [TestMethod]
        public void NumbersStatingWith0FormattedToPlus353()
        {
            //Arrange
            string number = "0873645577";
            //Act
            number = NumberFormatter.FormatIrishToInternational(number);
            //Assert
            Assert.AreEqual("+353873645577", number);
        }
        [TestMethod]
        public void ANumberThatStartsWithWhiteSpaceIsStillFormattedCorrectly()
        {
            //Arrange
            string number = "  089456782";
            //Act
            number = NumberFormatter.FormatIrishToInternational(number);
            //Assert
            Assert.AreEqual("+35389456782", number);

        }
        [TestMethod]
        public void OnlyPhoneNumberIsAffectedWhenAStringArrayOfDataIsPassedThroughInAForEachLoop() 
        {
            //Arrange
            int i = 0;
            string[] data = { "Conal", "O'Shiel", "007TheBondKing@gmail.com", " 0879359988" };
            string[] result = new string[4];
            //Act
            foreach (var str in data)
            {
                result[i] = NumberFormatter.FormatIrishToInternational(str);
                i++;
            }
            //Assert            
            Assert.AreEqual(result[0], data[0]);
            Assert.AreEqual(result[1], data[1]);
            Assert.AreEqual(result[2], data[2]);
            Assert.AreEqual("+353879359988", result[3]);
        }
    }
}
