using Microsoft.UI.Xaml.Controls;
using SkiaSharp;
using SkiaSharp.Views.Windows;
using System;

namespace XamlBrewer.WinUI3.SkiaSharp.Sample
{
    public sealed partial class PythagorasTreePage : Page
    {
        public PythagorasTreePage()
        {
            this.InitializeComponent();
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKCanvas canvas = e.Surface.Canvas;

            canvas.Clear(SKColors.Transparent);

            // Configure and draw a Pythagoras Tree

            var side = 120f;
            var angle = 36f;
            var paint = new SKPaint
            {
                Color = SKColors.Brown,
                IsAntialias = true
            };

            canvas.Translate(e.Info.Width / 2, e.Info.Height - side);

            var r = new SKRect(0, 0, side, side);
            DrawNode(canvas, paint, r, angle, 14);
        }

        private static void DrawNode(SKCanvas canvas, SKPaint paint, SKRect rect, float angle, int steps)
        {
            if (steps == 0)
            {
                return;
            }

            steps--;
            canvas.Save();
            canvas.DrawRect(rect, paint);
            canvas.Save();

            var leftSide = (float)(rect.Width * Math.Cos(angle * 2 * Math.PI / 360));
            canvas.Translate((float)(-leftSide * Math.Sin(angle * 2 * Math.PI / 360)), (float)(-leftSide * Math.Cos(angle * 2 * Math.PI / 360)));
            canvas.RotateDegrees(-angle);
            var r = new SKRect(0, 0, leftSide, leftSide);
            DrawNode(canvas, paint, r, angle, steps);
            canvas.Restore();

            canvas.Save();
            var rightSide = (float)(rect.Width * Math.Sin(angle * 2 * Math.PI / 360));
            canvas.Translate((float)((rightSide + leftSide) * Math.Cos(angle * 2 * Math.PI / 360)), (float)(-(rightSide + leftSide) * Math.Sin(angle * 2 * Math.PI / 360)));
            canvas.RotateDegrees(90 - angle);
            var r2 = new SKRect(0, 0, rightSide, rightSide);
            DrawNode(canvas, paint, r2, angle, steps);
            canvas.Restore();

            canvas.Restore();
        }
    }
}
