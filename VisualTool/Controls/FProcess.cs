﻿namespace Sunny.UI.Demo
{
    public partial class FProcess : UIPage
    {
        public FProcess()
        {
            InitializeComponent();
        }

        private int value;

        public override void Init()
        {
            value = 0;
            timer1.ReStart();
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            value++;
            uiTrackBar2.Value = uiTrackBar1.Value = value;
            uiProcessBar2.Value = uiProcessBar1.Value = value;
            uiProcessBar3.Value = uiRoundProcess2.Value = uiRoundProcess1.Value = value;
        }

        private void uiTrackBar1_ValueChanged(object sender, System.EventArgs e)
        {

        }

        private void uiTrackBar3_ValueChanged(object sender, System.EventArgs e)
        {
            uiTrackBar4.Value = uiTrackBar3.Value;
        }

        private void uiTrackBar4_ValueChanged(object sender, System.EventArgs e)
        {
            uiTrackBar5.Value = uiTrackBar4.Value;
        }
    }
}
