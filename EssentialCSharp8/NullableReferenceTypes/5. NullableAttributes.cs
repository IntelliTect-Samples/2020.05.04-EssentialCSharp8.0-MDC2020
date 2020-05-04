using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EssentialCSharp8.Tests.NullableReferenceTypes
{

    public static class DigitToTextConverter
    {
        static bool TryGetDigitAsText(
          char number, [NotNullWhen(true)]out string? text) =>
              (text = number switch
              {
                  '1' => "one",
                  '2' => "two",
                  // ...
                  '9' => "nine",
                  _ => null
              }) is string;

        [return: NotNullIfNotNull("text")]
        static public string? TryGetDigitsAsText(string? text)
        {
            if (text is null) return null;

            string result = "";
            foreach (char character in text)
            {
                if (TryGetDigitAsText(character, out string? digitText))
                {
                    if (result != "") result += '-';
                    result += digitText.ToLower();
                }
            }
            return result;
        }
    }
}
