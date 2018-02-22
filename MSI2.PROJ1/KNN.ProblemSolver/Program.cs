using KNN.Library;
using KNN.Library.IO;
using KNN.Library.ProblemEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.ProblemSolver
{
	class Program
	{
		static void Main(string[] args)
		{
#warning TODO: read k and filePath from args
			int k = 4;
			string filePath = string.Empty;
			TrainDataLoader dataLoader = new TrainDataLoader(filePath);
			List<Point> trainData = dataLoader.LoadData();
            AlgorithmEngine<Point, int> engine = new AlgorithmEngine<Point, int>(k, 2, trainData);
            
		}
	}
}
