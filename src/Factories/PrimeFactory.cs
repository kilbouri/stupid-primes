using System.Collections;

namespace StupidPrimes.Factories;

/// <summary>
/// Base class of prime factories. Provides automatic bounds checking on start and end range
/// and automates the implementation of <see cref="IEnumerable{int}" />.
/// </summary>
public abstract class PrimeFactory : IEnumerable<int>
{
    protected readonly int start, end;

    public PrimeFactory(int start = 0, int end = int.MaxValue)
    {
        if (start < 0) throw new ArgumentException($"{nameof(start)} must be positive", nameof(start));
        if (start >= end) throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}", nameof(end));

        this.start = start;
        this.end = end;
    }

    public abstract IEnumerator<int> GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
