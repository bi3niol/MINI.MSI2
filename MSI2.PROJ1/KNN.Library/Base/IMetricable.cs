using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Library.Base
{
    public interface IMetricable<T>
    {
        /// <summary>
        /// </summary>
        /// <param name="other"></param>
        /// <param name="p">norm (double.PositiveInfinity means infinity form)</param>
        /// <returns></returns>
        float NormP(T other, double p);
    }
}
