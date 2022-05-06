using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VeryVisionControlLibrary
{
    public partial class ToolBar : UserControl
    {
        Bitmap bmpToolBar = Properties.Resources.工具栏;
        public ToolBar()
        {
            InitializeComponent();
            this.Width = bmpToolBar.Width;
            this.Height = bmpToolBar.Height;

            BitmapRegion.CreateControlRegion(this, bmpToolBar);
        }
    }
} 
