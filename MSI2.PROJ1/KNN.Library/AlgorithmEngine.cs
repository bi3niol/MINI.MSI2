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
        public double P { get; set; }
        public List<T> TrainSet { get; set; }
        /// <summary>
        /// numbers of neighbors
        /// </summary>
        public int K { get; set; }

        //TODO: check it
        public List<T> KnnRun(List<T> testData)
        {
            foreach (var item in testData)
                item.Classifier = GetMostCommonClassifier(GetKNeighbors(item));

            return testData;
        }

        private TClassifier GetMostCommonClassifier(List<T> list)
        {
            if (list.Count > 0)
                if (list[0].Classifier is ValueType)
                    return GetMostCommonClassifier_ValueType(list);

            return GetMostCommonClassifier_RefType(list);
        }
        private TClassifier GetMostCommonClassifier_RefType(List<T> list)
        {
            throw new NotImplementedException();
            return default(TClassifier);
        }
        private TClassifier GetMostCommonClassifier_ValueType(List<T> list)
        {
            Dictionary<TClassifier, int> counter = new Dictionary<TClassifier, int>();
            TClassifier res = default(TClassifier);
            int count = 0;
            foreach (var item in list)
            {
                var key = item.Classifier;
                counter[key]++;
                if (count < counter[key])
                {
                    res = key;
                    count = counter[key];
                }
            }
           
            return res;
        }
        private List<T> GetKNeighbors(T element)
        {
            SortedList<float, T> sortedList = new SortedList<float, T>(new DescFloatComparer());
            foreach (var item in TrainSet)
                sortedList.Add(item.NormP(element, P), item);
            return sortedList.Values.Take(K).ToList();
        }
        class DescFloatComparer : IComparer<float>
        {
            public int Compare(float x, float y)
            {
                return Comparer<float>.Default.Compare(y, x);
            }
        }
    }
}
