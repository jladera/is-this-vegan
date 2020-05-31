using System;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using Is_This_Vegan.Backend.Image;
using System.Drawing;
using Plugin.Media.Abstractions;

namespace Is_This_Vegan.Views
{
    public partial class PhotoCroppingPage : ContentPage
    {
        PhotoCropperCanvasView photoCropper;
        SKBitmap croppedBitmap;

        public PhotoCroppingPage(MediaFile image)
        {
            InitializeComponent();

            SKBitmap bitmap = SKBitmap.Decode(image.GetStream());
           

           // SKBitmap bitmap = BitmapExtensions.LoadBitmapResource(GetType(), "Is This Vegan.SharedMedia.test_ingredient_list_full.jpg");

            photoCropper = new PhotoCropperCanvasView(bitmap);
            canvasViewHost.Children.Add(photoCropper);
        }

        void OnDoneButtonClicked(object sender, EventArgs args)
        {
            croppedBitmap = photoCropper.CroppedBitmap;

            // Convert to Image
            var sKDataImage = croppedBitmap.Encode(SKEncodedImageFormat.Png, SKFilterQuality.Medium.GetHashCode());
            var imageStream = sKDataImage.AsStream();
            // var bitmap = new Bitmap(imageStream); doesn't work, stop trying this lol
            ImageSource source = ImageSource.FromStream( () => imageStream);
            

            // Add text extracting functionality here
            // 1) Determine necessary image type for tesseract to work
            // 2) Convert SKBitmap to necessary image type

            NavigateToResultPage(source, croppedBitmap);
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            canvas.DrawBitmap(croppedBitmap, info.Rect, BitmapStretch.Uniform);
        }

        public async void NavigateToResultPage(ImageSource source, SKBitmap croppedBitmap)
        {
            await Navigation.PushAsync(new Result(source, croppedBitmap), true);
        }
    }
}