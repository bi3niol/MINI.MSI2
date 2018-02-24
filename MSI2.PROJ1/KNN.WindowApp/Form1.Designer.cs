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
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.KLabel = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.PLabel = new System.Windows.Forms.Label();
            this.runBtn = new System.Windows.Forms.Button();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.loadTrainDataBtn = new System.Windows.Forms.Button();
            this.loadTestDataBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(649, 518);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(774, 61);
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.Value = 4;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // KLabel
            // 
            this.KLabel.AutoSize = true;
            this.KLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KLabel.Location = new System.Drawing.Point(679, 61);
            this.KLabel.Name = "KLabel";
            this.KLabel.Size = new System.Drawing.Size(22, 24);
            this.KLabel.TabIndex = 2;
            this.KLabel.Text = "K";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(774, 112);
            this.trackBar2.Maximum = 20;
            this.trackBar2.Minimum = 2;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(104, 45);
            this.trackBar2.TabIndex = 1;
            this.trackBar2.Value = 2;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // PLabel
            // 
            this.PLabel.AutoSize = true;
            this.PLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PLabel.Location = new System.Drawing.Point(679, 112);
            this.PLabel.Name = "PLabel";
            this.PLabel.Size = new System.Drawing.Size(22, 24);
            this.PLabel.TabIndex = 2;
            this.PLabel.Text = "P";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(680, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(683, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 542);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadTestDataBtn);
            this.Controls.Add(this.loadTrainDataBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.PLabel);
            this.Controls.Add(this.KLabel);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.zedGraphControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label KLabel;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label PLabel;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button loadTrainDataBtn;
        private System.Windows.Forms.Button loadTestDataBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

