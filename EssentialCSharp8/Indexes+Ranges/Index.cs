using System;
using System.Collections.Generic;
using System.Text;

namespace EssentialCSharp8.Tests.Indexes_Ranges
{
    public readonly struct Index
    {
        private readonly int _value;

        public int Value => _value < 0 ? ~_value : _value;
        public bool FromEnd => _value < 0;

        public Index(int value, bool fromEnd)
        {
            if (value < 0) throw new ArgumentException("Index must not be negative.", nameof(value));

            _value = fromEnd ? ~value : value;
        }

        public static implicit operator Index(int value)
            => new Index(value, fromEnd: false);
    }
}
