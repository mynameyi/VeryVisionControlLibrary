using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;
namespace VeryVisionControlLibrary
{
    public class LatticeWord
    {
        #region------字符库-------
        Matrix[] CharLibray = new Matrix[]
        {
            new Matrix(//0
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(2,1),
                new Point(2,5),
                new Point(3,1),
                new Point(3,5),
                new Point(4,1),
                new Point(4,5),
                new Point(5,1),
                new Point(5,5),
                new Point(6,2),
                new Point(6,3),
                new Point(6,4)
                ),

            new Matrix(//1
                new Point(1,3),
                new Point(2,2),
                new Point(2,3),
                new Point(3,3),
                new Point(4,3),
                new Point(5,3),
                new Point(6,2),
                new Point(6,3),
                new Point(6,4)),

            new Matrix(//2
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(2,1),
                new Point(2,5),
                new Point(3,4),
                new Point(4,3),
                new Point(5,2),
                new Point(6,1),
                new Point(6,2),
                new Point(6,3),
                new Point(6,4),
                new Point(6,5)),

            new Matrix(//3
                new Point(1,1),
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(1,5),
                new Point(2,5),
                new Point(3,3),
                new Point(3,4),
                new Point(4,5),
                new Point(5,1),
                new Point(5,5),
                new Point(6,2),
                new Point(6,3),
                new Point(6,4)),

            new Matrix(//4
                new Point(1,4),
                new Point(2,3),
                new Point(2,4),
                new Point(3,2),
                new Point(3,4),
                new Point(4,1),
                new Point(4,4),
                new Point(5,1),
                new Point(5,2),
                new Point(5,3),
                new Point(5,4),
                new Point(5,5),
                new Point(6,4)),

            new Matrix(//5
                new Point(1,1),
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(1,5),
                new Point(2,1),
                new Point(3,1),
                new Point(3,2),
                new Point(3,3),
                new Point(3,4),
                new Point(4,5),
                new Point(5,1),
                new Point(5,5),
                new Point(6,2),
                new Point(6,3),
                new Point(6,4)),

            new Matrix(//6
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(2,1),
                new Point(3,1),
                new Point(3,2),
                new Point(3,3),
                new Point(3,4),
                new Point(4,1),
                new Point(4,5),
                new Point(5,1),
                new Point(5,5),
                new Point(6,2),
                new Point(6,3),
                new Point(6,4)),

            new Matrix(//7
                new Point(1,1),
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(1,5),
                new Point(2,5),
                new Point(3,4),
                new Point(4,3),
                new Point(5,3),
                new Point(6,3)),

            new Matrix(//8
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(2,1),
                new Point(2,5),
                new Point(3,2),
                new Point(3,3),
                new Point(3,4),
                new Point(4,1),
                new Point(4,5),
                new Point(5,1),
                new Point(5,5),
                new Point(6,2),
                new Point(6,3),
                new Point(6,4)),

            new Matrix(//9
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(2,1),
                new Point(2,5),
                new Point(3,1),
                new Point(3,5),
                new Point(4,2),
                new Point(4,3),
                new Point(4,4),
                new Point(4,5),
                new Point(5,5),
                new Point(6,2),
                new Point(6,3),
                new Point(6,4)),

            new Matrix(//B
                new Point(1,1),
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(2,1),
                new Point(2,5),
                new Point(3,1),
                new Point(3,2),
                new Point(3,3),
                new Point(3,4),
                new Point(4,1),
                new Point(4,5),
                new Point(5,1),
                new Point(5,5),
                new Point(6,1),
                new Point(6,2),
                new Point(6,3),
                new Point(6,4)),

            new Matrix(//P
                new Point(1,1),
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(2,1),
                new Point(2,5),
                new Point(3,1),
                new Point(3,5),
                new Point(4,1),
                new Point(4,2),
                new Point(4,3),
                new Point(4,4),
                new Point(5,1),
                new Point(6,1)),

            new Matrix(//.
                new Point(5,2),
                new Point(5,3),
                new Point(6,2),
                new Point(6,3)),

            new Matrix(//M
                new Point(1,2),
                new Point(1,3),
                new Point(1,4),
                new Point(2,1),
                new Point(2,3),
                new Point(2,5),
                new Point(3,1),
                new Point(3,3),
                new Point(3,5),
                new Point(4,1),
                new Point(4,3),
                new Point(4,5),
                new Point(5,1),
                new Point(5,3),
                new Point(5,5),
                new Point(6,1),
                new Point(6,3),
                new Point(6,5)),

             new Matrix(//℃
                new Point(1,2),
                new Point(1,4),
                new Point(2,1),
                new Point(2,3),
                new Point(2,5),
                new Point(3,2),
                new Point(3,3),
                new Point(4,3),
                new Point(5,3),
                new Point(5,5),
                new Point(6,4)),

             new Matrix(// -
                new Point(3,1),
                new Point(3,2),
                new Point(3,3),
                new Point(3,4),
                new Point(3,5)),
        };
        #endregion
        int _ScaleX = 4, _ScaleY = 4;
        Color _CharColor = Color.White;
        public Color CharColor
        {
            get { return _CharColor; }
            set { _CharColor = value; }
        }
        public System.Drawing.Bitmap Create(char c)
        {
            Point[] Points = null;
            Bitmap bmpChar = new Bitmap(_ScaleX * 5 + 2,_ScaleY * 6 + 2);
            switch (c)
            {
                case '0':
                    Points = CharLibray[0].Scale(_ScaleX,_ScaleY);
                    break;
                case '1':
                    Points = CharLibray[1].Scale(_ScaleX, _ScaleY);
                    break;
                case '2':
                    Points = CharLibray[2].Scale(_ScaleX, _ScaleY);
                    break;
                case '3':
                    Points = CharLibray[3].Scale(_ScaleX, _ScaleY);
                    break;
                case '4':
                    Points = CharLibray[4].Scale(_ScaleX, _ScaleY);
                    break;
                case '5':
                    Points = CharLibray[5].Scale(_ScaleX, _ScaleY);
                    break;
                case '6':
                    Points = CharLibray[6].Scale(_ScaleX, _ScaleY);
                    break;
                case '7':
                    Points = CharLibray[7].Scale(_ScaleX, _ScaleY);
                    break;
                case '8':
                    Points = CharLibray[8].Scale(_ScaleX, _ScaleY);
                    break;
                case '9':
                    Points = CharLibray[9].Scale(_ScaleX, _ScaleY);
                    break;
                case 'P':
                    Points = CharLibray[11].Scale(_ScaleX, _ScaleY);
                    break;
                case 'B':
                    Points = CharLibray[10].Scale(_ScaleX, _ScaleY);
                    break;
                case 'p':
                    break;
                case 'b':
                    break;
                case '.':
                    Points = CharLibray[12].Scale(_ScaleX, _ScaleY);
                    break;
                case 'M':
                    Points = CharLibray[13].Scale(_ScaleX, _ScaleY);
                    break;
                case '℃':
                    Points = CharLibray[14].Scale(_ScaleX, _ScaleY);
                    break;
                case '-':
                    Points = CharLibray[15].Scale(_ScaleX, _ScaleY);
                    break;
                default:
                    return bmpChar;
            }

            foreach (var p in Points)
            {
                for (int i = 0; i < _ScaleY; i++)
                {
                    for (int j = 0; j < _ScaleX; j++)
                    {
                        bmpChar.SetPixel(p.Y - j, p.X - i, _CharColor);
                    }
                }
            }

            return bmpChar;
        }
        Bitmap bmpResult = null;
        public Bitmap Make(string OriginalString)
        {
            bmpResult = null;//清空原位图

            foreach (var c in OriginalString)
            {
                bmpResult = this + this.Create(c);
            }
            return bmpResult;
        }
        public static Bitmap operator +(LatticeWord lw, Bitmap bmp)
        {
            Bitmap bmpCurrent;
            int iWidth = 0, iHeight = 0, iWidth2 = 0, iHeight2 = 0;
            if (lw.bmpResult != null)
            {
                bmpCurrent = new Bitmap(lw.bmpResult.Width + bmp.Width, lw.bmpResult.Height + bmp.Height);

                iWidth = lw.bmpResult.Width;
                iHeight = lw.bmpResult.Height;

                for (int i = 0; i < iWidth; i++)
                {
                    for (int j = 0; j < iHeight; j++)
                    {
                        bmpCurrent.SetPixel(i, j, lw.bmpResult.GetPixel(i, j));
                    }
                }

                iWidth2 = bmp.Width;
                iHeight2 = bmp.Height;

                for (int i = 0; i < iWidth2; i++)
                {
                    for (int j = 0; j < iHeight2; j++)
                    {
                        bmpCurrent.SetPixel(iWidth + i, j, bmp.GetPixel(i, j));
                    }
                }
            }
            else
            {
                bmpCurrent = bmp;
            }
            return bmpCurrent;
        }
    }
    public class LatticeWord8
    {
        int _CharHeight = 12;//字符高度
        public int CharHeight
        {
            get 
            {
                return _CharHeight;
            }
            set 
            {
                _CharHeight = value;
            }
        }
        int _CharThickness = 2;
        public int CharThickness
        {
            get { return _CharThickness; }
            set { _CharThickness = value; }
        }
        Color _CharColor = Color.White;
        public Color CharColor
        {
            get { return _CharColor; }
            set { _CharColor = value; }
        }
        Point[][] LatticeSet = new Point[][]
        {
            new Point[]{
                new Point(1,2),
                new Point(1,3),
                new Point(2,1),
                new Point(2,4),
                new Point(3,1),
                new Point(3,4),
                new Point(4,1),
                new Point(4,4),
                new Point(5,1),
                new Point(5,4),
                new Point(6,1),
                new Point(6,4),
                new Point(7,1),
                new Point(7,4),
                new Point(8,1),
                new Point(8,4),
                new Point(9,1),
                new Point(9,4),
                new Point(10,1),
                new Point(10,4),
                new Point(11,2),
                new Point(11,3)
            }
        };
        public System.Drawing.Bitmap Create(char c)
        {

            int Width = _CharHeight/2;
            Bitmap bmpChar = new Bitmap(Width,_CharHeight);
            int thick, up, down, middle, left, right;
            bool IsOdd = (_CharHeight + _CharThickness) % 2 == 0 ? false : true;
            left = 1;
            right = Width - _CharThickness - 1;
            middle = Width - 1;
            up = 1;
            if (IsOdd)
            {
                down = _CharHeight - _CharThickness - 1 - 1;
            }
            else
            {
                down = _CharHeight - _CharThickness - 1;
            }
            switch (c)
            {
                case '0':
                    //横
                    for (int i = 0; i < _CharThickness; i++)
                    {
                        for (int j = left + _CharThickness; j < right; j++)
                        {
                            bmpChar.SetPixel(j,up + i,_CharColor);
                        }
                    }
                    for (int i = 0; i < _CharThickness; i++)
                    {
                        for (int j = up + _CharThickness; j < down; j++)
                        {
                            bmpChar.SetPixel(left + i, j, _CharColor);
                        }
                    }
                    //竖
                    for (int i = 0; i < _CharThickness; i++)
                    {
                        for (int j = up + _CharThickness; j < down; j++)
                        {
                            bmpChar.SetPixel(right + i, j, _CharColor);
                        }
                    }
                    //底线
                    for (int i = 0; i < _CharThickness; i++)
                    {
                        for (int j = left + _CharThickness; j < right; j++)
                        {
                            bmpChar.SetPixel(j,down + i, _CharColor);
                        }
                    }
                    //bmpChar.set
                    break;
                case '1':
                    break;
                case '2':
                    break;
                case '3':
                    break;
                case '4':
                    break;
                case '5':
                    break;
                case '6':
                    break;
                case '7':
                    break;
                case '8':
                    break;
                case '9':
                    break;
                case 'p':
                    break;
                case 'b':
                    break;
                default:
                    break;
            }
            return bmpChar;
        }

        public static Bitmap operator +(LatticeWord8 lw8,Bitmap bmp1)
        {
            return new Bitmap(48, 24);
        }
    }

    public class Matrix
    {
        Point[] PointMatrix;
        public Matrix(params Point[] Points)
        {
            //PointMatrix = new Point[Points.Length];
            PointMatrix = Points;
        }
        public Point[] Scale(int x,int y)
        {
            Point[] ScaleMatrix = new Point[PointMatrix.Length];
            int iLength = PointMatrix.Length;
            for (int i = 0; i < iLength; i++)
            {
                ScaleMatrix[i].X = PointMatrix[i].X * y;
                ScaleMatrix[i].Y = PointMatrix[i].Y * x;
            }
            return ScaleMatrix;
        }
    }
}
