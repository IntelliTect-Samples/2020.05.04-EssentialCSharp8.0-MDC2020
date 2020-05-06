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
            //return thing == null;
            //return ReferenceEquals(thing, null);
            return thing is null;
        }

        public static void AssertIsNotNull<T>(this T thing)
            where T: class
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
        [NotNull]
        public TestContext? TestContext { get; set; }

        [TestMethod]
        public void IsNull_GivenNullObject_Success()
        {
            //mark@intellitect.com
            //kevin@intellitect.com

            string testName = TestContext.TestName;
            Assert.AreEqual(
                true, NullChecker.IsNull(null));
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
            Assert.IsFalse(
                42.IsNull());
        }

        public void Foo(string text)
        {
            text.AssertIsNotNull();
        }

        [TestMethod]
        public void AssertIsNotNull_GivenText_Success()
        {
            string? text = "Mark";
            Foo(text!);

            ((object)null).AssertIsNotNull();
        }
    }

}
