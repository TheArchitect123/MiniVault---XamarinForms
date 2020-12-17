using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(Cross.DataVault.Effects.ButtonRoundedEffect), "ButtonRoundedEffect")]
namespace Cross.DataVault.iOS.Effects
{
    public class ButtonRoundedEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            this.Control.Layer.CornerRadius = 40.0f;
            this.Control.Layer.BorderWidth = 0.4f;
        }

        protected override void OnDetached()
        {
        }

    }
}