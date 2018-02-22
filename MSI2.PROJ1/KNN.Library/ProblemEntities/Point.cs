using KNN.Library.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNN.Project.Problem
{
	public class Point: IMetricable<Point>, IClassifiable<int>
	{
		public int Classifier
		{
			get; set;
		}
		public float X
		{
			get; private set;
		}
		public float Y
		{
			get; private set;
		}

		public Point(float x, float y)
		{
			X = x;
			Y = y;
			Classifier = -1;
		}

		public float NormP(Point other, double p)
		{
			if (p == double.PositiveInfinity)
				return Math.Max(Math.Abs(X - other.X), Math.Abs(Y - other.Y));

			float res = (float)Math.Pow(Math.Abs(X - other.X), p);
			res += (float)Math.Pow(Math.Abs(Y - other.Y), p);
			return (float)Math.Pow(res, 1.0 / p);
		}
	}
}
