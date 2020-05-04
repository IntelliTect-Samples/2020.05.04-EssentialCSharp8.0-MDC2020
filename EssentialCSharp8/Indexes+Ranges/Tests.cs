using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialCSharp8.Tests.Indexes_Ranges
{
    class Tests
    {

        public void Test()
        {
            #if CSharp8
            Span<int> span;
            //new int[]{0, 1, 2, 3, 4, 5, 6, 7, 8}
            int[] array = Enumerable.Range(0, 9).ToArray();

            span = array[Range.Create(4, new Index(2, true))];
            Assert.AreEquivalent(new int[]{4, 5, 6}, span);

            span = array[4..^ 2]; // Range.Create(4, new Index(2, true))
            Assert.AreEquivalent(new int[]{4, 5, 6}, span);

            span = array[..^ 3]; // Range.ToEnd(new Index(3, true))
            Assert.AreEquivalent(new int[]{0, 1, 2, 3, 4, 5}, span);

            span = array[2..]; // Range.FromStart(2)
            Assert.AreEquivalent(new int[]{2, 3, 4, 5, 6, 7, 8}, span);

            span = array[Range.All()]; // array [Range.All()]
            Assert.AreEquivalent(new int[]{0, 1, 2, 3, 4, 5, 6, 7, 8}, span);
            #endif
        }
    }
}
