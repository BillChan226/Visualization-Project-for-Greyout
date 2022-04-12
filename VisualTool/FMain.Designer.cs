namespace Sunny.UI.Demo
{
    partial class FMain
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
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Dataset");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Data Flow");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Dim-Reduction");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Visualization");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Theme");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            this.uiAvatar = new Sunny.UI.UIAvatar();
            this.StyleManager = new Sunny.UI.UIStyleManager(this.components);
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.uiLogo1 = new Sunny.UI.UILogo();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.Header.SuspendLayout();
            this.uiContextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Footer
            // 
            this.Footer.Location = new System.Drawing.Point(2, 662);
            this.Footer.Size = new System.Drawing.Size(1020, 56);
            // 
            // Aside
            // 
            this.Aside.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aside.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Aside.ItemHeight = 36;
            this.Aside.Location = new System.Drawing.Point(2, 145);
            this.Aside.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            this.Aside.ScrollBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Aside.ScrollBarHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Aside.ScrollBarPressColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Aside.ShowOneNode = true;
            this.Aside.ShowSecondBackColor = true;
            this.Aside.ShowTips = true;
            this.Aside.Size = new System.Drawing.Size(250, 517);
            this.Aside.MenuItemClick += new Sunny.UI.UINavMenu.OnMenuItemClick(this.Aside_MenuItemClick);
            // 
            // Header
            // 
            this.Header.Controls.Add(this.uiAvatar);
            this.Header.DropMenuFont = new System.Drawing.Font("Times New Roman", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.Font = new System.Drawing.Font("微软雅黑", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Header.Location = new System.Drawing.Point(2, 35);
            treeNode16.ImageIndex = 1;
            treeNode16.Name = "节点0";
            treeNode16.Text = "Dataset";
            treeNode17.Name = "节点1";
            treeNode17.Text = "Data Flow";
            treeNode18.Name = "节点2";
            treeNode18.Text = "Dim-Reduction";
            treeNode19.Name = "节点0";
            treeNode19.Text = "Visualization";
            treeNode20.Name = "节点2";
            treeNode20.Text = "Theme";
            this.Header.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20});
            this.Header.NodeSize = new System.Drawing.Size(110, 45);
            this.Header.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Header.SelectedIndex = 0;
            this.Header.Size = new System.Drawing.Size(1020, 110);
            this.Header.MenuItemClick += new Sunny.UI.UINavBar.OnMenuItemClick(this.Header_MenuItemClick);
            // 
            // uiAvatar
            // 
            this.uiAvatar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiAvatar.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiAvatar.Location = new System.Drawing.Point(939, 25);
            this.uiAvatar.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiAvatar.Name = "uiAvatar";
            this.uiAvatar.Size = new System.Drawing.Size(66, 70);
            this.uiAvatar.TabIndex = 4;
            this.uiAvatar.Text = "uiAvatar1";
            // 
            // StyleManager
            // 
            this.StyleManager.DPIScale = true;
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiContextMenuStrip1.IsScaled = true;
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem,
            this.关于ToolStripMenuItem1});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(113, 56);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(112, 26);
            this.关于ToolStripMenuItem.Text = "主页";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(112, 26);
            this.关于ToolStripMenuItem1.Text = "关于";
            this.关于ToolStripMenuItem1.Click += new System.EventHandler(this.关于ToolStripMenuItem1_Click);
            // 
            // uiLogo1
            // 
            this.uiLogo1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.uiLogo1.Location = new System.Drawing.Point(68, 53);
            this.uiLogo1.MaximumSize = new System.Drawing.Size(300, 80);
            this.uiLogo1.MinimumSize = new System.Drawing.Size(300, 80);
            this.uiLogo1.Name = "uiLogo1";
            this.uiLogo1.Size = new System.Drawing.Size(300, 80);
            this.uiLogo1.TabIndex = 3;
            this.uiLogo1.Text = "uiLogo1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(257, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // uiLabel1
            // 
            this.uiLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.White;
            this.uiLabel1.Location = new System.Drawing.Point(10, 5);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(180, 25);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.StyleCustomMode = true;
            this.uiLabel1.TabIndex = 7;
            this.uiLabel1.Text = "Greyout Visualization";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FMain
            // 
            this.AllowAddControlOnTitle = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1024, 720);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.uiLogo1);
            this.ExtendBox = true;
            this.ExtendMenu = this.uiContextMenuStrip1;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1024, 720);
            this.Name = "FMain";
            this.Padding = new System.Windows.Forms.Padding(2, 35, 2, 2);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowDragStretch = true;
            this.ShowRadius = false;
            this.ShowShadow = true;
            this.Text = "Greyout Visualization";
            this.Selecting += new Sunny.UI.UIMainFrame.OnSelecting(this.FMain_Selecting);
            this.HotKeyEventHandler += new Sunny.UI.HotKeyEventHandler(this.FMain_HotKeyEventHandler);
            this.Load += new System.EventHandler(this.FMain_Load);
            this.Controls.SetChildIndex(this.uiLogo1, 0);
            this.Controls.SetChildIndex(this.Footer, 0);
            this.Controls.SetChildIndex(this.Header, 0);
            this.Controls.SetChildIndex(this.Aside, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.uiLabel1, 0);
            this.Header.ResumeLayout(false);
            this.uiContextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private UIAvatar uiAvatar;
        private UIStyleManager StyleManager;
        private UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
        private UILogo uiLogo1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private UILabel uiLabel1;
    }
}