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
        private static Color[] colors = new[]
        {
            Color.Aqua,
            Color.DarkCyan,
            Color.DarkBlue,
            Color.DarkGreen,
            Color.Red,
            Color.Silver,
            Color.Beige,
            Color.Gold
        };
        private ZedGraphControl zedGraph;
        public GraphManager(ZedGraphControl zedGraph)
        {
            this.zedGraph = zedGraph;
        }
        public void UpdateGraph(List<KNN.Solver.ProblemEntities.Point> points)
        {
            zedGraph.GraphPane.CurveList.Clear();
            var groups = points.GroupBy((p) => { return p.Cluster; });
            foreach (var group in groups)
            {
                var curve = zedGraph.GraphPane.AddCurve("Class " + group.Key, new PointPairList(), colors[group.Key % colors.Length], SymbolType.Circle);
                curve.Line.IsVisible = false;
                curve.Symbol.Fill = new Fill(curve.Color);
                foreach (var point in group)
                {
                    curve.AddPoint(point.X, point.Y);
                }

            }
            zedGraph.GraphPane.XAxis.Scale.Min = zedGraph.GraphPane.YAxis.Scale.Min = -1;
            zedGraph.GraphPane.XAxis.Scale.Max = zedGraph.GraphPane.YAxis.Scale.Max = 1;

            zedGraph.Invalidate();
        }
    }
}
