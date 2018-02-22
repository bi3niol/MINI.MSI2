using KNN.Library.ProblemEntities;
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
        public void UpdateGraph(List<KNN.Library.ProblemEntities.Point> points)
        {
            Dictionary<int, PointPairList> class_point = new Dictionary<int, PointPairList>();
            foreach (var point in points)
                if (class_point.ContainsKey(point.Classifier))
                    class_point[point.Classifier].Add(point.X,point.Y);
                else
                    class_point.Add(point.Classifier, new PointPairList( new double[]{ point.X },new double []{ point.Y}));
            // get a reference to the GraphPane
            GraphPane myPane = zedGraph.GraphPane;
            myPane.CurveList.Clear();
            foreach (var key in class_point.Keys)
                myPane.AddCurve("Set " + key, class_point[key], colors[key % colors.Length]).Line.IsVisible = false;

            zedGraph.AxisChange();
        }
    }
}
