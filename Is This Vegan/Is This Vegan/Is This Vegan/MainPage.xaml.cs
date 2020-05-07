using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Is_This_Vegan
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        async void OnBitmapDraggingPageButtonClicked(object sender, EventArgs e)
        {
            // Page appearance not animated
            await Navigation.PushAsync(new BitmapDraggingPage(), true);
        }

        //private void Black_Clicked(object sender, System.EventArgs e)
        //{
        //    BgColor.BackgroundColor = Color.FromHex("#000000");
        //}

        //private void Green_Clicked(object sender, System.EventArgs e)
        //{
        //    BgColor.BackgroundColor = Color.FromHex("00281A");
        //}

        //private void Blue_Clicked(object sender, System.EventArgs e)
        //{
        //    BgColor.BackgroundColor = Color.FromHex("040930");

        //}

        //private void Grey_Clicked(object sender, System.EventArgs e)
        //{
        //    BgColor.BackgroundColor = Color.FromHex("1a1a1a");

        //}

        //private void Purple_Clicked(object sender, System.EventArgs e)
        //{
        //    BgColor.BackgroundColor = Color.FromHex("16012B");
        //}

        //private void Eggplant_Clicked(object sender, System.EventArgs e)
        //{
        //    BgColor.BackgroundColor = Color.FromHex("18000F");
        //}
    }
}
