/*
 * Code provided by Microsoft SkiaSharp docs code sample
 * https://docs.microsoft.com/en-us/samples/xamarin/xamarin-forms-samples/skiasharpforms-demos/
 */

namespace Is_This_Vegan
{
    enum TouchManipulationMode
    {
        None,
        PanOnly,
        IsotropicScale,     // includes panning
        AnisotropicScale,   // includes panning
        ScaleRotate,        // implies isotropic scaling
        ScaleDualRotate     // adds one-finger rotation
    }
}
