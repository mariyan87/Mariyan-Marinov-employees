namespace UI
{
    partial class EmployeeView
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpenCsv = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvLongestWork = new System.Windows.Forms.DataGridView();
            this.EmployeeID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectIDs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DaysWorked = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvAllEmployees = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbDateFormat = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLongestWork)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllEmployees)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "fileDialog";
            this.openFileDialog1.Filter = "txt files|*.txt|csv files|*.csv";
            // 
            // btnOpenCsv
            // 
            this.btnOpenCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenCsv.Location = new System.Drawing.Point(644, 17);
            this.btnOpenCsv.Name = "btnOpenCsv";
            this.btnOpenCsv.Size = new System.Drawing.Size(75, 23);
            this.btnOpenCsv.TabIndex = 0;
            this.btnOpenCsv.Text = "Select file";
            this.btnOpenCsv.UseVisualStyleBackColor = true;
            this.btnOpenCsv.Click += new System.EventHandler(this.btnOpenCsv_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(632, 20);
            this.textBox1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnOpenCsv);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(728, 50);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvLongestWork);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 285);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(728, 164);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "pair of employees who worked longest on common projects";
            // 
            // dgvLongestWork
            // 
            this.dgvLongestWork.AllowUserToAddRows = false;
            this.dgvLongestWork.AllowUserToDeleteRows = false;
            this.dgvLongestWork.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLongestWork.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLongestWork.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeID1,
            this.EmployeeID2,
            this.ProjectIDs,
            this.DaysWorked});
            this.dgvLongestWork.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLongestWork.Location = new System.Drawing.Point(3, 16);
            this.dgvLongestWork.Name = "dgvLongestWork";
            this.dgvLongestWork.ReadOnly = true;
            this.dgvLongestWork.Size = new System.Drawing.Size(722, 145);
            this.dgvLongestWork.TabIndex = 0;
            this.dgvLongestWork.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLongestWork_CellFormatting);
            // 
            // EmployeeID1
            // 
            this.EmployeeID1.DataPropertyName = "ID1";
            this.EmployeeID1.HeaderText = "Employee ID #1";
            this.EmployeeID1.Name = "EmployeeID1";
            this.EmployeeID1.ReadOnly = true;
            // 
            // EmployeeID2
            // 
            this.EmployeeID2.DataPropertyName = "ID2";
            this.EmployeeID2.HeaderText = "Employee ID #2";
            this.EmployeeID2.Name = "EmployeeID2";
            this.EmployeeID2.ReadOnly = true;
            // 
            // ProjectIDs
            // 
            this.ProjectIDs.DataPropertyName = "ProjectID";
            this.ProjectIDs.HeaderText = " Project IDs";
            this.ProjectIDs.Name = "ProjectIDs";
            this.ProjectIDs.ReadOnly = true;
            // 
            // DaysWorked
            // 
            this.DaysWorked.DataPropertyName = "Days";
            this.DaysWorked.HeaderText = "Days worked";
            this.DaysWorked.Name = "DaysWorked";
            this.DaysWorked.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvAllEmployees);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 50);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(728, 235);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "All employees";
            // 
            // dgvAllEmployees
            // 
            this.dgvAllEmployees.AllowUserToAddRows = false;
            this.dgvAllEmployees.AllowUserToDeleteRows = false;
            this.dgvAllEmployees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllEmployees.Location = new System.Drawing.Point(3, 16);
            this.dgvAllEmployees.Name = "dgvAllEmployees";
            this.dgvAllEmployees.ReadOnly = true;
            this.dgvAllEmployees.Size = new System.Drawing.Size(594, 216);
            this.dgvAllEmployees.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbDateFormat);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(597, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(128, 216);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Date display format";
            // 
            // cbDateFormat
            // 
            this.cbDateFormat.FormattingEnabled = true;
            this.cbDateFormat.Location = new System.Drawing.Point(6, 19);
            this.cbDateFormat.Name = "cbDateFormat";
            this.cbDateFormat.Size = new System.Drawing.Size(116, 21);
            this.cbDateFormat.TabIndex = 0;
            // 
            // EmployeeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 449);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EmployeeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee View";
            this.Load += new System.EventHandler(this.EmployeeView_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLongestWork)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllEmployees)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpenCsv;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvLongestWork;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectIDs;
        private System.Windows.Forms.DataGridViewTextBoxColumn DaysWorked;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvAllEmployees;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbDateFormat;
    }
}

