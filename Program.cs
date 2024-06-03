using System.Transactions;

namespace monte_carlo
{
    
    internal class Program
    {
        public static Random rand = new Random();
        public static double correct = 0;
        public static double bad = 0;
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                RandomShoot(2, 3);
            }
            Console.WriteLine(FinalResult());
        }

        static void RandomShoot(double start, double end)
        {
            double x = rand.NextDouble() * (end - start) + start;
            double y = rand.NextDouble() * Math.Pow(end, 3);

            Compare(x, y);
        }
        static void Compare(double x, double y)
        {
            double result = Math.Pow(x, 3);
            if(result > y)
            {
                correct++;
            }
            else
            {
                bad++;
            }
        }

        static double FinalResult()
        {
            Console.WriteLine("correct: " + correct);
            Console.WriteLine("bad: " + bad);

            return correct / 10000 * Area(2, 3);
        }

        static double Area(double start, double end)
        {
            return (end - start) * Math.Pow(end, 3);
        }
    }
}