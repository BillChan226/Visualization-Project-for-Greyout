
namespace Sunny.UI.Demo
{
    partial class Dataview
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Data_Info = new Sunny.UI.UITitlePanel();
            this.Data_Importer = new Sunny.UI.UISymbolButton();
            this.Data_Preview = new Sunny.UI.UISymbolButton();
            this.Data_Infomer = new Sunny.UI.UISymbolButton();
            this.Data_Analyzer = new Sunny.UI.UISymbolButton();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.uiPagination1 = new Sunny.UI.UIPagination();
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Data_Info
            // 
            this.Data_Info.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Data_Info.Location = new System.Drawing.Point(273, 23);
            this.Data_Info.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Data_Info.MinimumSize = new System.Drawing.Size(1, 1);
            this.Data_Info.Name = "Data_Info";
            this.Data_Info.Padding = new System.Windows.Forms.Padding(0, 35, 0, 0);
            this.Data_Info.ShowText = false;
            this.Data_Info.Size = new System.Drawing.Size(431, 186);
            this.Data_Info.TabIndex = 41;
            this.Data_Info.Text = "Dataset Information";
            this.Data_Info.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Data_Importer
            // 
            this.Data_Importer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Data_Importer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Data_Importer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Data_Importer.Location = new System.Drawing.Point(98, 23);
            this.Data_Importer.MinimumSize = new System.Drawing.Size(1, 1);
            this.Data_Importer.Name = "Data_Importer";
            this.Data_Importer.Size = new System.Drawing.Size(138, 42);
            this.Data_Importer.Symbol = 61564;
            this.Data_Importer.TabIndex = 42;
            this.Data_Importer.Text = "Import Data";
            this.Data_Importer.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Data_Importer.Click += new System.EventHandler(this.Data_Importer_Click);
            // 
            // Data_Preview
            // 
            this.Data_Preview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Data_Preview.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Data_Preview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Data_Preview.Location = new System.Drawing.Point(98, 71);
            this.Data_Preview.MinimumSize = new System.Drawing.Size(1, 1);
            this.Data_Preview.Name = "Data_Preview";
            this.Data_Preview.Size = new System.Drawing.Size(138, 42);
            this.Data_Preview.Symbol = 61568;
            this.Data_Preview.TabIndex = 43;
            this.Data_Preview.Text = "Preview  ";
            this.Data_Preview.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // Data_Infomer
            // 
            this.Data_Infomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Data_Infomer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Data_Infomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Data_Infomer.Location = new System.Drawing.Point(98, 119);
            this.Data_Infomer.MinimumSize = new System.Drawing.Size(1, 1);
            this.Data_Infomer.Name = "Data_Infomer";
            this.Data_Infomer.Size = new System.Drawing.Size(138, 42);
            this.Data_Infomer.Symbol = 61530;
            this.Data_Infomer.TabIndex = 44;
            this.Data_Infomer.Text = "Show Info.";
            this.Data_Infomer.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            // 
            // Data_Analyzer
            // 
            this.Data_Analyzer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Data_Analyzer.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Data_Analyzer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Data_Analyzer.Location = new System.Drawing.Point(98, 167);
            this.Data_Analyzer.MinimumSize = new System.Drawing.Size(1, 1);
            this.Data_Analyzer.Name = "Data_Analyzer";
            this.Data_Analyzer.Size = new System.Drawing.Size(138, 42);
            this.Data_Analyzer.Symbol = 61953;
            this.Data_Analyzer.TabIndex = 45;
            this.Data_Analyzer.Text = "Analyze";
            this.Data_Analyzer.TipsFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Data_Analyzer.Click += new System.EventHandler(this.Data_Analyzer_Click);
            // 
            // uiDataGridView1
            // 
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle26;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle28;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.Location = new System.Drawing.Point(98, 235);
            this.uiDataGridView1.Name = "uiDataGridView1";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle29.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle29;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle30;
            this.uiDataGridView1.RowTemplate.Height = 23;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.ShowGridLine = true;
            this.uiDataGridView1.Size = new System.Drawing.Size(606, 333);
            this.uiDataGridView1.TabIndex = 46;
            this.uiDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.uiDataGridView1_CellContentClick);
            // 
            // uiPagination1
            // 
            this.uiPagination1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPagination1.Location = new System.Drawing.Point(110, 576);
            this.uiPagination1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPagination1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPagination1.Name = "uiPagination1";
            this.uiPagination1.RectSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.None;
            this.uiPagination1.ShowText = false;
            this.uiPagination1.Size = new System.Drawing.Size(594, 42);
            this.uiPagination1.TabIndex = 47;
            this.uiPagination1.Text = "uiPagination1";
            this.uiPagination1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiPagination1.PageChanged += new Sunny.UI.UIPagination.OnPageChangeEventHandler(this.uiPagination1_PageChanged);
            // 
            // Dataview
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 606);
            this.Controls.Add(this.uiPagination1);
            this.Controls.Add(this.uiDataGridView1);
            this.Controls.Add(this.Data_Analyzer);
            this.Controls.Add(this.Data_Infomer);
            this.Controls.Add(this.Data_Preview);
            this.Controls.Add(this.Data_Importer);
            this.Controls.Add(this.Data_Info);
            this.Name = "Dataview";
            this.PageIndex = 1001;
            this.Symbol = 61568;
            this.Text = "View Data";
            this.Initialize += new System.EventHandler(this.Dataview_Initialize);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private UITitlePanel Data_Info;
        private UISymbolButton Data_Importer;
        private UISymbolButton Data_Preview;
        private UISymbolButton Data_Infomer;
        private UISymbolButton Data_Analyzer;
        private UIDataGridView uiDataGridView1;
        private UIPagination uiPagination1;
    }
}