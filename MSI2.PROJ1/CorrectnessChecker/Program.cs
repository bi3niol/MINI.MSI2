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

            K_Test(alg, args[2]);
            alg.K = 6;
            P_Test(alg, args[2]);
            Console.Read();
        }

        private static void K_Test(AlgorithmEngine<Point, int> algorithm, string fileName)
        {
            Console.WriteLine("Running K test...");
            StringBuilder content = new StringBuilder();
            content.AppendLine("K;%");
            for (int k = 2; k < 20; k += 2)
            {
                Console.WriteLine($"k={k}...");
                algorithm.K = k;
                content.AppendLine($"{k};{test.RunTest(algorithm.KnnRunParallel())}");
            }
            Console.WriteLine("Saving results to file...");
            File.WriteAllText("K_"+fileName, content.ToString());
        }

        private static void P_Test(AlgorithmEngine<Point, int> algorithm, string fileName)
        {
            StringBuilder content = new StringBuilder();
            Console.WriteLine("Running P test...");
            content.AppendLine("P;%");
            for (int p = 2; p < 6; p++)
            {
                Console.WriteLine($"p={p}...");
                algorithm.P = p;
                content.AppendLine($"{p};{test.RunTest(algorithm.KnnRunParallel())}");
            }
            algorithm.P = double.PositiveInfinity;
            content.AppendLine($"{algorithm.P};{test.RunTest(algorithm.KnnRunParallel())}");
            Console.WriteLine("Saving results to file...");
            File.WriteAllText("P_"+fileName, content.ToString());
        }
    }
}
