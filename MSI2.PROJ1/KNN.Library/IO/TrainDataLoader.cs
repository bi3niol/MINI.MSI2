using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Library.IO
{
	public class TrainDataLoader<T>
	{
		private string filePath;

		public TrainDataLoader(string filePath)
		{
			this.filePath = filePath;
		}

		public List<T> LoadData()
		{
			List<T> trainData = new List<T>();
#warning here data should be uploaded from csv file

			return trainData;
		}
	}
}
