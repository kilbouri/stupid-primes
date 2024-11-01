using System.Collections;

namespace StupidPrimes.Factories;

/// <summary>
/// A prime factory based on Willson's theorem:
/// https://en.wikipedia.org/wiki/Formula_for_primes
/// </summary>
public class WilsonsTheoremPrimeFactory(int start = 0, int end = int.MaxValue)
    : PrimeFactory(start, end)
{
    public override IEnumerator<int> GetEnumerator()
    {
        int minStart = Math.Max(2, start);
        int optimizedStart = (minStart % 2 == 0) ? minStart + 1 : minStart;

        // skip straight to (n-1)!
        int nMinusOneFac = Enumerable.Range(1, minStart - 1).Aggregate((acc, val) => acc * val);
        for (int n = minStart; n < optimizedStart && n < end; ++n)
        {
            if (IsPrime(n, nMinusOneFac)) yield return n;
            nMinusOneFac *= n;
        }

        for (int n = optimizedStart; n < end; n += 2)
        {
            if (IsPrime(n, nMinusOneFac)) yield return n;
            nMinusOneFac *= n * (n + 1);
        }

    }

    private static bool IsPrime(int n, int nMinusOneFac) => (nMinusOneFac + 1) % n == 0;
}

#region old
// using System.Collections;

// namespace StupidPrimes.Factories;

// /// <summary>
// /// A prime factory based on Willson's theorem:
// /// https://en.wikipedia.org/wiki/Formula_for_primes
// /// </summary>
// public class WilsonsTheoremPrimeFactory(int start = 0, int end = int.MaxValue)
//     : PrimeFactory(start, end)
// {
//     public override IEnumerator<int> GetEnumerator()
//     {
//         int optimizedStart = (start % 2 == 0) ? start + 1 : start;
//         int nMinusOneFac;

//         if (start < 2)
//         {
//             nMinusOneFac = 1;
//             for (int n = 2; n < optimizedStart && n < end; ++n)
//             {
//                 if (IsPrime(n, nMinusOneFac)) yield return n;
//                 nMinusOneFac *= n;
//             }
//         }
//         else
//         {
//             // skip straight to (n-1)!
//             nMinusOneFac = Enumerable.Range(1, start - 1).Aggregate((acc, val) => acc * val);
//             for (int n = start; n < optimizedStart && n < end; ++n)
//             {
//                 if (IsPrime(n, nMinusOneFac)) yield return n;
//                 nMinusOneFac *= n;
//             }
//         }

//         for (int n = optimizedStart; n < end; n += 2)
//         {
//             if (IsPrime(n, nMinusOneFac)) yield return n;
//             nMinusOneFac *= n * (n + 1);
//         }

//     }

//     private static bool IsPrime(int n, int nMinusOneFac) => (nMinusOneFac + 1) % n == 0;
// }
#endregion
