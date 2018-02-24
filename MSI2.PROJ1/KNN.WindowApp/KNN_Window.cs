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
        private List<KNN.Solver.ProblemEntities.Point> trainData;
        private List<KNN.Solver.ProblemEntities.Point> testData;
        private int k;
        private double p;
        public KNN_Window()
        {
            InitializeComponent();
        }

        private void KNN_Window_Load(object sender, EventArgs e)
        {
            kTrackBar_Scroll(this, EventArgs.Empty);
            pTrackBar_Scroll(this, EventArgs.Empty);
            graphManager = new GraphManager.GraphManager(zedGraphControl);

            GraphPane graphPane = zedGraphControl.GraphPane;

            // Set the Titles
            graphPane.Title.Text = "K Nearest Neighbours";
            graphPane.XAxis.Title.Text = "X axis";
            graphPane.YAxis.Title.Text = "Y axis";
        }

        private void kTrackBar_Scroll(object sender, EventArgs e)
        {
            k = kTrackBar.Value;
            kLabel.Text = $"K = {k}";
        }

        private void pTrackBar_Scroll(object sender, EventArgs e)
        {
            if (pTrackBar.Maximum == pTrackBar.Value)
                p = double.PositiveInfinity;
            else
                p = pTrackBar.Value;
            pLabel.Text = $"P = {p.ToString()}";
        }

        private void RunBtn_Click(object sender, EventArgs e)
        {
            bool canRun = true;
            StringBuilder msg = new StringBuilder();
            if (trainData == null)
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
                graphManager.UpdateGraph(new AlgorithmEngine<KNN.Solver.ProblemEntities.Point, int>(k, p, trainData, testData).KnnRunParallel());
            else
                MessageBox.Show(msg.ToString(), "Warnings:");
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            var res = saveFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                zedGraphControl.MasterPane.GetImage().Save(saveFileDialog.FileName);
            }
        }

        private void loadTrainDataBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try {
                    trainData = new TrainDataLoader().LoadData(openFileDialog.FileName);
                    this.trainDataLabel.Text = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.trainDataLabel.Text = string.Empty;
                }
            }
        }

        private void loadTestDataBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try {
                    testData = new TrainDataLoader().LoadData(openFileDialog.FileName);
                    this.testDataLabel.Text = openFileDialog.FileName;
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                    this.testDataLabel.Text = string.Empty;
                }
            }
        }
    }
}
