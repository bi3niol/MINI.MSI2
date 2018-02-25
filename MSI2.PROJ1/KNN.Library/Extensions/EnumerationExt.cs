using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Library.Extensions
{
    public static class EnumerationExt
    {
        public static IEnumerable TakeEverNth(this IEnumerable collection, int n)
        {
            int i = 0;
            foreach (var item in collection)
            {
                if (i++ % n == 0)
                    yield return item;
            }
        }
    }
}
