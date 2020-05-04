using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCSharp8.Tests.AsyncStreams
{

    public interface IAsyncDisposable
    {
        Task DisposeAsync();
    }

    public interface IAsyncEnumerable<out T>
    {
        IAsyncEnumerator<T> GetAsyncEnumerator();
    }

    public interface IAsyncEnumerator<out T> : IAsyncDisposable
    {
        Task<bool> MoveNextAsync();
        T Current { get; }
    }
}
