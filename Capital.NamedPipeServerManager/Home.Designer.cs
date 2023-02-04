namespace Capital.NamedPipeServer
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtPipeName = new System.Windows.Forms.TextBox();
            this.dgrdCurrent = new System.Windows.Forms.DataGridView();
            this.colSeq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblPipeName = new System.Windows.Forms.Label();
            this.grpNew = new System.Windows.Forms.GroupBox();
            this.chkRestart = new System.Windows.Forms.CheckBox();
            this.lblCloseAction = new System.Windows.Forms.Label();
            this.picValidation = new System.Windows.Forms.PictureBox();
            this.grpCurrent = new System.Windows.Forms.GroupBox();
            this.lblClose = new System.Windows.Forms.Button();
            this.lblSelectedPipName = new System.Windows.Forms.Label();
            this.lblSelected = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCurrent)).BeginInit();
            this.grpNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picValidation)).BeginInit();
            this.grpCurrent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnStart.Location = new System.Drawing.Point(580, 23);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(138, 31);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtPipeName
            // 
            this.txtPipeName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPipeName.Location = new System.Drawing.Point(188, 24);
            this.txtPipeName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPipeName.Name = "txtPipeName";
            this.txtPipeName.Size = new System.Drawing.Size(347, 31);
            this.txtPipeName.TabIndex = 1;
            this.txtPipeName.TextChanged += new System.EventHandler(this.txtPipeName_TextChanged);
            // 
            // dgrdCurrent
            // 
            this.dgrdCurrent.AllowUserToAddRows = false;
            this.dgrdCurrent.AllowUserToDeleteRows = false;
            this.dgrdCurrent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrdCurrent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSeq,
            this.colName,
            this.colStatus});
            this.dgrdCurrent.Location = new System.Drawing.Point(188, 30);
            this.dgrdCurrent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgrdCurrent.Name = "dgrdCurrent";
            this.dgrdCurrent.ReadOnly = true;
            this.dgrdCurrent.RowHeadersWidth = 51;
            this.dgrdCurrent.RowTemplate.Height = 29;
            this.dgrdCurrent.Size = new System.Drawing.Size(530, 286);
            this.dgrdCurrent.TabIndex = 3;
            // 
            // colSeq
            // 
            this.colSeq.HeaderText = "#";
            this.colSeq.MinimumWidth = 6;
            this.colSeq.Name = "colSeq";
            this.colSeq.ReadOnly = true;
            this.colSeq.Width = 50;
            // 
            // colName
            // 
            this.colName.HeaderText = "Name";
            this.colName.MinimumWidth = 6;
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.HeaderText = "Status";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            this.colStatus.Width = 175;
            // 
            // lblPipeName
            // 
            this.lblPipeName.AutoSize = true;
            this.lblPipeName.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPipeName.Location = new System.Drawing.Point(7, 27);
            this.lblPipeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPipeName.Name = "lblPipeName";
            this.lblPipeName.Size = new System.Drawing.Size(120, 23);
            this.lblPipeName.TabIndex = 4;
            this.lblPipeName.Text = "Pipe name:";
            // 
            // grpNew
            // 
            this.grpNew.Controls.Add(this.chkRestart);
            this.grpNew.Controls.Add(this.lblCloseAction);
            this.grpNew.Controls.Add(this.picValidation);
            this.grpNew.Controls.Add(this.lblPipeName);
            this.grpNew.Controls.Add(this.txtPipeName);
            this.grpNew.Controls.Add(this.btnStart);
            this.grpNew.Location = new System.Drawing.Point(12, 12);
            this.grpNew.Name = "grpNew";
            this.grpNew.Size = new System.Drawing.Size(725, 93);
            this.grpNew.TabIndex = 5;
            this.grpNew.TabStop = false;
            this.grpNew.Text = "New";
            // 
            // chkRestart
            // 
            this.chkRestart.AutoSize = true;
            this.chkRestart.Checked = true;
            this.chkRestart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRestart.Location = new System.Drawing.Point(188, 61);
            this.chkRestart.Name = "chkRestart";
            this.chkRestart.Size = new System.Drawing.Size(109, 27);
            this.chkRestart.TabIndex = 6;
            this.chkRestart.Text = "Restart";
            this.chkRestart.UseVisualStyleBackColor = true;
            // 
            // lblCloseAction
            // 
            this.lblCloseAction.AutoSize = true;
            this.lblCloseAction.Location = new System.Drawing.Point(7, 62);
            this.lblCloseAction.Name = "lblCloseAction";
            this.lblCloseAction.Size = new System.Drawing.Size(109, 23);
            this.lblCloseAction.TabIndex = 5;
            this.lblCloseAction.Text = "On close:";
            // 
            // picValidation
            // 
            this.picValidation.Image = global::Capital.NamedPipeServerManager.Properties.Resources._cross;
            this.picValidation.Location = new System.Drawing.Point(542, 24);
            this.picValidation.Name = "picValidation";
            this.picValidation.Size = new System.Drawing.Size(31, 31);
            this.picValidation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picValidation.TabIndex = 0;
            this.picValidation.TabStop = false;
            // 
            // grpCurrent
            // 
            this.grpCurrent.Controls.Add(this.lblClose);
            this.grpCurrent.Controls.Add(this.lblSelectedPipName);
            this.grpCurrent.Controls.Add(this.lblSelected);
            this.grpCurrent.Controls.Add(this.lblCurrent);
            this.grpCurrent.Controls.Add(this.dgrdCurrent);
            this.grpCurrent.Location = new System.Drawing.Point(12, 111);
            this.grpCurrent.Name = "grpCurrent";
            this.grpCurrent.Size = new System.Drawing.Size(725, 370);
            this.grpCurrent.TabIndex = 6;
            this.grpCurrent.TabStop = false;
            this.grpCurrent.Text = "Current";
            // 
            // lblClose
            // 
            this.lblClose.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblClose.Location = new System.Drawing.Point(589, 326);
            this.lblClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(129, 31);
            this.lblClose.TabIndex = 5;
            this.lblClose.Text = "Disconnect";
            this.lblClose.UseVisualStyleBackColor = true;
            // 
            // lblSelectedPipName
            // 
            this.lblSelectedPipName.Location = new System.Drawing.Point(188, 330);
            this.lblSelectedPipName.Name = "lblSelectedPipName";
            this.lblSelectedPipName.Size = new System.Drawing.Size(385, 23);
            this.lblSelectedPipName.TabIndex = 7;
            // 
            // lblSelected
            // 
            this.lblSelected.AutoSize = true;
            this.lblSelected.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSelected.Location = new System.Drawing.Point(7, 330);
            this.lblSelected.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelected.Name = "lblSelected";
            this.lblSelected.Size = new System.Drawing.Size(109, 23);
            this.lblSelected.TabIndex = 6;
            this.lblSelected.Text = "Selected:";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrent.Location = new System.Drawing.Point(7, 27);
            this.lblCurrent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(164, 23);
            this.lblCurrent.TabIndex = 5;
            this.lblCurrent.Text = "Current pipes:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 495);
            this.Controls.Add(this.grpCurrent);
            this.Controls.Add(this.grpNew);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Home";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Named pip server manager";
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrdCurrent)).EndInit();
            this.grpNew.ResumeLayout(false);
            this.grpNew.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picValidation)).EndInit();
            this.grpCurrent.ResumeLayout(false);
            this.grpCurrent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnStart;
        private TextBox txtPipeName;
        private DataGridView dgrdCurrent;
        private Label lblPipeName;
        private GroupBox grpNew;
        private PictureBox picValidation;
        private GroupBox grpCurrent;
        private Label lblSelectedPipName;
        private Label lblSelected;
        private Label lblCurrent;
        private DataGridViewTextBoxColumn colSeq;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colStatus;
        private Button lblClose;
        private CheckBox chkRestart;
        private Label lblCloseAction;
        private System.Windows.Forms.Timer timer1;
    }
}