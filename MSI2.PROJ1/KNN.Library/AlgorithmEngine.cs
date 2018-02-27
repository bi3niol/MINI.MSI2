using KNN.Library.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Library
{
	public sealed class AlgorithmEngine<T, TCluster> where T : IMetricable<T>, IClusterable<TCluster>
	{
		/// <summary>
		/// indicates norm
        /// PUBLIC SET
		/// </summary>
		public double P
		{
			get; set;
		}
		public List<T> TrainSet
		{
			get; private set;
		}
        /// <summary>
        /// PUBLIC SET
        /// </summary>
        public List<T> TestSet
        {
            get; set;
        }
        /// <summary>
        /// number of neighbors
        /// PUBLIC SET
        /// </summary>
        public int K
		{
			get; set;
		}

		public AlgorithmEngine(int k, double p, List<T> trainSet, List<T> testSet)
		{
			K = k;
			P = p;
			TrainSet = trainSet;
            TestSet = testSet;
		}


        public List<T> KnnRunParallel()
        {
            this.TestSet.AsParallel().ForAll(x => { x.Cluster = GetMostCommonClassifier(GetKNeighbors(x)); });

            return this.TestSet;
        }

        private TCluster GetMostCommonClassifier(List<T> list)
		{
			Dictionary<TCluster, int> counters = new Dictionary<TCluster, int>();
			TCluster res = default(TCluster);
			int count = 0;
			foreach (var item in list)
			{
				var key = item.Cluster;
				if (counters.ContainsKey(key))
					counters[key]++;
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
