
namespace Sunny.UI.Demo.Stage
{
    partial class Stage1
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
            this.uiBattery1 = new Sunny.UI.UIBattery();
            this.SuspendLayout();
            // 
            // uiBattery1
            // 
            this.uiBattery1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiBattery1.Location = new System.Drawing.Point(78, 103);
            this.uiBattery1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiBattery1.Name = "uiBattery1";
            this.uiBattery1.Size = new System.Drawing.Size(48, 24);
            this.uiBattery1.TabIndex = 0;
            this.uiBattery1.Text = "uiBattery1";
            // 
            // Stage1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.uiBattery1);
            this.Name = "Stage1";
            this.Text = "Stage 1";
            this.ResumeLayout(false);

        }

        #endregion

        private UIBattery uiBattery1;
    }
}