using System;
using System.Diagnostics;

namespace DS_UF
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10000000;

            IUnionFind uf3 = new UnionFind3(n);
            IUnionFind uf4 = new UnionFind4(n);
            IUnionFind uf5 = new UnionFind5(n);

            Console.WriteLine("uf3 time is  " + UnionFindTest(uf3, n));
            Console.WriteLine("uf4 time is  " + UnionFindTest(uf4, n));
            Console.WriteLine("uf5 time is  " + UnionFindTest(uf5, n));

        }

        static double UnionFindTest(IUnionFind uf, int n)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            Random rand = new Random();

            // 进行n次操作， 每次随机选择两个元素进行合并
            for (int i = 0; i < n; i++)
            {
                int a = rand.Next(n);
                int b = rand.Next(n);
                uf.UnitElement(a, b);
            }

            // 进行n次操作， 每次随机判断两个元素是否相连接
            for (int i = 0; i < n; i++)
            {
                int a = rand.Next(n);
                int b = rand.Next(n);
                uf.IsConnected(a, b);
            }

            sw.Stop();
            return sw.Elapsed.TotalSeconds;
        }
    }
}
