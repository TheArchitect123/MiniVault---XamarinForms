using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Editor), typeof(Cross.DataVault.iOS.EditorView))]
namespace Cross.DataVault.iOS
{
    public class EditorView : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            Control.Layer.BorderColor = UIColor.Black.CGColor;
            Control.Layer.BorderWidth = 0.2f;   
        }
    }
} 