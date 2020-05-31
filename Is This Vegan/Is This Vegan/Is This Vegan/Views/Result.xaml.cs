using Is_This_Vegan.Backend.Tesseract;
using SkiaSharp;
using System.Drawing;
using Tesseract;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Is_This_Vegan.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Result : ContentPage
    {
        private TextExtractor textExtractor;

        public Result(ImageSource source, SKBitmap croppedBitmap)
        {
            InitializeComponent();
            textExtractor = new TextExtractor();
            var response = textExtractor.ExtractFromImageTestAsync();
            MyImage.Source = source;
            
        }
    }
}