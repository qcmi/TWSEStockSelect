namespace StockSelect
{
	partial class MainForm
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
		/// 修改這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
            this.buttonDownload = new System.Windows.Forms.Button();
            this.dateTimePickerDownloadDateFrom = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBoxAnalys = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownLeverage = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSelectStocks = new System.Windows.Forms.Button();
            this.groupBoxDownload = new System.Windows.Forms.GroupBox();
            this.buttonSaveXml = new System.Windows.Forms.Button();
            this.panelProgress = new System.Windows.Forms.Panel();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressBarDownload = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDateFrom = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBoxDay1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDay1 = new System.Windows.Forms.DataGridView();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBoxDay2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDay2 = new System.Windows.Forms.DataGridView();
            this.groupBoxDay3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewDay3 = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownAnalysisBackdays = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateTimePickerAnalysisDate = new System.Windows.Forms.DateTimePicker();
            this.buttonLoadXml = new System.Windows.Forms.Button();
            this.groupBoxXml = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePickerDownloadDateTo = new System.Windows.Forms.DateTimePicker();
            this.groupBoxDownloadDate = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBoxAnalys.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeverage)).BeginInit();
            this.groupBoxDownload.SuspendLayout();
            this.panelProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBoxDay1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDay1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBoxDay2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDay2)).BeginInit();
            this.groupBoxDay3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDay3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnalysisBackdays)).BeginInit();
            this.groupBoxXml.SuspendLayout();
            this.groupBoxDownloadDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(73, 139);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(95, 33);
            this.buttonDownload.TabIndex = 0;
            this.buttonDownload.Text = "下載資料";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // dateTimePickerDownloadDateFrom
            // 
            this.dateTimePickerDownloadDateFrom.Location = new System.Drawing.Point(43, 32);
            this.dateTimePickerDownloadDateFrom.Name = "dateTimePickerDownloadDateFrom";
            this.dateTimePickerDownloadDateFrom.Size = new System.Drawing.Size(161, 27);
            this.dateTimePickerDownloadDateFrom.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxXml);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxAnalys);
            this.splitContainer1.Panel1.Controls.Add(this.groupBoxDownload);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1192, 659);
            this.splitContainer1.SplitterDistance = 295;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBoxAnalys
            // 
            this.groupBoxAnalys.Controls.Add(this.label8);
            this.groupBoxAnalys.Controls.Add(this.dateTimePickerAnalysisDate);
            this.groupBoxAnalys.Controls.Add(this.label6);
            this.groupBoxAnalys.Controls.Add(this.numericUpDownAnalysisBackdays);
            this.groupBoxAnalys.Controls.Add(this.label7);
            this.groupBoxAnalys.Controls.Add(this.label4);
            this.groupBoxAnalys.Controls.Add(this.numericUpDownLeverage);
            this.groupBoxAnalys.Controls.Add(this.label5);
            this.groupBoxAnalys.Controls.Add(this.buttonSelectStocks);
            this.groupBoxAnalys.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxAnalys.Location = new System.Drawing.Point(22, 376);
            this.groupBoxAnalys.Name = "groupBoxAnalys";
            this.groupBoxAnalys.Size = new System.Drawing.Size(249, 230);
            this.groupBoxAnalys.TabIndex = 7;
            this.groupBoxAnalys.TabStop = false;
            this.groupBoxAnalys.Text = "分析";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(216, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "倍";
            // 
            // numericUpDownLeverage
            // 
            this.numericUpDownLeverage.DecimalPlaces = 1;
            this.numericUpDownLeverage.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDownLeverage.Location = new System.Drawing.Point(161, 137);
            this.numericUpDownLeverage.Name = "numericUpDownLeverage";
            this.numericUpDownLeverage.Size = new System.Drawing.Size(49, 27);
            this.numericUpDownLeverage.TabIndex = 7;
            this.numericUpDownLeverage.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 19);
            this.label5.TabIndex = 6;
            this.label5.Text = "2. 交易量大於平均";
            // 
            // buttonSelectStocks
            // 
            this.buttonSelectStocks.Location = new System.Drawing.Point(77, 183);
            this.buttonSelectStocks.Name = "buttonSelectStocks";
            this.buttonSelectStocks.Size = new System.Drawing.Size(91, 31);
            this.buttonSelectStocks.TabIndex = 0;
            this.buttonSelectStocks.Text = "挑選";
            this.buttonSelectStocks.UseVisualStyleBackColor = true;
            this.buttonSelectStocks.Click += new System.EventHandler(this.buttonSelectStocks_Click);
            // 
            // groupBoxDownload
            // 
            this.groupBoxDownload.Controls.Add(this.groupBoxDownloadDate);
            this.groupBoxDownload.Controls.Add(this.panelProgress);
            this.groupBoxDownload.Controls.Add(this.buttonDownload);
            this.groupBoxDownload.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDownload.Location = new System.Drawing.Point(22, 21);
            this.groupBoxDownload.Name = "groupBoxDownload";
            this.groupBoxDownload.Size = new System.Drawing.Size(249, 254);
            this.groupBoxDownload.TabIndex = 6;
            this.groupBoxDownload.TabStop = false;
            this.groupBoxDownload.Text = "下載資料";
            // 
            // buttonSaveXml
            // 
            this.buttonSaveXml.Location = new System.Drawing.Point(10, 26);
            this.buttonSaveXml.Name = "buttonSaveXml";
            this.buttonSaveXml.Size = new System.Drawing.Size(95, 33);
            this.buttonSaveXml.TabIndex = 8;
            this.buttonSaveXml.Text = "儲存資料";
            this.buttonSaveXml.UseVisualStyleBackColor = true;
            this.buttonSaveXml.Click += new System.EventHandler(this.buttonSaveXml_Click);
            // 
            // panelProgress
            // 
            this.panelProgress.Controls.Add(this.labelProgress);
            this.panelProgress.Controls.Add(this.progressBarDownload);
            this.panelProgress.Controls.Add(this.label3);
            this.panelProgress.Location = new System.Drawing.Point(6, 192);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(237, 56);
            this.panelProgress.TabIndex = 7;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.Location = new System.Drawing.Point(111, 30);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(118, 19);
            this.labelProgress.TabIndex = 8;
            this.labelProgress.Text = "已完成[00.00%]";
            // 
            // progressBarDownload
            // 
            this.progressBarDownload.Location = new System.Drawing.Point(4, 30);
            this.progressBarDownload.Name = "progressBarDownload";
            this.progressBarDownload.Size = new System.Drawing.Size(100, 23);
            this.progressBarDownload.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 19);
            this.label3.TabIndex = 7;
            this.label3.Text = "下載進度";
            // 
            // labelDateFrom
            // 
            this.labelDateFrom.AutoSize = true;
            this.labelDateFrom.Location = new System.Drawing.Point(11, 38);
            this.labelDateFrom.Name = "labelDateFrom";
            this.labelDateFrom.Size = new System.Drawing.Size(26, 19);
            this.labelDateFrom.TabIndex = 2;
            this.labelDateFrom.Text = "從";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBoxDay1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(893, 659);
            this.splitContainer2.SplitterDistance = 295;
            this.splitContainer2.TabIndex = 1;
            // 
            // groupBoxDay1
            // 
            this.groupBoxDay1.Controls.Add(this.dataGridViewDay1);
            this.groupBoxDay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDay1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDay1.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxDay1.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDay1.Name = "groupBoxDay1";
            this.groupBoxDay1.Size = new System.Drawing.Size(295, 659);
            this.groupBoxDay1.TabIndex = 1;
            this.groupBoxDay1.TabStop = false;
            this.groupBoxDay1.Text = "第一天挑選";
            // 
            // dataGridViewDay1
            // 
            this.dataGridViewDay1.AllowUserToAddRows = false;
            this.dataGridViewDay1.AllowUserToDeleteRows = false;
            this.dataGridViewDay1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewDay1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDay1.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewDay1.Name = "dataGridViewDay1";
            this.dataGridViewDay1.ReadOnly = true;
            this.dataGridViewDay1.RowTemplate.Height = 24;
            this.dataGridViewDay1.Size = new System.Drawing.Size(289, 633);
            this.dataGridViewDay1.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBoxDay2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupBoxDay3);
            this.splitContainer3.Size = new System.Drawing.Size(594, 659);
            this.splitContainer3.SplitterDistance = 290;
            this.splitContainer3.TabIndex = 0;
            // 
            // groupBoxDay2
            // 
            this.groupBoxDay2.Controls.Add(this.dataGridViewDay2);
            this.groupBoxDay2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDay2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDay2.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxDay2.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDay2.Name = "groupBoxDay2";
            this.groupBoxDay2.Size = new System.Drawing.Size(290, 659);
            this.groupBoxDay2.TabIndex = 2;
            this.groupBoxDay2.TabStop = false;
            this.groupBoxDay2.Text = "第二天挑選";
            // 
            // dataGridViewDay2
            // 
            this.dataGridViewDay2.AllowUserToAddRows = false;
            this.dataGridViewDay2.AllowUserToDeleteRows = false;
            this.dataGridViewDay2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDay2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDay2.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewDay2.Name = "dataGridViewDay2";
            this.dataGridViewDay2.ReadOnly = true;
            this.dataGridViewDay2.RowTemplate.Height = 24;
            this.dataGridViewDay2.Size = new System.Drawing.Size(284, 633);
            this.dataGridViewDay2.TabIndex = 0;
            // 
            // groupBoxDay3
            // 
            this.groupBoxDay3.Controls.Add(this.dataGridViewDay3);
            this.groupBoxDay3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDay3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDay3.ForeColor = System.Drawing.Color.Blue;
            this.groupBoxDay3.Location = new System.Drawing.Point(0, 0);
            this.groupBoxDay3.Name = "groupBoxDay3";
            this.groupBoxDay3.Size = new System.Drawing.Size(300, 659);
            this.groupBoxDay3.TabIndex = 2;
            this.groupBoxDay3.TabStop = false;
            this.groupBoxDay3.Text = "第三天挑選";
            // 
            // dataGridViewDay3
            // 
            this.dataGridViewDay3.AllowUserToAddRows = false;
            this.dataGridViewDay3.AllowUserToDeleteRows = false;
            this.dataGridViewDay3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDay3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDay3.Location = new System.Drawing.Point(3, 23);
            this.dataGridViewDay3.Name = "dataGridViewDay3";
            this.dataGridViewDay3.ReadOnly = true;
            this.dataGridViewDay3.RowTemplate.Height = 24;
            this.dataGridViewDay3.Size = new System.Drawing.Size(294, 633);
            this.dataGridViewDay3.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(132, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "交易日";
            // 
            // numericUpDownAnalysisBackdays
            // 
            this.numericUpDownAnalysisBackdays.Location = new System.Drawing.Point(77, 97);
            this.numericUpDownAnalysisBackdays.Name = "numericUpDownAnalysisBackdays";
            this.numericUpDownAnalysisBackdays.Size = new System.Drawing.Size(49, 27);
            this.numericUpDownAnalysisBackdays.TabIndex = 10;
            this.numericUpDownAnalysisBackdays.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 19);
            this.label7.TabIndex = 9;
            this.label7.Text = "1. 往前";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "查詢日期";
            // 
            // dateTimePickerAnalysisDate
            // 
            this.dateTimePickerAnalysisDate.Location = new System.Drawing.Point(11, 56);
            this.dateTimePickerAnalysisDate.Name = "dateTimePickerAnalysisDate";
            this.dateTimePickerAnalysisDate.Size = new System.Drawing.Size(161, 27);
            this.dateTimePickerAnalysisDate.TabIndex = 12;
            // 
            // buttonLoadXml
            // 
            this.buttonLoadXml.Location = new System.Drawing.Point(136, 26);
            this.buttonLoadXml.Name = "buttonLoadXml";
            this.buttonLoadXml.Size = new System.Drawing.Size(95, 33);
            this.buttonLoadXml.TabIndex = 9;
            this.buttonLoadXml.Text = "讀取資料";
            this.buttonLoadXml.UseVisualStyleBackColor = true;
            this.buttonLoadXml.Click += new System.EventHandler(this.buttonLoadXml_Click);
            // 
            // groupBoxXml
            // 
            this.groupBoxXml.Controls.Add(this.buttonLoadXml);
            this.groupBoxXml.Controls.Add(this.buttonSaveXml);
            this.groupBoxXml.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxXml.Location = new System.Drawing.Point(22, 281);
            this.groupBoxXml.Name = "groupBoxXml";
            this.groupBoxXml.Size = new System.Drawing.Size(249, 80);
            this.groupBoxXml.TabIndex = 8;
            this.groupBoxXml.TabStop = false;
            this.groupBoxXml.Text = "本機資料";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "到";
            // 
            // dateTimePickerDownloadDateTo
            // 
            this.dateTimePickerDownloadDateTo.Location = new System.Drawing.Point(43, 71);
            this.dateTimePickerDownloadDateTo.Name = "dateTimePickerDownloadDateTo";
            this.dateTimePickerDownloadDateTo.Size = new System.Drawing.Size(161, 27);
            this.dateTimePickerDownloadDateTo.TabIndex = 8;
            // 
            // groupBoxDownloadDate
            // 
            this.groupBoxDownloadDate.Controls.Add(this.dateTimePickerDownloadDateTo);
            this.groupBoxDownloadDate.Controls.Add(this.label9);
            this.groupBoxDownloadDate.Controls.Add(this.dateTimePickerDownloadDateFrom);
            this.groupBoxDownloadDate.Controls.Add(this.labelDateFrom);
            this.groupBoxDownloadDate.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxDownloadDate.Location = new System.Drawing.Point(6, 26);
            this.groupBoxDownloadDate.Name = "groupBoxDownloadDate";
            this.groupBoxDownloadDate.Size = new System.Drawing.Size(231, 107);
            this.groupBoxDownloadDate.TabIndex = 10;
            this.groupBoxDownloadDate.TabStop = false;
            this.groupBoxDownloadDate.Text = "資料日期";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 659);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "StockSelect";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBoxAnalys.ResumeLayout(false);
            this.groupBoxAnalys.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLeverage)).EndInit();
            this.groupBoxDownload.ResumeLayout(false);
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBoxDay1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDay1)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBoxDay2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDay2)).EndInit();
            this.groupBoxDay3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDay3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnalysisBackdays)).EndInit();
            this.groupBoxXml.ResumeLayout(false);
            this.groupBoxDownloadDate.ResumeLayout(false);
            this.groupBoxDownloadDate.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonDownload;
		private System.Windows.Forms.DateTimePicker dateTimePickerDownloadDateFrom;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.Label labelDateFrom;
		private System.Windows.Forms.GroupBox groupBoxDownload;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ProgressBar progressBarDownload;
		private System.Windows.Forms.Label labelProgress;
		private System.Windows.Forms.Panel panelProgress;
		private System.Windows.Forms.GroupBox groupBoxAnalys;
		private System.Windows.Forms.Button buttonSelectStocks;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.GroupBox groupBoxDay1;
		private System.Windows.Forms.DataGridView dataGridViewDay1;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.GroupBox groupBoxDay2;
		private System.Windows.Forms.DataGridView dataGridViewDay2;
		private System.Windows.Forms.GroupBox groupBoxDay3;
		private System.Windows.Forms.DataGridView dataGridViewDay3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericUpDownLeverage;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSaveXml;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateTimePickerAnalysisDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownAnalysisBackdays;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonLoadXml;
        private System.Windows.Forms.GroupBox groupBoxXml;
        private System.Windows.Forms.GroupBox groupBoxDownloadDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDownloadDateTo;
        private System.Windows.Forms.Label label9;
    }
}

