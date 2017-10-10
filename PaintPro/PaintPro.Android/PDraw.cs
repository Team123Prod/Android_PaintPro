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
using Android.Util;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace PaintPro.Droid
{
    [Register("PaintPro.Droid.PDraw")]
    public class PDraw : View
    {
        public PDraw(Context context, IAttributeSet attrs) :
           base(context, attrs)
        {
        }
        public XData_Android data {get; set;}
        float x;
        float y;
        List<Figure> figures = new List<Figure>();
        Paint paint;
        Canvas canvas;

        protected override void OnDraw(Canvas canvas)
        {
            this.canvas = canvas;
            canvas.ClipRect(new Rect(0, 0, Width, Height));
            paint = new Paint();
            paint.SetStyle(Paint.Style.Stroke);
            paint.StrokeJoin = Paint.Join.Round;
            paint.StrokeCap = Paint.Cap.Round;
            paint.AntiAlias = true;

            foreach (Figure f in figures)
            {
                paint.StrokeWidth = f.StrokeWidth;
                paint.Color = f.Color;
                canvas.DrawPath(f.Path, paint);
            }
        }

        private void AddFigure(float curX, float curY)
        {
            Figure figure = new Figure(new PointF(x, y), new PointF(curX, curY), data.Color, data.Width, data.Type);
            figures.Add(figure);

        }
        
        public override bool OnTouchEvent(MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    x = e.GetX();
                    y = e.GetY();
                    break;
                case MotionEventActions.Move:
                    Invalidate();
                    break;
                case MotionEventActions.Up:
                    AddFigure(e.GetX(), e.GetY());
                    Invalidate();
                    break;
                default:
                    return false;
            }
            return true;
        }
    }
}