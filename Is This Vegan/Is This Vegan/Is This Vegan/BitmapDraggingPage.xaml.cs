/*
 * Code provided by Microsoft SkiaSharp docs code sample
 * https://docs.microsoft.com/en-us/samples/xamarin/xamarin-forms-samples/skiasharpforms-demos/
 */

using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Xamarin.Forms;

namespace Is_This_Vegan
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class BitmapDraggingPage : ContentPage
    {
        TouchManipulationBitmap bitmap;
        List<long> touchIds = new List<long>();
        MatrixDisplay matrixDisplay = new MatrixDisplay();

        public BitmapDraggingPage()
        {
            InitializeComponent();

            string resourceID = "Is This Vegan.SharedMedia.Neon_Circle.png";
            Assembly assembly = GetType().GetTypeInfo().Assembly;

            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                SKBitmap bitmap = SKBitmap.Decode(stream);
                this.bitmap = new TouchManipulationBitmap(bitmap);
                this.bitmap.TouchManager.Mode = TouchManipulationMode.ScaleRotate;
            }
        }

        void OnTouchModePickerSelectedIndexChanged(object sender, EventArgs args)
        {
            if (bitmap != null)
            {
                Picker picker = (Picker)sender;
                bitmap.TouchManager.Mode = (TouchManipulationMode)picker.SelectedItem;
            }
        }

        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            // Convert Xamarin.Forms point to pixels
            Point pt = args.Location;
            SKPoint point =
                new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                            (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));

            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (bitmap.HitTest(point))
                    {
                        touchIds.Add(args.Id);
                        bitmap.ProcessTouchEvent(args.Id, args.Type, point);
                        break;
                    }
                    break;

                case TouchActionType.Moved:
                    if (touchIds.Contains(args.Id))
                    {
                        bitmap.ProcessTouchEvent(args.Id, args.Type, point);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Released:
                case TouchActionType.Cancelled:
                    if (touchIds.Contains(args.Id))
                    {
                        bitmap.ProcessTouchEvent(args.Id, args.Type, point);
                        touchIds.Remove(args.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;
            }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            // Display the bitmap
            bitmap.Paint(canvas);

            // Display the matrix in the lower-right corner
            SKSize matrixSize = matrixDisplay.Measure(bitmap.Matrix);

            matrixDisplay.Paint(canvas, bitmap.Matrix,
                new SKPoint(info.Width - matrixSize.Width,
                            info.Height - matrixSize.Height));
        }
    }
}
