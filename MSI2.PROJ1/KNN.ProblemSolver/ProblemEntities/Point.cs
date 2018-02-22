using KNN.Library.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Solver.ProblemEntities
{
	public class Point: IMetricable<Point>, IClassifiable<int>
	{
		public int Classifier
		{
			get; set;
		}
		public double X
		{
			get; private set;
		}
		public double Y
		{
			get; private set;
		}

		public Point(double x, double y, int cls = -1)
		{
			X = x;
			Y = y;
			Classifier = cls;
		}

		public double NormP(Point other, double p)
		{
			if (p == double.PositiveInfinity)
				return Math.Max(Math.Abs(X - other.X), Math.Abs(Y - other.Y));

			double res = (double)Math.Pow(Math.Abs(X - other.X), p);
			res += (double)Math.Pow(Math.Abs(Y - other.Y), p);
			return (double)Math.Pow(res, 1.0 / p);
		}
	}
}
