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
            string filePath;
            int k;
            if (!CheckAndResolveArgs(args, out filePath, out k))
                return;
            TrainDataLoader dataLoader = new TrainDataLoader(filePath);
			List<Point> trainData = dataLoader.TryLoadData();
            if (trainData == null) {
                return;
            }
            AlgorithmEngine<Point, int> engine = new AlgorithmEngine<Point, int>(k, 2, trainData);
            
		}

        private static bool CheckAndResolveArgs(string[] args, out string filePath, out int k) {
            filePath = string.Empty;
            k = -1;

            if (args.Length != 2) {
                PressAnyKey();
                return false;
            }
            filePath = args[0];
            if (!int.TryParse(args[1], out k)) {
                PressAnyKey();
                return false;
            }
            return true;
        }

        private static void PressAnyKey()
        {
#if DEBUG
            Console.WriteLine("Nieprawidłowe wywołanie.\nKNN.Solver <ścieżka_do_pliku> <k>");
            Console.WriteLine("Naciśnij ENTER aby zakończyć..");
            Console.Read();
#endif
        }
    }
}
