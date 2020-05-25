using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Is_This_Vegan.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Result : ContentPage
{
    public Result(System.Drawing.Image image)
    {
        InitializeComponent();
    }
}
}