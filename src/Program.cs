using StupidPrimes.Factories;

foreach (var prime in new WilsonsTheoremPrimeFactory(5, int.MaxValue >> 2))
{
    Console.WriteLine(prime);
}
