using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
//#nullable enable
namespace EssentialCSharp8.Tests.NullableReferenceTypes
{

    public static class StringEx
    {
        public static string? ToPascalCase(this string? text)
        {
            if (text is null)
            {
                return text;
                //throw new ArgumentNullException(nameof(text));
            }

            // Forgive the use of string rather than StringBuilder :)
            string result = "";
            bool lastCharacterIsWhitespace = true;

            foreach (char character in text)
            {
                if (char.IsWhiteSpace(character))
                {
                    lastCharacterIsWhitespace = true;
                    result += character;
                }
                else if (!char.IsWhiteSpace(character))
                {
                    if (lastCharacterIsWhitespace)
                    {
                        result += char.ToUpper(character);
                    }
                    else
                    {
                        result += char.ToLower(character);
                    }
                    lastCharacterIsWhitespace = false;
                }
            }
            return result;
        }
    }
#nullable enable


    [TestClass]
    public class StringExTests
    {

        [TestMethod]
        public void ToPascalCase_GivenPascalCase_Success()
        {
            Assert.AreEqual(
                "Pascal Case", "Pascal Case".ToPascalCase());
        }
        [TestMethod]
        public void ToPascalCase_Givenpascalcase_Success()
        {
            Assert.AreEqual(
                "Pascal Case", "pascal case".ToPascalCase());
        }
        [TestMethod]
        public void ToPascalCase_GivenSpacepascalcase_Success()
        {
            Assert.AreEqual(
                " Pascal Case", " pascal case".ToPascalCase());
        }
        [TestMethod]
        public void ToPascalCase_GivenEmptyString_ReturnNull()
        {
            // Error Intentional
            Assert.AreEqual(
                null, "".ToPascalCase());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToPascalCase_GivenNull_ThrowArgumentNullException()
        {
            Assert.AreEqual(
                "Pascal Case", ((string?)null).ToPascalCase());
        }

        //[TestMethod]
        //public void ToPascalCase_GivenNull_Success()
        //{
        //    Assert.IsNull(((string?)null).ToPascalCase());
        //}
    }

}
