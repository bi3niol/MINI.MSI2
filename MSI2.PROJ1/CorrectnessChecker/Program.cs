using KNN.Library;
using KNN.Library.Extensions;
using KNN.Library.Tests;
using KNN.Solver.IO;
using KNN.Solver.ProblemEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrectnessChecker
{
    class Program
    {
        private static int[] goodRes;
        private static CorrectnessTest<Point, int> test = new CorrectnessTest<Point, int>();
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("args");
                Console.WriteLine("[TrainSet] [TestSet] [outfilename] [N]");
                return;
            }

            TrainDataLoader loader = new TrainDataLoader();
            var TrainSet = loader.LoadData(args[0]);
            var TestSet = loader.LoadData(args[1]);
            int n = 5;
            if (args.Length == 4)
                if (!int.TryParse(args[3], out n))
                    n = 5;

            TestSet = TestSet.TakeEverNth(n).Cast<Point>().ToList();
            goodRes = TestSet.Select(x => x.Cluster).ToArray();

            test.GoodClassification = goodRes;
            var alg = new AlgorithmEngine<Point, int>(2, 2, TrainSet, TestSet);

           // K_Test(alg, args[2]);
            alg.K = 6;
           // P_Test(alg, args[2]);
            All_Test(alg, args[2]);
            Console.Read();
        }
        private static void All_Test(AlgorithmEngine<Point, int> algorithm, string fileName)
        {
            Console.WriteLine("All_Test");
            StringBuilder content = new StringBuilder();
            Console.WriteLine("K;P;%");
            content.AppendLine("K;P;%");
            double res;
            for (int i = 2; i <= 8; i += 2)
            {
                algorithm.P = i == 8 ? double.PositiveInfinity : i;
                for (int k = 1; k <= 100; k += 2)
                {
                    algorithm.K = k;
                    res = test.RunTest(algorithm.KnnRunParallel());
                    content.AppendLine($"{k};{algorithm.P};{res}");
                    Console.WriteLine($"{k};{algorithm.P};{res}");
                }
            }
            File.WriteAllText("K_P_" + fileName, content.ToString());
        }

        private static void K_Test(AlgorithmEngine<Point, int> algorithm, string fileName)
        {
            StringBuilder content = new StringBuilder();
            Console.WriteLine("K_Test");
            content.AppendLine("K;%");
            double res;
            for (int k = 2; k <= 22; k += 2)
            {
                algorithm.K = k==22?200:k;
                res = test.RunTest(algorithm.KnnRunParallel());
                content.AppendLine($"{k};{res}");
                Console.WriteLine($"{k};{res}");
            }
            File.WriteAllText("K_" + fileName, content.ToString());
        }

        private static void P_Test(AlgorithmEngine<Point, int> algorithm, string fileName)
        {
            StringBuilder content = new StringBuilder();
            Console.WriteLine("P_Test");
            content.AppendLine("P;%");
            Console.WriteLine("P;%");
            double res;
            for (int k = 2; k < 6; k += 1)
            {
                algorithm.P = k;
                res = test.RunTest(algorithm.KnnRunParallel());
                content.AppendLine($"{k};{res}");
                Console.WriteLine($"{k};{res}");
            }
            algorithm.P = double.PositiveInfinity;
            res = test.RunTest(algorithm.KnnRunParallel());
            content.AppendLine($"{algorithm.P};{res}");
            Console.WriteLine($"{algorithm.P};{res}");
            File.WriteAllText("P_" + fileName, content.ToString());
        }
    }
}
