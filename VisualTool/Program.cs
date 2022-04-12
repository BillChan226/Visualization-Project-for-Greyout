﻿using System;
using System.Windows.Forms;

namespace Sunny.UI.Demo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FMain Main_Form = new FMain();
            Application.Run(Main_Form);
            
        }
    }
}
