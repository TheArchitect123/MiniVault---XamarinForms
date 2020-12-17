using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Label), typeof(Cross.DataVault.iOS.TextLabel))]
namespace Cross.DataVault.iOS
{
    public class TextLabel : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            Control.LineBreakMode = UILineBreakMode.Clip;
        }
    }
}