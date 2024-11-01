using System.Text.RegularExpressions;

namespace StupidPrimes.Factories;

/// <summary>
/// Uses a regex to determine if the length of a string is prime or not.
/// https://www.youtube.com/watch?v=5vbk0TwkokM    
/// </summary>
public partial class RegexPrimeFactory(int start = 0, int end = int.MaxValue)
    : PrimeFactory(start, end)
{
    [GeneratedRegex(@"^.?$|^(..+?)\1+$")]
    private static partial Regex CompositeLengthRegex();
    private static bool IsPrime(ReadOnlySpan<char> view) => !CompositeLengthRegex().IsMatch(view);

    public override IEnumerator<int> GetEnumerator()
    {
        string @string = new('0', end);
        int optimizedStart = (start % 2 == 0) ? start + 1 : start;

        for (int n = start; n < optimizedStart && n < end; ++n)
        {
            if (IsPrime(@string.AsSpan(0, n))) yield return n;
        }

        for (int n = optimizedStart; n < end; n += 2)
        {
            if (IsPrime(@string.AsSpan(0, n))) yield return n;
        }
    }
}
