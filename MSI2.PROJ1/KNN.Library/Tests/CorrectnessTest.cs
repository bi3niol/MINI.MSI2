using KNN.Library.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Library.Tests
{
   public sealed class CorrectnessTest<TElement, TCluster> where TElement: IClusterable<TCluster>
    {
        public TCluster[] GoodClassification { get; set; }
        
        public double RunTest(List<TElement> list)
        {
            if(GoodClassification == null || GoodClassification.Length != list.Count)
                throw new InvalidOperationException("GoodClassification is null or number of tested elements is not equal to the number of elements in GoodClassification");

            double correct = 0;
            for (int i = 0; i < GoodClassification.Length; i++)
                correct += GoodClassification[i].Equals(list[i].Cluster) ? 1 : 0;

            return correct/GoodClassification.Length*100;
        }
    }
}
