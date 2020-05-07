/*
 * Code provided by Microsoft SkiaSharp docs code sample
 * https://docs.microsoft.com/en-us/samples/xamarin/xamarin-forms-samples/skiasharpforms-demos/
 */
 
 using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly: ResolutionGroupName("XamarinDocs")]
[assembly: ExportEffect(typeof(Is_This_Vegan.iOS.TouchEffect), "TouchEffect")]

namespace Is_This_Vegan.iOS
{
    public class TouchEffect : PlatformEffect
    {
        UIView view;
        TouchRecognizer touchRecognizer;

        protected override void OnAttached()
        {
            // Get the iOS UIView corresponding to the Element that the effect is attached to
            view = Control == null ? Container : Control;

            // Get access to the TouchEffect class in the .NET Standard library
            Is_This_Vegan.TouchEffect effect = (Is_This_Vegan.TouchEffect)Element.Effects.FirstOrDefault(e => e is Is_This_Vegan.TouchEffect);

            if (effect != null && view != null)
            {
                // Create a TouchRecognizer for this UIView
                touchRecognizer = new TouchRecognizer(Element, view, effect);
                view.AddGestureRecognizer(touchRecognizer);
            }
        }

        protected override void OnDetached()
        {
            if (touchRecognizer != null)
            {
                // Clean up the TouchRecognizer object
                touchRecognizer.Detach();

                // Remove the TouchRecognizer from the UIView
                view.RemoveGestureRecognizer(touchRecognizer);
            }
        }
    }
}