using Xamarin.Forms;
using Is_This_Vegan.Views;

namespace Is_This_Vegan
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            
            // Make Navigation Bar align with our palette
            ((NavigationPage)MainPage).BarBackgroundColor = Color.FromHex("#1A1A1A");//#292929
            ((NavigationPage)MainPage).BarTextColor = Color.FromHex("#1F775C");
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
