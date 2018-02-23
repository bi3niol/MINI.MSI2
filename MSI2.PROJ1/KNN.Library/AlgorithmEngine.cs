using KNN.Library.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Library
{
	public sealed class AlgorithmEngine<T, TClassifier> where T : IMetricable<T>, IClassifiable<TClassifier>
	{
		/// <summary>
		/// indicates norm
		/// </summary>
		public double P
		{
			get; set;
		}
		public List<T> TrainSet
		{
			get; set;
		}

        public List<T> TestSet
        {
            get; set;
        }
        /// <summary>
        /// number of neighbors
        /// </summary>
        public int K
		{
			get; set;
		}

        public AlgorithmEngine() { }

		public AlgorithmEngine(int k, double p, List<T> trainSet, List<T> testSet)
		{
			K = k;
			P = p;
			TrainSet = trainSet;
            TestSet = testSet;
		}

        public List<Tuple<T, TClassifier>> KnnRun()
        {
            List<Tuple<T, TClassifier>> results = new List<Tuple<T, TClassifier>>();

            foreach (var item in TestSet)
            {
                Console.WriteLine("Trwa obliczanie...");
                results.Add(new Tuple<T, TClassifier>(item, GetMostCommonClassifier(GetKNeighbors(item))));
            }

            return results;
        }

        public List<T> KnnRun(List<T> testSet)
        {
            testSet.AsParallel().ForAll(x => { x.Classifier = GetMostCommonClassifier(GetKNeighbors(x)); });

            return testSet;
        }

        private TClassifier GetMostCommonClassifier(List<T> list)
		{
			Dictionary<TClassifier, int> counters = new Dictionary<TClassifier, int>();
			TClassifier res = default(TClassifier);
			int count = 0;
			foreach (var item in list)
			{
				var key = item.Classifier;
				if (counters.ContainsKey(key))
					counters[key]++;  //check if it not throws exception
				else
					counters.Add(key, 1);
				if (count < counters[key])
				{
					res = key;
					count = counters[key];
				}
			}
			return res;
		}
	
		private List<T> GetKNeighbors(T element)
		{
            SortedList<double, T> sortedList = new SortedList<double, T>(Comparer<double>.Default);
			foreach (var item in TrainSet) {
				double distance = item.NormP(element, P);
				if (sortedList.Count < K)
					sortedList.Add(distance, item);
				else if (sortedList.ElementAt(sortedList.Count - 1).Key > distance)
                {
                    sortedList.RemoveAt(sortedList.Count - 1);
                    sortedList.Add(distance, item);
                }
            }
			return sortedList.Values.ToList();
		}
	}
}
