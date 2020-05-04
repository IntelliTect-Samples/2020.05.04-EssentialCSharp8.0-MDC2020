using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EssentialCSharp8.Tests.PreviewFeatures
{
    [TestClass]
    public class SwitchTests
    {

        public string SwitchingMessage()
        {
            string text = Guid.NewGuid().ToString();

            switch (text[0])
            {
                case char n when char.IsDigit(n):
                    int number = int.Parse(n.ToString());
                    return $"'{n}' is a digit - {number}";
                case char c:
                    return $"'{c}' is not a digit";
                default:
                    throw new Exception("Shouldn't get here...");
            }
        }

public string RemovePathJoin(string path)
{
    if (path[path.Length - 1] == System.IO.Path.DirectorySeparatorChar)
    {
        path = path.Remove(path.Length - 1, 1);
    }
    return path;
}

class Person(string FirstName, string LastName);

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
    Task<bool> MoveNextAsync(); T Current { get; }
}


}
