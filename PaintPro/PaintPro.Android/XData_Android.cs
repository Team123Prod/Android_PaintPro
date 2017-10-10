using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static PaintPro.Droid.Figure;

namespace PaintPro.Droid
{
    public class XData_Android
    {
        public Android.Graphics.Color Color { get; set; }

        public int Width { get; set; }
        public FigureType Type { get; set; }

        public XData_Android()
        {
            Color = Android.Graphics.Color.Black;
            Width = 1;
            Type = FigureType.Rect;
        }
    }
}