using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(Cross.DataVault.Effects.LeftAlignButtonEffect), "LeftAlignButtonEffect")]
namespace Cross.DataVault.iOS.Effects
{
    public class LeftAlignButtonEffect : PlatformEffect<UIButton, UIButton>
    {
        protected override void OnAttached()
        {
            this.Control.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
        }

        protected override void OnDetached()
        {
        }
    }
}