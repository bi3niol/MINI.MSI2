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
		/// <summary>
		/// number of neighbors
		/// </summary>
		public int K
		{
			get; set;
		}

		public AlgorithmEngine(int k, double p, List<T> trainSet)
		{
			K = k;
			P = p;
			TrainSet = trainSet;
		}

		public List<T> KnnRun(List<T> testData)
		{
			foreach (var item in testData)
				item.Classifier = GetMostCommonClassifier(GetKNeighbors(item));

			return testData;
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
			SortedList<float, T> sortedList = new SortedList<float, T>();
			foreach (var item in TrainSet) {
				float distance = item.NormP(element, P);
				if (sortedList.Count < K)
					sortedList.Add(distance, item);
				else if (sortedList.Max().Key > distance) {
					sortedList.Remove(sortedList.Max().Key);
					sortedList.Add(distance, item);
				}
			}
			return sortedList.Values.ToList();
		}
	}
}
