namespace KNN.WindowApp
{
    partial class KNN_Window
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.kTrackBar = new System.Windows.Forms.TrackBar();
            this.kLabel = new System.Windows.Forms.Label();
            this.pTrackBar = new System.Windows.Forms.TrackBar();
            this.pLabel = new System.Windows.Forms.Label();
            this.runBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadTrainDataBtn = new System.Windows.Forms.Button();
            this.loadTestDataBtn = new System.Windows.Forms.Button();
            this.trainDataLabel = new System.Windows.Forms.Label();
            this.testDataLabel = new System.Windows.Forms.Label();
            this.runKnnForSurfaceBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.kTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(518, 518);
            this.zedGraphControl.TabIndex = 0;
            // 
            // kTrackBar
            // 
            this.kTrackBar.Location = new System.Drawing.Point(774, 61);
            this.kTrackBar.Maximum = 20;
            this.kTrackBar.Minimum = 1;
            this.kTrackBar.Name = "kTrackBar";
            this.kTrackBar.Size = new System.Drawing.Size(104, 45);
            this.kTrackBar.TabIndex = 1;
            this.kTrackBar.Value = 4;
            this.kTrackBar.Scroll += new System.EventHandler(this.kTrackBar_Scroll);
            // 
            // kLabel
            // 
            this.kLabel.AutoSize = true;
            this.kLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kLabel.Location = new System.Drawing.Point(679, 61);
            this.kLabel.Name = "kLabel";
            this.kLabel.Size = new System.Drawing.Size(22, 24);
            this.kLabel.TabIndex = 2;
            this.kLabel.Text = "K";
            // 
            // pTrackBar
            // 
            this.pTrackBar.Location = new System.Drawing.Point(774, 112);
            this.pTrackBar.Maximum = 20;
            this.pTrackBar.Minimum = 1;
            this.pTrackBar.Name = "pTrackBar";
            this.pTrackBar.Size = new System.Drawing.Size(104, 45);
            this.pTrackBar.TabIndex = 1;
            this.pTrackBar.Value = 2;
            this.pTrackBar.Scroll += new System.EventHandler(this.pTrackBar_Scroll);
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pLabel.Location = new System.Drawing.Point(679, 112);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(22, 24);
            this.pLabel.TabIndex = 2;
            this.pLabel.Text = "P";
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(683, 453);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(195, 23);
            this.runBtn.TabIndex = 3;
            this.runBtn.Text = "Run K-NN";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.RunBtn_Click);
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(683, 482);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(195, 23);
            this.SaveBtn.TabIndex = 4;
            this.SaveBtn.Text = "Save plot";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // loadTrainDataBtn
            // 
            this.loadTrainDataBtn.Location = new System.Drawing.Point(683, 220);
            this.loadTrainDataBtn.Name = "loadTrainDataBtn";
            this.loadTrainDataBtn.Size = new System.Drawing.Size(195, 23);
            this.loadTrainDataBtn.TabIndex = 5;
            this.loadTrainDataBtn.Text = "Load train data";
            this.loadTrainDataBtn.UseVisualStyleBackColor = true;
            this.loadTrainDataBtn.Click += new System.EventHandler(this.loadTrainDataBtn_Click);
            // 
            // loadTestDataBtn
            // 
            this.loadTestDataBtn.Location = new System.Drawing.Point(683, 279);
            this.loadTestDataBtn.Name = "loadTestDataBtn";
            this.loadTestDataBtn.Size = new System.Drawing.Size(195, 23);
            this.loadTestDataBtn.TabIndex = 6;
            this.loadTestDataBtn.Text = "Load test data";
            this.loadTestDataBtn.UseVisualStyleBackColor = true;
            this.loadTestDataBtn.Click += new System.EventHandler(this.loadTestDataBtn_Click);
            // 
            // trainDataLabel
            // 
            this.trainDataLabel.AutoSize = true;
            this.trainDataLabel.Location = new System.Drawing.Point(680, 204);
            this.trainDataLabel.Name = "trainDataLabel";
            this.trainDataLabel.Size = new System.Drawing.Size(0, 13);
            this.trainDataLabel.TabIndex = 7;
            // 
            // testDataLabel
            // 
            this.testDataLabel.AutoSize = true;
            this.testDataLabel.Location = new System.Drawing.Point(683, 263);
            this.testDataLabel.Name = "testDataLabel";
            this.testDataLabel.Size = new System.Drawing.Size(0, 13);
            this.testDataLabel.TabIndex = 8;
            // 
            // button1
            // 
            this.runKnnForSurfaceBtn.Location = new System.Drawing.Point(683, 424);
            this.runKnnForSurfaceBtn.Name = "button1";
            this.runKnnForSurfaceBtn.Size = new System.Drawing.Size(195, 23);
            this.runKnnForSurfaceBtn.TabIndex = 9;
            this.runKnnForSurfaceBtn.Text = "Run K-NN for surface";
            this.runKnnForSurfaceBtn.UseVisualStyleBackColor = true;
            this.runKnnForSurfaceBtn.Click += new System.EventHandler(this.KnnForSurface_Click);
            // 
            // KNN_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 542);
            this.Controls.Add(this.runKnnForSurfaceBtn);
            this.Controls.Add(this.testDataLabel);
            this.Controls.Add(this.trainDataLabel);
            this.Controls.Add(this.loadTestDataBtn);
            this.Controls.Add(this.loadTrainDataBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.pLabel);
            this.Controls.Add(this.kLabel);
            this.Controls.Add(this.pTrackBar);
            this.Controls.Add(this.kTrackBar);
            this.Controls.Add(this.zedGraphControl);
            this.Name = "KNN_Window";
            this.Text = "K-NN";
            this.Load += new System.EventHandler(this.KNN_Window_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.TrackBar kTrackBar;
        private System.Windows.Forms.Label kLabel;
        private System.Windows.Forms.TrackBar pTrackBar;
        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button loadTrainDataBtn;
        private System.Windows.Forms.Button loadTestDataBtn;
        private System.Windows.Forms.Label trainDataLabel;
        private System.Windows.Forms.Label testDataLabel;
        private System.Windows.Forms.Button runKnnForSurfaceBtn;
    }
}

