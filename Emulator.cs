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
    public partial class Emulator : UserControl
    {
        private string _Name = "O3";//监测因子名称
        private string _Unit = "PPB";//数值单位,初始化
        private string _Value = "0.0";//监测值
        private string _InstrumentModel = "赛默飞世尔Thermo 42C";//仪器型号
        private string _ErrorMessage = "设备运行正常";//异常信息
        LatticeWord LWMaker;//栅格字生成器
        Bitmap bmpValue;
        Bitmap bmpUnit;

        Point ptValuePos = new Point(15, 55);
        Point ptUnitPos = new Point(108, 64);
        //Point ptNamePos = new Point(14, 6);
        Point ptInstumentModal = new Point(44, 4);
        Point ptErrorMessage = new Point(0, 132);

        Rectangle rectEllipse = new Rectangle(10, 8, 38, 28);
        Font ftName = new Font("楷书", 12);

        int iInterval = 1000;
        System.Windows.Forms.Timer tAlarm = new Timer();

        public string ErrorMessage
        {
            get{
                return _ErrorMessage;
            }
            set 
            { 
                _ErrorMessage = value;
                Refresh();
            }
        }
        public object Value
        {
            get { return _Value;}
            set 
            {
                string strTypeName = value.GetType().Name,strValue = "";
                switch (strTypeName)
                {
                    case "Int32":
                        strValue = value.ToString();
                        break;
                    case "Int":
                        break;
                    case "String":
                        strValue =(string) value;
                        break;
                    case "Double":
                        strValue = value.ToString();
                        break;
                    case "Decimal":
                        strValue = value.ToString();
                        break;
                    default:
                        throw new Exception("请输入有效的数值类型");
                }
                if (_Value == strValue)
                {
                    return;
                }
                else
                {
                    _Value = strValue;
                    bmpValue = LWMaker.Make(_Value);
                    Refresh();
                }
            }
        }
        public string Unit
        {
            get 
            {
                return _Unit;
            }
            set {
                if (_Unit == value)
                {
                    return;
                }
                else
                {
                    _Unit = value;
                    bmpUnit = LWMaker.Make(_Unit);
                    Refresh();
                }
            }
        }
        public string FactorName
        {
            get {
                return _Name;
            }
            set 
            {
                _Name = value;
            }
        }

        public Emulator()
        {
            LWMaker = new LatticeWord();//栅格字生成器
            LWMaker.CharColor = Color.Orange;
            bmpValue = LWMaker.Make(_Value);
            bmpUnit = LWMaker.Make(_Unit);

            //初始化控件
            InitializeComponent();

            tAlarm.Interval = iInterval;
            tAlarm.Tick += new EventHandler(tAlarm_Tick);

        }

        void tAlarm_Tick(object sender, EventArgs e)
        {
            this.Refresh();
            //throw new NotImplementedException();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            SuspendLayout();
            //if (_Name.Length > 4)
            //{
            //    ftName = new Font("楷书", 8);
            //}
            //else
            //{
            //    ftName = new Font("楷书", 12);
            //}
            SizeF sf = e.Graphics.MeasureString(_Name, ftName);

            rectEllipse.Width = (int)sf.Width + 4;
            rectEllipse.Height = (int)sf.Height + 4;

            e.Graphics.DrawString(_Name, ftName, new SolidBrush(Color.Black), (rectEllipse.Width -sf.Width)/2 + rectEllipse.X , (rectEllipse.Height - sf.Height)/2 + rectEllipse.Y);

            //标志
            e.Graphics.DrawLine(new Pen(Color.OrangeRed, 2), 0, rectEllipse.Height / 2 + rectEllipse.Y, rectEllipse.X, rectEllipse.Height / 2 + rectEllipse.Y);
            e.Graphics.DrawEllipse(new Pen(Color.OrangeRed, 2), rectEllipse.X, rectEllipse.Y, rectEllipse.Width, rectEllipse.Height);
            e.Graphics.DrawLine(new Pen(Color.OrangeRed, 2), rectEllipse.Width + rectEllipse.X, rectEllipse.Height / 2 + rectEllipse.Y, this.Width, rectEllipse.Height / 2 + rectEllipse.Y);

            //e.Graphics.DrawString(_InstrumentModel, new Font("宋体", 8), new SolidBrush(Color.Black), ptInstumentModal.X, ptInstumentModal.Y);
            //e.Graphics.DrawLine(new Pen(Color.OrangeRed, 2), 0, 21, 180, 21);

            e.Graphics.DrawString(_InstrumentModel, new Font("宋体", 8), new SolidBrush(Color.Black),rectEllipse.Width+rectEllipse.X, ptInstumentModal.Y);
            e.Graphics.DrawImage(bmpValue,ptValuePos.X,ptValuePos.Y);//监测值
            if (_Value.Length <= 4)
            {
                e.Graphics.DrawImage(bmpUnit, ptUnitPos.X, ptUnitPos.Y);//单位
            }
            else
            {
                e.Graphics.DrawImage(bmpUnit, ptUnitPos.X, ptUnitPos.Y + 20);//单位;
            }

            e.Graphics.DrawLine(new Pen(Color.OrangeRed, 2),0,ptErrorMessage.Y - 4,this.Width,ptErrorMessage.Y - 4);
            sf = e.Graphics.MeasureString(_ErrorMessage, new Font("宋体", 10));
            e.Graphics.DrawString(_ErrorMessage, new Font("宋体", 10), new SolidBrush(Color.Black), (this.Width - sf.Width)/2, ptErrorMessage.Y);

            //e.Graphics.DrawRectangle(new Pen(Color.FromArgb(255, 255, 0, 0)), 0, 0, this.Width, this.Height);
            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 255, 0, 0)), 0, 0, this.Width, this.Height);
            if (_ErrorMessage != "设备运行正常")
            {
                tAlarm.Start();
                Flash();
            }
            else
            {
                tAlarm.Stop();
            }
            //e.Graphics.DrawLine(new Pen(Color.OrangeRed, 2), 0, 16, 10, 16);

            ////鼠标移到控件上发
            //if (IsOverControl)
            //{
            //    ;
            //}
            ResumeLayout();      
            base.OnPaint(e);
        }

        bool IsDraw = true;
        private void Flash()
        {
            if (IsDraw)
            {
                ControlOverPaint(this, Color.FromArgb(100, 255, 0, 0));
                IsDraw = false;
            }
            else
            {
                IsDraw = true;
            }
        }

        private void ControlOverPaint(Control control, Color color)
        {
            Graphics g;
            //根据实验结果，Alpha值每增加25，则Alpha加1 则最接近原控件颜色；
            //int iAlpha = color.A / 2 + 2;
            //int iAlpha = color.A / 2 + 5;
            //int iFillAlpha = color.A / 25;
            //int iFillAlpha = color.A / 15;
            //int iAlpha = color.A / 2 + iFillAlpha;
            //Color color2 = Color.FromArgb(iAlpha, color);

            foreach (Control item in control.Controls)
            {
                //g = item.CreateGraphics();
                //g.FillRectangle(new SolidBrush(color), 0, 0, item.Width, item.Height);
                item.Tag = color;
                item.Paint += new PaintEventHandler(item_Paint);
                //item.Paint += new PaintEventHandler(
                //    (sender, e) =>
                //    {
                //        //e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, item.Width, item.Height);
                //        e.Graphics.FillRectangle(new SolidBrush(color2), 0, 0, item.Width, item.Height);
                //        //System.Diagnostics.Trace.traceme
                //        //item.Paint-=
                //    }
                //    );

                //item.Paint -= new PaintEventHandler(
                //    (sender, e) =>
                //    {
                //        e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, item.Width, item.Height);
                //    }
                //    );
            }

            g = control.CreateGraphics();
            g.FillRectangle(new SolidBrush(color), 0, 0, control.Width, control.Height);
        }

        //Color cCurrentColor;
        void item_Paint(object sender, PaintEventArgs e)
        {
            Control control = ((Control)sender);
            Color color = (Color) control.Tag;
            control.SuspendLayout();
            e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, ((Control)sender).Width, control.Height);
            control.ResumeLayout();
            control.Paint -= new PaintEventHandler(item_Paint);
            //throw new NotImplementedException();
        }


        //控件移动
        Point? ptDownPos = null ;
        private void Emulator_MouseMove(object sender, MouseEventArgs e)
        {
            if (ptDownPos != null)
            {
                this.Top -= ((Point)ptDownPos).Y - e.Y;
                this.Left -= ((Point)ptDownPos).X - e.X;
            }
        }

        private void Emulator_MouseDown(object sender, MouseEventArgs e)
        {
            ptDownPos = new Point(e.X, e.Y);
        }

        private void Emulator_MouseUp(object sender, MouseEventArgs e)
        {
            ptDownPos = null;
        }

        bool IsOverControl = false;
        private void Emulator_MouseEnter(object sender, EventArgs e)
        {
            IsOverControl = true;
            this.Paint += new PaintEventHandler(Emulator_Paint);
            this.Refresh();
        }

        private void Emulator_MouseLeave(object sender, EventArgs e)
        {
            IsOverControl = false;
            this.Paint -= new PaintEventHandler(Emulator_Paint);
            this.Refresh();
        }

        void Emulator_Paint(object sender, PaintEventArgs e)
        {
            Color c = Color.FromArgb(180,Color.White);
            Control ctrl = sender as Control;
            this.Cursor = Cursors.Hand;
            ctrl.SuspendLayout();
            e.Graphics.FillRectangle(new SolidBrush(c),new Rectangle(0,0,this.Width,this.Height));
            
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Yellow),4),new Rectangle(0,0,this.Width,this.Height));
            ctrl.ResumeLayout();
            //this.Refresh();
            //throw new NotImplementedException();
        }
    }
}
