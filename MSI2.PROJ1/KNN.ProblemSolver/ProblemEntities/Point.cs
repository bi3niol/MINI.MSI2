using KNN.Library.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Solver.ProblemEntities
{
	public class Point: IMetricable<Point>, IClusterable<int>
	{
		public int Cluster
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
			Cluster = cls;
		}

		public double NormP(Point other, double p)
		{
			if (p == double.PositiveInfinity)
				return Math.Max(Math.Abs(X - other.X), Math.Abs(Y - other.Y));

			double res = Math.Pow(Math.Abs(X - other.X), p);
			res += Math.Pow(Math.Abs(Y - other.Y), p);
			return Math.Pow(res, 1.0d / p);
		}
	}
}
