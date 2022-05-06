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
    public partial class TitleBox : UserControl
    {
        string _StationName = "未知站点";
        public string StationName
        {
            get
            {
                return _StationName;
            }
            set
            {
                _StationName = value;
                SetStationName();
            }
        }

        Bitmap bmpBackground = Properties.Resources.站点提示框;
        Panel pnlControl = new Panel();

        Label labStationName;
        public TitleBox()
        {
            InitializeComponent();
            
            labStationName = new Label();

            //_StationName = "中山大学空气自动监测系统";
            labStationName.BackColor = Color.Transparent;//设置背景顏色为透明
            labStationName.Left = 80;
            labStationName.Cursor = Cursors.Hand;

            SetStationName();
            pnlControl.Controls.Add(labStationName);
            pnlControl.Width = bmpBackground.Width;
            pnlControl.Height = bmpBackground.Height;
            pnlControl.Top = 0;
            pnlControl.Left = 0;

            //事件传递
            pnlControl.MouseHover += new EventHandler(pnlControl_MouseHover);
            pnlControl.MouseLeave += new EventHandler(pnlControl_MouseLeave);
            pnlControl.Paint += new PaintEventHandler(pnlControl_Paint);

            pnlControl.MouseUp += new MouseEventHandler(pnlControl_MouseUp);
            pnlControl.MouseDown += new MouseEventHandler(pnlControl_MouseDown);
            pnlControl.MouseMove += new MouseEventHandler(pnlControl_MouseMove);

            this.Width = pnlControl.Width;
            this.Height = pnlControl.Height;
            BitmapRegion.CreateControlRegion(pnlControl, bmpBackground);

            this.Controls.Add(pnlControl);

        }

        private void SetStationName()
        {
            System.Drawing.Graphics g = this.CreateGraphics();
            labStationName.Text = _StationName;
            int iLength = _StationName.Length;
            Font f;
            if (iLength <= 4)
            {
                f = new Font("楷体", 48);
            }
            else if (iLength <= 8)
            {
                f = new Font("楷体", 32);
            }
            else
            {
                f = new Font("楷体", 18);
            }
            labStationName.Font = f;
            SizeF sf = g.MeasureString(_StationName, f);

            labStationName.Width = (int)sf.Width + 8;
            labStationName.Height = (int)sf.Height;

            labStationName.ForeColor = Color.White;

            labStationName.Top = (int)(this.Height - sf.Height) / 2;
            //this.Refresh();
        }

        void pnlControl_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
            //throw new NotImplementedException();
        }

        void pnlControl_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawString("Test", new Font("宋体", 56), new SolidBrush(Color.White), 10, 10);
            //throw new NotImplementedException();
        }

        void pnlControl_MouseHover(object sender, EventArgs e)
        {
            this.OnMouseHover(e);
            //throw new NotImplementedException();
        }
        void pnlControl_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
            //throw new NotImplementedException();
        }

        void pnlControl_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
            //throw new NotImplementedException();
        }

        void pnlControl_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
            //throw new NotImplementedException();
        }
    }
}
