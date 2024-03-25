namespace oop_lab_2
{
    public class Program
    {
        public static int res = 30;
        public static Func<int, int, int, int, int> f = (a, b, c, d) => a + 2 * b + 3 * c + 4 * d;
        public static Random r = new Random();

        static void Main(string[] args)
        {
            List<Generation> generators = new List<Generation>();
            for (int i = 0; i < 5; i++)
            {
                generators.Add(new Generation(f, r.Next(1, 30), r.Next(1, 30), r.Next(1, 30), r.Next(1, 30), res));

            }
            for (int i = 0; ; i++)
            {
                Console.WriteLine("Итерация " + (i + 1));
                foreach (var item in generators)
                {
                    Console.Write("a = " + item.a + " b = " + item.b + " c = " + item.c + " d = " + item.d + "\n");
                }
                Console.WriteLine("--------");

                double koef1 = Generation.SrKoef(generators);
                var best = generators
                    .OrderBy(g => g.GetAc())
                    .ToList();
                if (best.Any(g => g.RealResult == res))
                {
                    Solution(best[0]);
                    break;
                }

                generators.Clear();
                generators.Add(Generation.NewGen(best[0], best[1]));
                generators.Add(Generation.NewGen(best[1], best[0]));
                generators.Add(Generation.NewGen(best[0], best[2]));
                generators.Add(Generation.NewGen(best[2], best[0]));
                generators.Add(Generation.NewGen(best[1], best[2]));

                double koef2 = Generation.SrKoef(generators);
                if (koef2 <= koef1)
                {
                    Random ran = new Random();
                    int x = ran.Next(1, 5);
                    for (int j = 0; j < x; j++)
                    {
                        generators[ran.Next(0, 5)].Change();
                    }
                }
            }
        }

        public static void Solution(Generation g)
        {
            Console.WriteLine("Решение: ");
            Console.Write("a=" + g.a + " b=" + g.b + " c=" + g.c + " d=" + g.d + "\n");
        }

    }
}
