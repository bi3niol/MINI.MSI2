using KNN.Library;
using KNN.Solver.IO;
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
        private AlgorithmEngine<KNN.Solver.ProblemEntities.Point, int> algorithm;
        private List<KNN.Solver.ProblemEntities.Point> treinSet;
        private List<KNN.Solver.ProblemEntities.Point> otherSet;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            algorithm = new AlgorithmEngine<KNN.Solver.ProblemEntities.Point, int>();
            trackBar1_Scroll(this, EventArgs.Empty);
            trackBar2_Scroll(this, EventArgs.Empty);
            graphManager = new GraphManager.GraphManager(zedGraphControl1);

            GraphPane myPane = zedGraphControl1.GraphPane;

            // Set the Titles
            myPane.Title.Text = "K-nearest neighbours";
            myPane.XAxis.Title.Text = "X Axis";
            myPane.YAxis.Title.Text = "Y Axis";
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

        private void button1_Click(object sender, EventArgs e)
        {
            bool canRun = true;
            string msg = "";
            if (algorithm.TrainSet == null)
            {
                msg = "Train set is null";
                canRun = false;
            }
            if (otherSet == null)
            {
                msg += "\n Test set is null";
                canRun = false;
            }
            if (canRun)
                graphManager.UpdateGraph(algorithm.KnnRun(otherSet));
            else
                MessageBox.Show(msg);
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var res = saveFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                zedGraphControl1.MasterPane.GetImage().Save(saveFileDialog1.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                treinSet = new TrainDataLoader().TryLoadData(openFileDialog1.FileName);
                algorithm.TrainSet = treinSet;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                otherSet = new TrainDataLoader().TryLoadData(openFileDialog1.FileName);
            }
        }
    }
}
