namespace GPOSite.Algorithms
{
    public class A000045
    {
        static List<int> derevo = new List<int>();
        static int F(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 1;
            return F(n - 1) + F(n - 2);
        }
        static int RankFibonacci(int cur, int n)
        {

            if (n == 1 || n == 2)
                return 0;
            if (derevo[cur] == 0)
                return RankFibonacci(cur + 1, n - 1);

            return RankFibonacci(cur + 1, n - 2) + F(n - 1);
        }

        static void FibonacciGenerate(int num, int n)
        {
            if (n == 1 || n == 2)
                return;
            if (num < F(n - 1))
            {
                derevo.Add(0);
                FibonacciGenerate(num, n - 1);
            }
            else
            {
                derevo.Add(1);
                FibonacciGenerate(num - F(n - 1), n - 2);
            }


        }
        public List<string> Start(int n)
        {
            var response = new List<string>();  
            for (int r = 0; r < F(n); r++)
            {
                string amnyam = "";
                derevo.Clear();
                FibonacciGenerate(r, n);
                for (int i = 0; i < derevo.Count; i++)
                {
                    amnyam = $"{derevo[i]}";
                    response.Add(amnyam);
                }
                response.Add(" ");
                int a = RankFibonacci(0, n);
                response.Add(a.ToString());
                response.Add(" ");
            }
            return response;
        }
    }
}
