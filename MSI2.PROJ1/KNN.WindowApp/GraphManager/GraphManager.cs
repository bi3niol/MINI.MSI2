using KNN.Solver.ProblemEntities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace KNN.WindowApp.GraphManager
{
    public class GraphManager
    {
        private static Color[] templateColors = new[]
        {
            Color.Blue,
            Color.DarkViolet,
            Color.DarkRed,
            Color.DarkGreen,
            Color.Yellow,
            Color.Silver,
            Color.Pink,
            Color.DarkOrange
        };
        private static Color[] classifiedColors = new[]
       {
            Color.LightBlue,
            Color.Violet,
            Color.Red,
            Color.LightGreen,
            Color.LightYellow,
            Color.LightGray,
            Color.LightPink,
            Color.Orange
        };
        private ZedGraphControl zedGraph;
        public GraphManager(ZedGraphControl zedGraph)
        {
            this.zedGraph = zedGraph;
        }

        public void ClearGraph()
        {
            zedGraph.GraphPane.CurveList.Clear();
        }

        public void UpdateGraph()
        {
            zedGraph.GraphPane.XAxis.Scale.Min = zedGraph.GraphPane.YAxis.Scale.Min = -1;
            zedGraph.GraphPane.XAxis.Scale.Max = zedGraph.GraphPane.YAxis.Scale.Max = 1;
            zedGraph.Invalidate();
        }

        public void PrintTemplatePoints(List<KNN.Solver.ProblemEntities.Point> points)
        {
            if (points != null)
                PrintPoints(points, 4, true, templateColors);
        }

        public void PrintClassifiedPoints(List<KNN.Solver.ProblemEntities.Point> points)
        {
            if (points != null)
                PrintPoints(points, 2, false, classifiedColors);
        }

        private void PrintPoints(List<KNN.Solver.ProblemEntities.Point> points, float markerSize, bool isLabelVisible, Color[] colors)
        {
            var groups = points.GroupBy((p) => { return p.Cluster; });
            foreach (var group in groups)
            {
                var curve = zedGraph.GraphPane.AddCurve("Cluster " + group.Key, new PointPairList(), GetColor(group.Key, colors), SymbolType.Circle);
                curve.Line.IsVisible = false;
                curve.Symbol.Fill = new Fill(curve.Color);
                curve.Symbol.Size = markerSize;
                curve.Label.IsVisible = isLabelVisible;
                foreach (var point in group)
                {
                    curve.AddPoint(point.X, point.Y);
                }

            }
        }

        private Color GetColor(int key, Color[] tab)
        {
            return tab[key % templateColors.Length];
        }
    }
}
