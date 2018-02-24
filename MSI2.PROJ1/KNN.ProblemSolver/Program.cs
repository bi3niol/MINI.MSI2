using KNN.Library;
using KNN.Solver.IO;
using KNN.Solver.ProblemEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Solver
{
	class Program
	{
		static void Main(string[] args)
		{
            string trainFilePath;
            string testFilePath;
            int k;
            if (!CheckAndResolveArgs(args, out trainFilePath, out testFilePath, out k))
                return;
            TrainDataLoader dataLoader = new TrainDataLoader();
            List<Point> trainData;
            List<Point> testData;
            try
            {
                trainData = dataLoader.LoadData(trainFilePath);
                testData = dataLoader.LoadData(testFilePath);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return;
            }
            AlgorithmEngine<Point, int> engine = new AlgorithmEngine<Point, int>(k, 2, trainData, testData);
            var results = engine.KnnRun();
            PressAnyKey(false);
		}

        private static bool CheckAndResolveArgs(string[] args, out string trainFilePath, out string testFilePath, out int k) {
            trainFilePath = string.Empty;
            testFilePath = string.Empty;
            k = -1;

            if (args.Length != 3) {
                PressAnyKey();
                return false;
            }
            trainFilePath = args[0];
            testFilePath = args[1];
            if (!int.TryParse(args[2], out k)) {
                PressAnyKey();
                return false;
            }
            return true;
        }

        private static void PressAnyKey(bool warn = true)
        {
#if DEBUG
            if(warn)
                Console.WriteLine("Nieprawidłowe wywołanie.\nKNN.Solver <train_file_path> <test_file_path> <k>");
            Console.WriteLine("Naciśnij ENTER aby zakończyć..");
            Console.Read();
#endif
        }
    }
}
