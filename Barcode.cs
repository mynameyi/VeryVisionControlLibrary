/***********************************************
 * 功能/用途：条码显示控件
 * 目标：
 * 应用情景：
 * 版本号：V1.0;
 * 作者：Ecky Leung;
 * 立项时间：2022-4-28
 * 修改记录：
 * 备注：
 **********************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace VeryVisionControlLibrary
{
    public partial class Barcode : UserControl
    {
        [DllImport("Shell32.dll")]
        private extern static int ExtractIconEx(string libName, int iconIndex, IntPtr[] largeIcon, IntPtr[] smallIcon, int nIcons);

        //public delegate bool OnCheckedHandler(string code);
        //public event OnCheckedHandler Checked;

        public delegate void OnClosedHanlder(Barcode barcode);

        /// <summary>
        /// 发生关闭事件
        /// </summary>
        public event OnClosedHanlder Closed;


        Button mBtnClose;
        public Barcode()
        {
            InitializeComponent();

            //添加关闭窗口
            //PictureBox mPbClose;
            //mPbClose = new PictureBox();
            //mPbClose.SetBounds(Width - 16, 0, 16, 16);
            //this.Controls.Add(mPbClose);
            //mPbClose.Image = GetSystemCrossIcon().ToBitmap();

            mBtnClose = new Button();
            mBtnClose.SetBounds(Width - 16, 0, 16, 16);
            mBtnClose.BackgroundImage = GetSystemCrossIcon().ToBitmap();
            mBtnClose.Click += B_Click;
            this.Controls.Add(mBtnClose);

        }

        private void B_Click(object sender, EventArgs e)
        {
            Control c = this.Parent;
            c?.Controls.Remove(this);
            Closed?.Invoke(this);//通知上层发生关闭事件
            //throw new NotImplementedException();
        }

        public void SetStatus(bool isOK) {
            if (isOK) {
                BackColor = Color.Green;
            }
            else {
                BackColor = Color.Red;
            }
        }

        bool _closeButtonVisible = true;
        public bool CloseButtonVisible {
            get {
                return _closeButtonVisible;
            }
            set {
                _closeButtonVisible = value;

                if (mBtnClose == null)
                    return;

                mBtnClose.Visible = _closeButtonVisible;
            }
        }
        

        string _text;
        public override string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;

                //bool? isOK = Checked?.Invoke(_text);

                //if(isOK!=null)
                //    SetStatus(isOK.Value);

                Invalidate();
            }
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            mBtnClose?.SetBounds(Width - 16, 0, 16, 16);
            base.OnSizeChanged(e);
        }


        protected override void OnPaint(PaintEventArgs e) {
            SuspendLayout();

            DrawTextToCenter(e);

            ResumeLayout();
            base.OnPaint(e);
        }

        private void DrawTextToCenter(PaintEventArgs e) {
            Font ftName = new Font("楷书", 12);
            SizeF sf = e.Graphics.MeasureString(Text, ftName);
            PointF p = new PointF();

            p.X = (Width - sf.Width) / 2;
            p.Y = (Height - sf.Height) / 2;

            e.Graphics.DrawString(Text, ftName, new SolidBrush(Color.Black), p);
        }


        private Icon GetSystemCrossIcon() {

            IntPtr[] largeIcon = new IntPtr[1];
            IntPtr[] smallIcon = new IntPtr[1];

            ExtractIconEx("shell32.dll", 131, largeIcon, smallIcon, 1);
            Icon ic = Icon.FromHandle(smallIcon[0]);
            return ic;
        }
    }
}
