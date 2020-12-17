using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using XAM = Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;

[assembly: XAM.ExportEffect(typeof(Cross.DataVault.Effects.LeftAlignButtonEffect), "LeftAlignButtonEffect")]
namespace Cross.DataVault.Android.Effects
{
    public class LeftAlignButtonEffect : XAM.PlatformEffect<Button, Button>
    {
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            this.Control.TextAlignment = TextAlignment.TextStart;
        }

        protected override void OnAttached()
        {
            this.Control.TextAlignment = TextAlignment.TextStart;
        }

        protected override void OnDetached()
        {
        }
    }
}