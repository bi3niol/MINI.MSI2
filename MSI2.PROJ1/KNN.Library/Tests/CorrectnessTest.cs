using KNN.Library.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Library.Tests
{
   public sealed class CorrectnessTest<TElement,TClassifier> where TElement: IClassifiable<TClassifier>
    {
        public TClassifier[] GoodClassification { get; set; }
        
        public double RunTest(List<TElement> list)
        {
            if(GoodClassification==null || GoodClassification.Length != list.Count)
                throw new InvalidOperationException("GoodClassification is null or number of tested elements is not equals to number of elements in GoodClassification");

            double correct = 0;
            for (int i = 0; i < GoodClassification.Length; i++)
                correct += GoodClassification[i].Equals(list[i].Classifier) ? 1 : 0;

            return correct/GoodClassification.Length*100;
        }
    }
}
