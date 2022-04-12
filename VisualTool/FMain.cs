using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sunny.UI.Demo
{
    public partial class FMain : UIHeaderAsideMainFooterFrame //UIHeaderAsideMainFrame
    {
        

        public static string DataSetPath = "Null";
        public FMain()
        {
            InitializeComponent();
            
            int pageIndex = 1000;
            Header.SetNodePageIndex(Header.Nodes[0], pageIndex);
            Header.SetNodeSymbol(Header.Nodes[0], 61451);
            TreeNode parent = Aside.CreateNode("Dataset", 61451, 24, pageIndex);
            //TreeNode parent = Aside.CreateNode("Dataset", AddPage(new FAvatar(), ++pageIndex));
            Aside.CreateChildNode(parent, AddPage(new Dataview(), ++pageIndex));
            //通过设置PageIndex关联，节点文字、图标由相应的Page的Text、Symbol提供
            //
            //Aside.CreateChildNode(parent, AddPage(new FAvatar(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FButton(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FCheckBox(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FCombobox(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FContextMenuStrip(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FDataGridView(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FFlowLayoutPanel(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FHeaderButton(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FLabel(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FLine(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FListBox(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FNavigation(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FPanel(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FProcess(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FRadioButton(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FScrollBar(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FSplitContainer(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FTabControl(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FTextBox(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FTransfer(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FTreeView(), ++pageIndex));
            //Aside.CreateChildNode(parent, AddPage(new FOther(), ++pageIndex));
            //示例设置某个节点的小红点提示
            //Aside.ShowTips = true;
            //Aside.SetNodeTipsText(Aside.Nodes[0], "6", Color.Red, Color.White);
            //Aside.SetNodeTipsText(parent.Nodes[1], " ", Color.Lime, Color.White);
            
            pageIndex = 2000;
            Header.SetNodePageIndex(Header.Nodes[1], pageIndex);
            Header.SetNodeSymbol(Header.Nodes[1], 61818);
            parent = Aside.CreateNode("Data Flow", 61818, 24, pageIndex);
            //通过设置GUID关联，节点字体图标和大小由UIPage设置
            //Aside.CreateChildNode(parent, AddPage(new FDialogs(), Guid.NewGuid()));
            //Aside.CreateChildNode(parent, AddPage(new FEditor(), Guid.NewGuid()));
            //Aside.CreateChildNode(parent, AddPage(new FFrames(), Guid.NewGuid()));

            pageIndex = 3000;
            Header.SetNodePageIndex(Header.Nodes[2], pageIndex);
            Header.SetNodeSymbol(Header.Nodes[2], 61950);
            parent = Aside.CreateNode("Dimension Reduction", 61950, 24, pageIndex);
            //直接关联（默认自动生成GUID）
            //Aside.CreateChildNode(parent, AddPage(new FBarChart()));
            //Aside.CreateChildNode(parent, AddPage(new FDoughnutChart()));
            //Aside.CreateChildNode(parent, AddPage(new FLineChart()));
            //Aside.CreateChildNode(parent, AddPage(new FPieChart()));

            pageIndex = 4000;
            Header.SetNodePageIndex(Header.Nodes[3], pageIndex);
            Header.SetNodeSymbol(Header.Nodes[3], 362614);
            parent = Aside.CreateNode("Visualization", 362614, 24, pageIndex);
            //直接关联（默认自动生成GUID）

            //Aside.CreateChildNode(parent, AddPage(CreateInstance<UIPage>("Sunny.UI.Demo.FPipe")));
            //Aside.CreateChildNode(parent, AddPage(CreateInstance<UIPage>("Sunny.UI.Demo.FMeter")));
            //Aside.CreateChildNode(parent, AddPage(CreateInstance<UIPage>("Sunny.UI.Demo.FLed")));
            //Aside.CreateChildNode(parent, AddPage(CreateInstance<UIPage>("Sunny.UI.Demo.FLight")));

            Header.SetNodeSymbol(Header.Nodes[4], 61502);
            var styles = UIStyles.PopularStyles();
            foreach (UIStyle style in styles)
            {
                Header.CreateChildNode(Header.Nodes[4], style.DisplayText(), style.Value());
            }

            Header.CreateChildNode(Header.Nodes[4], "Colorful", UIStyle.Colorful.Value());
            //直接增加一个页面，不在左侧列表显示
            AddPage(new FColorful());
            AddPage(new FCommon());

            //选中第一个节点
            Aside.SelectPage(1002);

            Text = Version;
            RegisterHotKey(UI.ModifierKeys.Shift, Keys.F8);

            //根据页面类型获取页面
            FButton page = GetPage<FButton>();
            if (page != null)
                page.Text.WriteConsole();

            //根据页面索引获取页面
            UIPage page1 = GetPage(1002);
            if (page1 != null)
                page1.Text.WriteConsole();



            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Enabled = true;
            timer.Interval = 200;//4秒执行间隔时间,单位为毫秒   
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Footnet_Present);          // timer.Stop();停止
        }

        /// <summary>
        /// 创建对象实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullName">命名空间.类型名</param>
        /// <returns></returns>
        public static T CreateInstance<T>(string fullName)
        {
            Type o = Type.GetType(fullName);
            dynamic obj = Activator.CreateInstance(o, true);
            return (T)obj;//类型转换并返回
        }

        private void Header_MenuItemClick(string text, int menuIndex, int pageIndex)
        {
            switch (menuIndex)
            {
                case 4:
                    UIStyle style = (UIStyle)pageIndex;
                    if (style != UIStyle.Colorful)
                        StyleManager.Style = style;
                    else
                        SelectPage(pageIndex);

                    break;
                default:
                    Aside.SelectPage(pageIndex);
                    break;
            }
        }

        private void FMain_Selecting(object sender, TabControlCancelEventArgs e, UIPage page)
        {
            if (page != null)
                Console.WriteLine(page.Text);
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UIMessageBox.Show(Version, "关于", Style, UIMessageBoxButtons.OK, false);
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://gitee.com/yhuse/SunnyUI");
        }

        private void FMain_HotKeyEventHandler(object sender, HotKeyEventArgs e)
        {
            if (e.hotKey.ModifierKey == UI.ModifierKeys.Shift && e.hotKey.Key == Keys.F8)
            {
                ShowInfoTip("您按下了全局系统热键 Shift+F8");
            }
        }

        private void Aside_MenuItemClick(TreeNode node, NavMenuItem item, int pageIndex)
        {
            Footer.Text = "PageIndex: " + pageIndex;
        }


        public static string Footnote_to_Show = @"None";
        public void Footnet_Present(object sender, System.Timers.ElapsedEventArgs e)
        {
            Footer.Text = Footnote_to_Show;
        }

        static public Bitmap GetPicfromPython(string command)
        {
            Bitmap plot = new Bitmap(@"F:\\SJTU\\Projects\\Graduation Project\\Visualization-Project-for-Greyout\\VisualTool\\Resources\\7.png");
            string log = "";//错误信息
            string Url = "http://127.0.0.1:8000/plot/";//功能网址
            //string command = "pairplot";
            string jsonParams = "#" + command + "#";
            string result = RequestsPost(Url, jsonParams);
            if (result == null)
            {
                log = "Failed to Connect Flask Server!";
            }
            else
            {
                if (result.Contains("default"))
                {
                    log = "There is an error running the algorithm." + "\r\n" + result;
                }
                else
                {
                    plot = new Bitmap(result);
               
                    log = "Test Successed!";
                    return plot;
                }
            }
            MessageBox.Show(log);
            return plot;
        }

        /// <summary>
        /// 通过网络地址和端口访问数据
        /// </summary>
        /// <param name="Url">网络地址</param>
        /// <param name="jsonParas">json参数</param>
        /// <returns></returns>
        static public string RequestsPost(string Url, string jsonParas)
        {
            string postContent = "";
            string strURL = Url;
            //创建一个HTTP请求  
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(strURL);
            //Post请求方式  
            request.Method = "POST";
            //内容类型
            request.ContentType = "application/json";
            //设置参数，并进行URL编码 

            string paraUrlCoded = jsonParas;//System.Web.HttpUtility.UrlEncode(jsonParas);   

            byte[] payload;
            //将Json字符串转化为字节  
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            //设置请求的ContentLength 
            request.ContentLength = payload.Length;

            //发送请求，获得请求流 
            Stream writer;
            try
            {
                writer = request.GetRequestStream();//获取用于写入请求数据的Stream对象
            }
            catch (Exception)
            {
                writer = null;
                MessageBox.Show("连接服务器失败!");
                return null;
            }
            //将请求参数写入流
            writer.Write(payload, 0, payload.Length);
            writer.Close();//关闭请求流
            HttpWebResponse response;
            try
            {
                //获得响应流
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = ex.Response as HttpWebResponse;
                postContent = "default: The response is null." + "\r\n" + "Exception: " + ex.Message;
            }
            if (response != null)
            {
                try
                {
                    Stream s = response.GetResponseStream();
                    StreamReader sRead = new StreamReader(s);
                    postContent = sRead.ReadToEnd();
                    sRead.Close();
                }
                catch (Exception e)
                {
                    postContent = "default: The data stream is not readable." + "\r\n" + e.Message;
                }
            }
            return postContent;//返回Json数据
        }

        static public void PicZoomIn(Object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox picturebox = sender as PictureBox;
                Utils.PictureZoomIn PicZoom = new Utils.PictureZoomIn(picturebox.Image);
                PicZoom.ShowDialog();
                //MessageBox.Show("连接服务器失败!");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FMain_Load(object sender, EventArgs e)
        {

        }
    }
}