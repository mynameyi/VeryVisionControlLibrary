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
    public partial class Compass : UserControl
    {
        public Compass()
        {
            InitializeComponent();

            pbxDialContainer.Paint += new PaintEventHandler(pbxDialContainer_Paint);
        }

        void pbxDialContainer_Paint(object sender, PaintEventArgs e)
        {
            Control c = sender as Control;
            c.SuspendLayout();

            string s;
            Font f = new Font("宋体",12);
            SolidBrush sb = new SolidBrush(Color.Red);

            s = "0";
            SizeF sf = e.Graphics.MeasureString(s,f);
            e.Graphics.DrawString(s, f,sb, Settings.Dial0OffsetX, Settings.Origin.Y-sf.Height/2);//0刻度

            s = (_Range / 2).ToString();
            sf = e.Graphics.MeasureString(s, f);
            e.Graphics.DrawString(s, f, sb ,Settings.Origin.X - sf.Width / 2,Settings.DialCenterOffsetY);

            s = _Range.ToString();
            sf = e.Graphics.MeasureString(s, f);
            e.Graphics.DrawString(_Range.ToString(), f, sb, Settings.DialtMaxOffsetX, Settings.Origin.Y - sf.Height / 2);

            Bitmap bmpNeedleNew = new Bitmap(bmpNeedle);
            Graphics g = Graphics.FromImage(bmpNeedleNew);
            g.TranslateTransform(Settings.DisplayCenter.X,Settings.DisplayCenter.Y);
            g.RotateTransform(-90);
            s = (Angle / 180 * _Range).ToString("F2");
            if (s.Length > Settings.DisplayMaxLength)//超过屏显最大的字符位数时，需要去掉后面多余的字符
            {
                s = s.Remove(Settings.DisplayMaxLength);
            }
            sf = g.MeasureString(s, new Font("黑体", 12));
            g.DrawString(s, new Font("黑体", 12), new SolidBrush(Color.White), -sf.Width / 2, -sf.Height / 2);
            g.Dispose();

            switch (_BerthMode)
            {
                case BerthModeType.RightDown:
                    //e.Graphics.DrawImage(bmpDial, Settings.ReserveWidth, Settings.ReserveHeight);//画背景
                    e.Graphics.TranslateTransform(Settings.Origin.X,Settings.Origin.Y);//移动原点
                    e.Graphics.RotateTransform(Angle);
                    e.Graphics.DrawImage(bmpNeedleNew, -Settings.Origin.X, bmpDial.Height - Settings.Origin.Y - bmpNeedle.Height);
                    break;
                case BerthModeType.LeftTop:
                    ;
                    break;
                default:
                    break;
            }
            c.ResumeLayout();
            //throw new NotImplementedException();
        }

        Bitmap bmpDial = global::VeryVisionControlLibrary.Properties.Resource.Dial2;
        Bitmap bmpNeedle = global::VeryVisionControlLibrary.Properties.Resource.Needle2;
        public ControlSettings Settings = new ControlSettings();
        public class ControlSettings
        {
            public int ReserveWidth = 48;
            public int ReserveHeight = 72;
            public int RevisionWidth = 0;
            public int RevisionHeight = 0;
            public Point Origin = new Point(190, 188);
            public Point DisplayCenter = new Point(130,27);
            public int Dial0OffsetX = 28;
            public int DialtMaxOffsetX = 340;
            public int DialCenterOffsetY = 26;
            public int DisplayMaxLength = 4;
        }
        public enum BerthModeType
        {
            LeftTop,
            RightDown,
        }
        BerthModeType _BerthMode = BerthModeType.RightDown;
        public BerthModeType BerthMode
        {
            get
            {
                return _BerthMode;
            }
            set
            {
                _BerthMode = value;
            }
        }
        float Angle = 0F;
        float _Value = 0;
        public float Value
        {
            get { return _Value;}

            set 
            {

                //if (_Range == 0)
                //{
                //    throw new Exception("设置Value属性前必须先制定量程（Range属性）");
                //}

                if (value > _Range)
                {
                    value = _Range;
                }

                if (PointerThread != null)
                {
                    PointerThread.Abort();
                }
                PointerThread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(SwingThread));
                PointerThread.IsBackground = true;
                PointerThread.Start(value);
                //_Value = value;
            }
        }
        float _Range = 2;
        public float Range
        {
            get 
            {
                return _Range;
            }
            set
            {
                _Range = value;
            }
        }
        int _Rate = 1;
        public int Rate
        {
            get { return _Rate; }
            set {
                _Rate = value;
            }
        }
        System.Threading.Thread PointerThread = null;
        private void SwingThread(object obj)
        {
            float v = (float)obj;
            //以值为递增条件时，当量程很小，每个值得范围就会变得很大，指针的跨度很大，变化就会变快。
            //while (v > _Value)
            //{
            //    if (v - _Value > 1)
            //    {
            //        _Value++;
            //        //_Value = _Value + 2;
            //    }
            //    else
            //    {
            //        _Value = v;
            //    }
            //    Angle = _Value / _Range * 180;//获取需要转换的角度 
            //    System.Threading.Thread.Sleep(30);
            //    RefreshControl();
            //}

            //while (v < _Value)
            //{
            //    if (_Value - v > 1)
            //    {
            //        _Value--;
            //        //_Value = _Value - 2;
            //    }
            //    else
            //    {
            //        _Value = v;
            //    }
            //    Angle = _Value / _Range * 180;//获取需要转换的角度 
            //    System.Threading.Thread.Sleep(30);
            //    RefreshControl();
            //}

            //以角度为递增条件
            float a = v / _Range * 180;//获取需要转换的角度 
            while (a > Angle)
            {
                if (a - Angle > 2)
                {
                    //Angle++;
                    Angle += 2; 
                    //_Value += 2F / 180 * _Range;
                }
                else
                {
                    Angle = a;
                    //_Value += (a-Angle) /180 * _Range;
                }

                System.Threading.Thread.Sleep(_Rate);
                RefreshControl();
            }

            while (a < Angle)
            {
                if (Angle - a  > 2)
                {
                    //Angle--;
                    Angle -= 2;
                    //_Value -= 2F / 180 * _Range;
                }
                else
                {
                    Angle = a;
                    //_Value -= (Angle - a) / 180 * _Range;
                }

                System.Threading.Thread.Sleep(_Rate);
                RefreshControl();
            }

            _Value = v;
            PointerThread = null;
            //this.Refresh();//重绘当前控件
        }
        delegate void  RefreshControlDelegate();
        private void RefreshControl()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new RefreshControlDelegate(RefreshControl));
                return;
            };
            this.Refresh();
        }
        protected override void OnPaint(PaintEventArgs e)
        {

            ////this.Width = bmpDial.Width + Settings.ReserveWidth;
            ////this.Height = bmpDial.Height + Settings.ReserveHeight;
            //this.SuspendLayout();
            //switch (_BerthMode)
            //{
            //    case BerthModeType.RightDown:
            //        //e.Graphics.DrawImage(bmpDial, Settings.ReserveWidth, Settings.ReserveHeight);//画背景
            //        e.Graphics.TranslateTransform(190 + Settings.ReserveWidth, 188 + Settings.ReserveHeight);//170
            //        e.Graphics.RotateTransform(Angle);
            //        e.Graphics.DrawImage(bmpNeedle, -190, bmpDial.Height - 188 - bmpNeedle.Height);
            //        break;
            //    case BerthModeType.LeftTop:
            //        ;
            //        break;
            //    default:
            //        break;
            //}
            //this.ResumeLayout();
            //base.OnPaint(e);

            this.Width = bmpDial.Width + Settings.ReserveWidth;
            this.Height = bmpDial.Height + Settings.ReserveHeight;
            pbxDialContainer.Image = bmpDial;
            pbxDialContainer.Width = bmpDial.Width;
            pbxDialContainer.Height = bmpDial.Height;
            pbxDialContainer.Top = Settings.ReserveHeight;
            pbxDialContainer.Left = Settings.ReserveWidth;
        }
    }
}
