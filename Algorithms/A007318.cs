namespace GPOSite.Algorithms
{
    public class A007318
    {
        static List<int> derevo = new List<int>();
        private static int Combinations(int allNumbers, int perGroup)
        {
            if (allNumbers < perGroup)
            {
                Console.WriteLine("Too big number!");
                return -1;
            }

            int result = 1;
            for (int i = 1; i <= perGroup; i++)
            {
                result *= allNumbers - i + 1;
                result /= i;
            }

            return result;
        }
        public static int RankCombination(int k, int m, int n)
        {
            if (m == 0)
                return 0;
            if (m == n)
                return 0;
            if (derevo[k] == 0)
                return RankCombination(k + 1, m, n - 1);
            else
                return RankCombination(k + 1, m - 1, n - 1) + Combinations(n - 1, m);
        }

        public static void GenCombination(int num, int m, int n)
        {
            if (m == 0)
            {
                for (int i = 0; i < n; i++)
                    derevo.Add(0);
            }
            else if (m == n)
            {
                for (int i = 0; i < n; i++)
                    derevo.Add(1);
            }
            else
            {
                if (num < Combinations(n - 1, m))

                {
                    derevo.Add(0);
                    GenCombination(num, m, n - 1);
                }
                else
                {
                    derevo.Add(1);
                    GenCombination(num - Combinations(n - 1, m), m - 1, n - 1);
                }
            }
        }
        public string Start(int n, int m)
        {
            string Answer = "";
            for (int r = 0; r < Combinations(n, m); r++)
            {
                derevo.Clear();
                GenCombination(r, m, n);
                for (int i = 0; i < derevo.Count; i++)
                    Answer += derevo[i].ToString();
                Answer += $" Rank=  {r};";

                Answer += "\n";


            }
            return Answer;
        }
    }
}
