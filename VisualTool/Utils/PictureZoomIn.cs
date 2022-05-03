using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;

namespace Sunny.UI.Demo.Utils
{
    public partial class PictureZoomIn : UIForm
    {
        public PictureZoomIn(System.Drawing.Image Image_to_Zoom)
        {
            InitializeComponent();
            this.pictureBox1.Image = Image_to_Zoom;
        }
    }
}
