using KNN.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace KNN.WindowApp
{
    public partial class Form1 : Form
    {
        private GraphManager.GraphManager graphManager;
        private AlgorithmEngine<KNN.Library.ProblemEntities.Point, int> algorithm;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            algorithm = new AlgorithmEngine<Library.ProblemEntities.Point, int>(5, 2, new List<Library.ProblemEntities.Point>());
            graphManager = new GraphManager.GraphManager(zedGraphControl1);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            algorithm.K = trackBar1.Value;
            KLabel.Text = $"K = {algorithm.K}";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Maximum == trackBar2.Value)
                algorithm.P = double.PositiveInfinity;
            else
                algorithm.P = trackBar2.Value;
            PLabel.Text = $"P = {algorithm.P.ToString()}";
        }
    }
}
