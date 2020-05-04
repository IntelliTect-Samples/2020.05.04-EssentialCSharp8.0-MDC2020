using Microsoft.VisualStudio.TestTools.UnitTesting;
using PreCSharp8;
using System;

namespace EssentialCSharp8.Tests.NullableReferenceTypes

{
    [TestClass]
    public class NullableReferenceTypeTests
    {
        readonly Address Number10 = new Address(
            street1: "10 Downing Street",
            city: "London",
            zip: "SW1A 2AB",
            country: "United Kingdom"
            );

        #region PROVIDE SYNTAX TO EXPECT NULL
#nullable disable

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void A_NullableReferenceTypeReturnsNullForLength()
        {
            Assert.AreEqual<int?>(
                null,
                Number10.Street2.Length);
        }

#nullable enable
        [TestMethod]
        public void B_CheckingForNullAvoidsTheWarning()
        {
            string? text;

            text = Number10.Street2;

            if (text is null)
            {
                return;
            }
            else
            {
                Assert.AreEqual<int?>(
                    null,
                    text.Length);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void B_AssigningNullCausesWarnings()
        {
            Address address = new Address(
                street1: "10 Downing Street",
                street2: null,
                city: "London",
                zip: null,
                country: "United Kingdom");

            //  A non-nullable type will not issue a nullility warning check.
            Assert.AreEqual<int?>(
                null, address.Zip.Length);
        }

        [TestMethod]
        public void C_ThreeCategoriesOfReferenceTypes()
        {

            // Nullable Reference Types
            string? text1 = null;
            Assert.IsNull(text1);

            // Non-Nullable Reference Types
#if ExplicitNonNullableReferenceType
            string! text2 = "Inigo Montoya";
            Assert.AreEqual<string!>(
                "Inigo Montoya", text2);
#endif

            // I Don't Know Reference Types
            string text3 = RandomNullValueGenerator.GetReferenceValue(
                    defaultNonNullValue: "non-null");
            Assert.IsTrue(text3 == null || text3 == "non-null");
        }
        #endregion PROVIDE SYNTAX TO EXPECT NULL

        #region MAKE DEFAULT REFERENCE TYPES EXPECT NON-NULLABLE
        [TestMethod]
        public void D_ReferenceTypeExpectNonNullByDefault()
        {
            Address GetNullAddress() { return null; }

            Address? address = null;

            address = GetNullAddress();

            if (address != null)
            {
                Assert.AreEqual<Address>(Number10, address);
            }
        }
        #endregion MAKE DEFAULT REFERENCE TYPES EXPECT NON-NULLABLE

        #region DECREASE THE OCCURRENCE OF NULLREFERENCEEXCEPTIONS
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void E_StaticCodeAnalysisProidesOpportunitiesToCorrectErrorsAtCompileTime()
        {
            string sampleText = "sample text";

            string text1 = null; // Warning: Cannot convert null to non-nullable reference

            string? text2 = null;

            string text3 = text2; // Warning: Possible null reference assignment

            Assert.AreNotEqual<int?>(
                sampleText.Length, text2.Length); // Warning: Possible dereference of a null reference
        }
        #endregion DECREASE THE OCCURRENCE OF NULLREFERENCEEXCEPTIONS

        #region STATIC FLOW ANALYSIS IS LIMITED
        [TestMethod]
        public void F_TrustMe_Im_A_Programmer()
        {
            string? text = null;

            static bool IsNotNull(object? thing) => !(thing is null);

            if (IsNotNull(text))
            {
                Assert.AreEqual<Type>(typeof(string), text.GetType());
            }

        }
        #endregion STATIC FLOW ANALYSIS IS LIMITED

        #region UNDER THE COVERS

        [TestMethod]
        public void F_WorkingWithVar()
        {
            static T? GetNullableReferenceType<T>() where T : class => default;
            var text1 = GetNullableReferenceType<string>();
            text1 = null;

            
            string text2 = text1!;
            Assert.IsNull(text2);


            string text4 = default;
            text2 = text4.ToString();

            var text3 = RandomNullValueGenerator.GetReferenceValue<string>("non-null");
            text2 = text3;  // text3 is a treated as a string (not a nullable string)
                            // even though its value could be null.
            Assert.IsTrue(text2 == null || text2 == "non-null");
        }
        #endregion UNDER THE COVERS
    }
}
