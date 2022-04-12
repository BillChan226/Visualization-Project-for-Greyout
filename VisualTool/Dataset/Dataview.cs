using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Sunny.UI.Demo
{
    public partial class Dataview : UIPage
    {
        List<Data> datas = new List<Data>();
        public Dataview()
        {
            InitializeComponent();

            //SunnyUI封装的加列函数，也可以和原生的一样，从Columns里面添加列
            uiDataGridView1.AddColumn("Column1", "Column1");
            uiDataGridView1.AddColumn("Column2", "Column2");
            uiDataGridView1.AddColumn("Column3", "Column3");
            uiDataGridView1.AddColumn("Column4", "Column4");

            //SunnyUI常用的初始化配置，看个人喜好用或者不用。
            uiDataGridView1.Init();

            //for (int i = 0; i < 3610; i++)
            //{
            //    Data data = new Data();
            //    data.Column1 = "Data" + i.ToString("D2");
            //    data.Column2 = i.Mod(2) == 0 ? "A" : "B";
            //    data.Column3 = "编辑";
            //    data.Column4 = i.Mod(4) == 0;
            //    datas.Add(data);
            //}

            //设置分页控件总数
            //uiPagination1.TotalCount = datas.Count;

            //设置分页控件每页数量
            //uiPagination1.PageSize = 50;

            //uiDataGridView1.SelectIndexChange += uiDataGridView1_SelectIndexChange;

            //uiDataGridView1.ShowGridLine = true;
            //设置统计绑定的表格
            //uiDataGridViewFooter1.DataGridView = uiDataGridView1;

        }

        public override void Init()
        {
            base.Init();
            uiPagination1.ActivePage = 1;
        }

        public class Data
        {
            public string Column1 { get; set; }

            public string Column2 { get; set; }

            public string Column3 { get; set; }

            public string Column4 { get; set; }

            public string Column5 { get; set; }

            public string Column6 { get; set; }

            public override string ToString()
            {
                return Column1;
            }
        }

        /// <summary>
        /// 分页控件页面切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pagingSource"></param>
        /// <param name="pageIndex"></param>
        /// <param name="count"></param>
        private void uiPagination1_PageChanged(object sender, object pagingSource, int pageIndex, int count)
        {
            //未连接数据库，通过模拟数据来实现
            //一般通过ORM的分页去取数据来填充
            //pageIndex：第几页，和界面对应，从1开始，取数据可能要用pageIndex - 1
            //count：单页数据量，也就是PageSize值
            List<Data> data = new List<Data>();
            for (int i = (pageIndex - 1) * count; i < (pageIndex - 1) * count + count; i++)
            {
                if (i >= datas.Count) continue;
                data.Add(datas[i]);
            }

            uiDataGridView1.DataSource = data;
            //uiDataGridViewFooter1.Clear();
            //uiDataGridViewFooter1["Column1"] = "合计：";
            //uiDataGridViewFooter1["Column2"] = "Column2_" + pageIndex;
            //uiDataGridViewFooter1["Column3"] = "Column3_" + pageIndex;
            //uiDataGridViewFooter1["Column4"] = "Column4_" + pageIndex;
        }

        private void uiDataGridView1_SelectIndexChange(object sender, int index)
        {
            index.WriteConsole("SelectedIndex");
        }


        private void BarChart_Click(object sender, EventArgs e)
        {

        }

        private void Dataview_Initialize(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Data_Importer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;//该值确定是否可以选择多个文件
            dialog.Title = "Import Target Dataset";
            dialog.Filter = "All files(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                string file_path = System.IO.Path.GetFullPath(dialog.FileName);//记录选中的文件的路径
                FMain.Footnote_to_Show = file_path;
                FMain.DataSetPath = file_path;
                string fileSuffix = System.IO.Path.GetExtension(file_path);
                if (fileSuffix == ".csv")
                {
                    PreviewData(file_path);
                }
            }
            

        }

        private void Data_Analyzer_Click(object sender, EventArgs e)
        {
            if(FMain.DataSetPath == "Null")
            {
                ShowErrorTip("No Dataset to Analyze!");
                return;
            }
            ShowWaitForm("Analyzing...");
            for (int i = 0; i < 2; i++)
            {
                
                PictureBox Data_Statistics = new PictureBox();
                //Button button = new Button();
                Data_Statistics.Size = new System.Drawing.Size(289, 187);//Button大小
                Data_Statistics.Location = new System.Drawing.Point(98 + 350 * (i % 2), 620 + 300 * (i / 2));//位置
                Data_Statistics.Name = "PicBoxSta_" + i;
                Data_Statistics.Text = "PicBoxSta_" + i;
                Data_Statistics.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                Data_Statistics.Click += new System.EventHandler(FMain.PicZoomIn);//注册点击事件
                if (i == 0)
                {
                    Data_Statistics.Image = FMain.GetPicfromPython(@"histoPlot");
                    SetWaitFormDescription("Decomposing Dimension... " + "40%");
                }
                
                if (i == 1)
                {
                    Data_Statistics.Image = FMain.GetPicfromPython(@"pairPlot");
                    SetWaitFormDescription("Plotting... " + "80%");
                }
                
                

                //Data_Statistics.Click += new EventHandler(btnEvent);//注册点击事件
                //this.panel2.Controls.Add(button);
                this.Controls.Add(Data_Statistics);
            }
            HideWaitForm();
        }

        


        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public class CsvRow : List<string>
        {
            public string LineText { get; set; }
        }

        /// <summary>
        /// Class to write data to a CSV file
        /// </summary>
        public class CsvFileWriter : StreamWriter
        {
            public CsvFileWriter(Stream stream)
                : base(stream)
            {
            }

            public CsvFileWriter(string filename)
                : base(filename)
            {
            }

            /// <summary>
            /// Writes a single row to a CSV file.
            /// </summary>
            /// <param name="row">The row to be written</param>
            public void WriteRow(CsvRow row)
            {
                StringBuilder builder = new StringBuilder();
                bool firstColumn = true;
                foreach (string value in row)
                {
                    // Add separator if this isn't the first value
                    if (!firstColumn)
                        builder.Append(',');
                    // Implement special handling for values that contain comma or quote
                    // Enclose in quotes and double up any double quotes
                    if (value.IndexOfAny(new char[] { '"', ',' }) != -1)
                        builder.AppendFormat("\"{0}\"", value.Replace("\"", "\"\""));
                    else
                        builder.Append(value);
                    firstColumn = false;
                }
                row.LineText = builder.ToString();
                WriteLine(row.LineText);
            }
        }

        /// <summary>
        /// Class to read data from a CSV file
        /// </summary>
        public class CsvFileReader : StreamReader
        {
            public CsvFileReader(Stream stream)
                : base(stream)
            {
            }

            public CsvFileReader(string filename)
                : base(filename)
            {
            }

            /// <summary>
            /// Reads a row of data from a CSV file
            /// </summary>
            /// <param name="row"></param>
            /// <returns></returns>
            public bool ReadRow(CsvRow row)
            {
                row.LineText = ReadLine();
                if (String.IsNullOrEmpty(row.LineText))
                    return false;

                int pos = 0;
                int rows = 0;

                while (pos < row.LineText.Length)
                {
                    string value;

                    // Special handling for quoted field
                    if (row.LineText[pos] == '"')
                    {
                        // Skip initial quote
                        pos++;

                        // Parse quoted value
                        int start = pos;
                        while (pos < row.LineText.Length)
                        {
                            // Test for quote character
                            if (row.LineText[pos] == '"')
                            {
                                // Found one
                                pos++;

                                // If two quotes together, keep one
                                // Otherwise, indicates end of value
                                if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                                {
                                    pos--;
                                    break;
                                }
                            }
                            pos++;
                        }
                        value = row.LineText.Substring(start, pos - start);
                        value = value.Replace("\"\"", "\"");
                    }
                    else
                    {
                        // Parse unquoted value
                        int start = pos;
                        while (pos < row.LineText.Length && row.LineText[pos] != ',')
                            pos++;
                        value = row.LineText.Substring(start, pos - start);
                    }

                    // Add field to list
                    if (rows < row.Count)
                        row[rows] = value;
                    else
                        row.Add(value);
                    rows++;

                    // Eat up to and including next comma
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    if (pos < row.LineText.Length)
                        pos++;
                }
                // Delete any unused items
                while (row.Count > rows)
                    row.RemoveAt(rows);

                // Return true if any columns read
                return (row.Count > 0);
            }
        }
        void WriteTest(string filepath)
        {
            // Write sample data to CSV file
            using (CsvFileWriter writer = new CsvFileWriter(filepath))
            {
                for (int i = 0; i < 100; i++)
                {
                    CsvRow row = new CsvRow();
                    for (int j = 0; j < 5; j++)
                        row.Add(String.Format("Column{0}", j));
                    writer.WriteRow(row);
                }
            }
        }
        void PreviewData(string filepath)
        {
            // Read sample data from CSV file
            using (CsvFileReader reader = new CsvFileReader(filepath))
            {
                CsvRow row = new CsvRow();
                //while (reader.ReadRow(row))
                //{
                //    DataRow dr = dt.NewRow();
                //    for (int i = 0; i < row.Capacity; i++)
                //    {
                //        dr[i] = row[i];
                //        Console.Write(row[i]);
                //        Console.Write(" ");
                //    }
                //    Console.WriteLine();
                //   dt.Rows.Add(dr);
                //}
                while (reader.ReadRow(row))
                    {
                        Data data = new Data();                   
                        data.Column1 = row[0].ToString();
                        data.Column2 = row[1].ToString();
                        data.Column3 = row[2].ToString();
                        data.Column4 = row[3].ToString();
                        datas.Add(data);
                    }
                FMain.Footnote_to_Show = filepath;

                //设置分页控件总数
                uiPagination1.TotalCount = datas.Count;

                //设置分页控件每页数量
                uiPagination1.PageSize = 50;

                uiDataGridView1.SelectIndexChange += uiDataGridView1_SelectIndexChange;

                uiDataGridView1.ShowGridLine = true;
            }
            //dataGridView1.DataSource = dt;


            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("连接服务器失败!");
        }
    }
}
