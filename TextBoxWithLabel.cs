using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


public partial class TextBoxWithLabel : UserControl
{

    public TextBoxWithLabel()
    {
        InitializeComponent();
    }



    public string Title {
        set {           
            //mLableLeastWidth = (int)label1.CreateGraphics().MeasureString(value, label1.Font).Width + 5;
            label1.Text = value;
        }

        get {
            return label1.Text;
        }
    }

    public string Content {
        get {
            return textBox1.Text;
        }

        set {
            textBox1.Text = value;
        }
    }

    public TextBox TxBox {
        get {
            return textBox1;
        }
    }

    int _lableAndTextBoxGap = 5;
    public int LableAndTextBoxGap {
        get {
            return _lableAndTextBoxGap;
        }set {
            _lableAndTextBoxGap = value;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        this.SuspendLayout();
        textBox1.SuspendLayout();
        label1.SuspendLayout();


        Rectangle rect = label1.ClientRectangle;

        int left = rect.Width + _lableAndTextBoxGap;
        textBox1.SetBounds(left, 0, Width - left, textBox1.Height);

        label1.ResumeLayout();
        textBox1.ResumeLayout();
        this.ResumeLayout();

        System.Diagnostics.Trace.WriteLine("mmmm = ");


        base.OnPaint(e);
    }

    //protected override void OnLoad(EventArgs e)
    //{
    //    base.OnLoad(e);

    //    textBox1.Width = this.Width - label1.Width;
    //}
}

