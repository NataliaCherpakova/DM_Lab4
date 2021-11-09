namespace Rank
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panelGraph = new System.Windows.Forms.Panel();
			this.buttonGo = new System.Windows.Forms.Button();
			this.textBoxStartUrl = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.labelPagesFound = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.labelLinksFound = new System.Windows.Forms.Label();
			this.labelPagesLeft = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.labelCurrentUrl = new System.Windows.Forms.Label();
			this.labelAveragePageRank = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panelGraph);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.groupBox1.Location = new System.Drawing.Point(583, 132);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.groupBox1.Size = new System.Drawing.Size(555, 430);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Graph";
			// 
			// panelGraph
			// 
			this.panelGraph.Location = new System.Drawing.Point(5, 21);
			this.panelGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.panelGraph.Name = "panelGraph";
			this.panelGraph.Size = new System.Drawing.Size(544, 404);
			this.panelGraph.TabIndex = 0;
			this.panelGraph.Visible = false;
			this.panelGraph.Paint += new System.Windows.Forms.PaintEventHandler(this.panelGraph_Paint);
			// 
			// buttonGo
			// 
			this.buttonGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.buttonGo.Location = new System.Drawing.Point(497, 90);
			this.buttonGo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.buttonGo.Name = "buttonGo";
			this.buttonGo.Size = new System.Drawing.Size(75, 28);
			this.buttonGo.TabIndex = 2;
			this.buttonGo.Text = "Go";
			this.buttonGo.UseVisualStyleBackColor = true;
			this.buttonGo.Click += new System.EventHandler(this.buttonGo_Click);
			// 
			// textBoxStartUrl
			// 
			this.textBoxStartUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.14F);
			this.textBoxStartUrl.Location = new System.Drawing.Point(33, 57);
			this.textBoxStartUrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.textBoxStartUrl.Name = "textBoxStartUrl";
			this.textBoxStartUrl.Size = new System.Drawing.Size(537, 27);
			this.textBoxStartUrl.TabIndex = 2;
			this.textBoxStartUrl.Text = "http://google.com/";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.14F);
			this.label1.Location = new System.Drawing.Point(29, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 20);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter URL";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(636, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Pages:";
			// 
			// labelPagesFound
			// 
			this.labelPagesFound.AutoSize = true;
			this.labelPagesFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPagesFound.Location = new System.Drawing.Point(727, 48);
			this.labelPagesFound.Name = "labelPagesFound";
			this.labelPagesFound.Size = new System.Drawing.Size(16, 17);
			this.labelPagesFound.TabIndex = 4;
			this.labelPagesFound.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label3.Location = new System.Drawing.Point(636, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 17);
			this.label3.TabIndex = 5;
			this.label3.Text = "Links:";
			// 
			// labelLinksFound
			// 
			this.labelLinksFound.AutoSize = true;
			this.labelLinksFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelLinksFound.Location = new System.Drawing.Point(727, 64);
			this.labelLinksFound.Name = "labelLinksFound";
			this.labelLinksFound.Size = new System.Drawing.Size(16, 17);
			this.labelLinksFound.TabIndex = 6;
			this.labelLinksFound.Text = "0";
			// 
			// labelPagesLeft
			// 
			this.labelPagesLeft.AutoSize = true;
			this.labelPagesLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelPagesLeft.Location = new System.Drawing.Point(727, 81);
			this.labelPagesLeft.Name = "labelPagesLeft";
			this.labelPagesLeft.Size = new System.Drawing.Size(16, 17);
			this.labelPagesLeft.TabIndex = 7;
			this.labelPagesLeft.Text = "0";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(636, 81);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 17);
			this.label4.TabIndex = 8;
			this.label4.Text = "Pages left:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.Location = new System.Drawing.Point(21, 128);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(91, 17);
			this.label5.TabIndex = 9;
			this.label5.Text = "Current URL:";
			// 
			// labelCurrentUrl
			// 
			this.labelCurrentUrl.AutoSize = true;
			this.labelCurrentUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelCurrentUrl.Location = new System.Drawing.Point(124, 128);
			this.labelCurrentUrl.Name = "labelCurrentUrl";
			this.labelCurrentUrl.Size = new System.Drawing.Size(13, 17);
			this.labelCurrentUrl.TabIndex = 10;
			this.labelCurrentUrl.Text = "-";
			// 
			// labelAveragePageRank
			// 
			this.labelAveragePageRank.AutoSize = true;
			this.labelAveragePageRank.Location = new System.Drawing.Point(972, 44);
			this.labelAveragePageRank.Name = "labelAveragePageRank";
			this.labelAveragePageRank.Size = new System.Drawing.Size(13, 17);
			this.labelAveragePageRank.TabIndex = 4;
			this.labelAveragePageRank.Text = "-";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(832, 44);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(133, 17);
			this.label7.TabIndex = 3;
			this.label7.Text = "Average page rank:";
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(33, 153);
			this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(537, 408);
			this.richTextBox1.TabIndex = 16;
			this.richTextBox1.Text = "";
			this.richTextBox1.Visible = false;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1152, 598);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonGo);
			this.Controls.Add(this.labelAveragePageRank);
			this.Controls.Add(this.labelPagesFound);
			this.Controls.Add(this.textBoxStartUrl);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.labelCurrentUrl);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.labelPagesLeft);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.labelLinksFound);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelGraph;
        private System.Windows.Forms.Button buttonGo;
        private System.Windows.Forms.TextBox textBoxStartUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPagesFound;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelLinksFound;
        private System.Windows.Forms.Label labelPagesLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelCurrentUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelAveragePageRank;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

