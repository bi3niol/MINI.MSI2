using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KNN.Library.ProblemEntities;

namespace KNN.Library.IO
{
	public class TrainDataLoader
	{
		private string filePath;

		public TrainDataLoader(string filePath)
		{
			this.filePath = filePath;
		}

		public List<Point> LoadData()
		{
			List<Point> trainData = new List<Point>();
#warning here data should be uploaded from csv file

			trainData.Add(new Point(0.2f, 0.1f));
			trainData.Add(new Point(0.23f, -0.5f));
			trainData.Add(new Point(0.56f, -0.2f));
			return trainData;
		}
	}
}
