using SkiaSharp;
using System.Drawing;
using Tesseract;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Is_This_Vegan.Backend.API;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Is_This_Vegan.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Result : ContentPage
    {
        // Instance that connects to RESTful API
        private TextExtractor textExtractor = new TextExtractor();

        public Result(ImageSource source, SKBitmap croppedBitmap)
        {
            InitializeComponent();

            TestPostImageAsync();
        }
        public async Task<bool> TestPostImageAsync()
        {
            try
            {
                var result = await textExtractor.PostImageAsync();

                if (result)
                {
                    var displayResult = textExtractor.response;
                    Console.WriteLine(displayResult);
                }
                return true;
            }
            catch (HttpRequestException)
            {
                await DisplayAlert("Server Issue", "We're sorry, there was an issue contacting the application server. Please try again after waiting a minute.", "Okay");
            }
            return false;
        }
    }
}