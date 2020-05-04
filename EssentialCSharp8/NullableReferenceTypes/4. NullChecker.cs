using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
#nullable disable
namespace EssentialCSharp8.Tests.NullableReferenceTypes
{

    public static class NullChecker
    {
        public static bool IsNull(this object thing)
        {
            return thing is null;
        }
        public static void AssertIsNotNull<T>(this T thing)
            where T: notnull
        {
            if(thing is null)
            {
                throw new ArgumentNullException(nameof(thing));
            }
        }
    }

#nullable enable

    [TestClass]
    public class NullCheckerTests
    {
        [TestMethod]
        public void IsNull_GivenNullObject_Success()
        {
            Assert.AreEqual(
                true, ((object?)null).IsNull());
        }

        [TestMethod]
        public void IsNull_GivenNullString_Success()
        {
            string text = "Inigo Montoya";
            Assert.AreEqual(
                false, text.IsNull());
        }

        [TestMethod]
        public void IsNull_GivenNullInt_Success()
        {
            Assert.IsTrue(
                5 is { });
        }

        [TestMethod]
        public void AssertIsNotNull_GivenText_Success()
        {
            ("Text").AssertIsNotNull();
        }
    }

}
