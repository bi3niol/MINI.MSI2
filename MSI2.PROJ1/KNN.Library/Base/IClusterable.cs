using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Library.Base
{
    public interface IClusterable<T>
    {
        T Cluster { get; set; }
    }
}
