/*
 * Code provided by Microsoft SkiaSharp docs code sample
 * https://docs.microsoft.com/en-us/samples/xamarin/xamarin-forms-samples/skiasharpforms-demos/
 */

using Xamarin.Forms;

namespace Is_This_Vegan.Backend
{
    public class TouchEffect : RoutingEffect
    {
        public event TouchActionEventHandler TouchAction;

        public TouchEffect() : base("XamarinDocs.TouchEffect")
        {
        }

        public bool Capture { set; get; }

        public void OnTouchAction(Element element, TouchActionEventArgs args)
        {
            TouchAction?.Invoke(element, args);
        }
    }
}
