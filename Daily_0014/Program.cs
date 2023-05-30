namespace Daily_0014
{
    internal class Program
    {
        static void Main (string[] args)
        {
            for (int i = 0; i < 10; ++i)
            {
                var pi = MonteCarlo();
                Console.WriteLine($"Out value is within {Math.Abs(pi / Math.PI - 1):F4}% of the correct value");
            }
        }

        static double MonteCarlo()
        {
            int n = 0;
            int p = 0;
            Random rand = new Random();
            while(!RoundsToPi(p, n))
            {
                n++;
                double x = rand.NextDouble() - 0.5;
                double y = rand.NextDouble() - 0.5;

                if (DistanceFromOrigin(x, y) < 0.5)
                    ++p;
            }

            return (double)p / n * 4.0;
        }

        static double DistanceFromOrigin(double x, double y)
        {
            return Math.Sqrt((x * x) + (y * y));
        }

        static bool RoundsToPi(int p, int n)
        {
            if (n is 0)
                return false;

            var value = Math.Abs((double)p / n) * 4;
            var difference = Math.Abs(Math.PI - value);

            return difference < 0.0005 && difference != 0;
        }
    }
}