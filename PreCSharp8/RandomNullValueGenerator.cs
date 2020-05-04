using System;

namespace PreCSharp8
{
    public static class RandomNullValueGenerator
    {
        #region T GetReferenceValue<t>() {}
        // Cannot convert null literal to non-nullable reference or unconstrained type
        #pragma warning disable CS8625
        public static T GetReferenceValue<T>(T defaultNonNullValue) where T : class
        {
            Random random = new Random();
            if (random.Next(2) == 1)
                return null;
            else
                return defaultNonNullValue;
        }
        #pragma warning restore CS8625
        #endregion // T GetReferenceValue<t>() {}
    }
}
