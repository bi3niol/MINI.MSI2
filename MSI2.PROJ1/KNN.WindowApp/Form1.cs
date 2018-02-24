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
    public partial class KNN_Window : Form
    {
        private GraphManager.GraphManager graphManager;
        private AlgorithmEngine<KNN.Solver.ProblemEntities.Point, int> algorithmEngine;
        private List<KNN.Solver.ProblemEntities.Point> trainData;
        private List<KNN.Solver.ProblemEntities.Point> testData;
        public KNN_Window()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            algorithmEngine = new AlgorithmEngine<KNN.Solver.ProblemEntities.Point, int>();
            trackBar1_Scroll(this, EventArgs.Empty);
            trackBar2_Scroll(this, EventArgs.Empty);
            graphManager = new GraphManager.GraphManager(zedGraphControl1);

            GraphPane myPane = zedGraphControl1.GraphPane;

            // Set the Titles
            myPane.Title.Text = "K-Nearest Neighbours";
            myPane.XAxis.Title.Text = "X axis";
            myPane.YAxis.Title.Text = "Y axis";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            algorithmEngine.K = trackBar1.Value;
            KLabel.Text = $"K = {algorithmEngine.K}";
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Maximum == trackBar2.Value)
                algorithmEngine.P = double.PositiveInfinity;
            else
                algorithmEngine.P = trackBar2.Value;
            PLabel.Text = $"P = {algorithmEngine.P.ToString()}";
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            bool canRun = true;
            StringBuilder msg = new StringBuilder();
            if (algorithmEngine.TrainSet == null)
            {
                msg.AppendLine("-Train data is required.");
                canRun = false;
            }
            if (testData == null)
            {
                msg.AppendLine("-Test data is required.");
                canRun = false;
            }
            if (canRun)
                graphManager.UpdateGraph(algorithmEngine.KnnRun(testData));
            else
                MessageBox.Show(msg.ToString(), "Warnings:");
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var res = saveFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                zedGraphControl1.MasterPane.GetImage().Save(saveFileDialog.FileName);
            }
        }

        private void loadTrainDataBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                trainData = new TrainDataLoader().TryLoadData(openFileDialog.FileName);
                algorithmEngine.TrainSet = trainData;
            }
        }

        private void loadTestDataBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                testData = new TrainDataLoader().TryLoadData(openFileDialog.FileName);
            }
        }
    }
}
