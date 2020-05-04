using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialCSharp8.Tests.Indexes_Ranges
{
    public readonly struct Range
    {
        public Index Start { get; }
        public Index End { get; }

        private Range(Index start, Index end)
        {
            this.Start = start;
            this.End = end;
        }

        public static Range Create(Index start, Index end) => new Range(start, end);
        public static Range FromStart(Index start) => new Range(start, new Index(0, fromEnd: true));
        public static Range ToEnd(Index end) => new Range(new Index(0, fromEnd: false), end);
        public static Range All() => new Range(new Index(0, fromEnd: false), new Index(0, fromEnd: true));
    }
}
