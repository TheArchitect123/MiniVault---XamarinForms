using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MaterialControls;
using CoreAnimation;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Entry), typeof(Cross.DataVault.iOS.TextField))]
namespace Cross.DataVault.iOS
{
    public class TextField : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            Control.ClearButtonMode = UITextFieldViewMode.UnlessEditing;
            Control.ClipsToBounds = false;

            Control.BorderStyle = UITextBorderStyle.None;
        
            //Control.Layer.BorderColor = UIColor.Black.CGColor;
            //Control.Layer.BorderWidth = 0.2f;


            UILabel Border = new UILabel();
            Border.Text = "____________________________________________";
            Border.ClipsToBounds = true;
            Border.LineBreakMode = UILineBreakMode.Clip;
            Border.Frame = new CoreGraphics.CGRect(0, Control.Frame.Bottom, Control.Bounds.Width, 20.0f);

            Control.AddSubview(Border);
        }
    }
}