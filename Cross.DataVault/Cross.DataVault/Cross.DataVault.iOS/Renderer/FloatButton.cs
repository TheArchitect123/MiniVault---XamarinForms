using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using CoreGraphics;
using UIKit;
using MaterialControls;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.PlatformConfiguration;

//[assembly: ExportRenderer(typeof(), typeof(Cross.DataVault.iOS.FloatButton))]
namespace Cross.DataVault.iOS
{
    public class FloatButton : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            //add the Material Ripple Button here
            MDButton RippleButton = new MDButton();
            RippleButton.Frame = new CGRect(Control.Frame.X, Control.Frame.Y, Control.Bounds.Width, Control.Bounds.Height);
            RippleButton.RippleColor = new UIColor(1.0f, 0.54f, 0.0f, 1.0f);
            
            RippleButton.VerticalAlignment = UIControlContentVerticalAlignment.Center;
            RippleButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;

            RippleButton.TitleLabel.TextAlignment = UITextAlignment.Center;

            RippleButton.BackgroundColor = Control.BackgroundColor;

            RippleButton.SetTitle(Control.TitleLabel.Text, UIControlState.Normal);
            RippleButton.SetTitle(Control.TitleLabel.Text, UIControlState.Highlighted);
            RippleButton.SetTitle(Control.TitleLabel.Text, UIControlState.Selected);

            RippleButton.SetTitleColor(Control.TitleLabel.TextColor, UIControlState.Normal);
            RippleButton.SetTitleColor(Control.TitleLabel.TextColor, UIControlState.Highlighted);
            RippleButton.SetTitleColor(Control.TitleLabel.TextColor, UIControlState.Selected);

            RippleButton.Font = Control.Font;
            

            //Borders
            RippleButton.Layer.BorderColor = Control.Layer.BorderColor;
            RippleButton.Layer.BorderWidth = Control.Layer.BorderWidth;
            RippleButton.Layer.CornerRadius = Control.Layer.CornerRadius;
            

            //    RippleButton.MdButtonType = MDButtonType.Flat;

            RippleButton.TouchUpInside += SendClicked;
            RippleButton.TouchDown += SendPressed;
            RippleButton.TouchCancel += SendReleased;

        //    this.SetNativeControl(RippleButton);
        }

        #region Touch Methods
        public void SendClicked(object sender, EventArgs e)
        {
            ((IButtonController)Element).SendClicked();
        }

        public void SendPressed(object sender, EventArgs e)
        {
            ((IButtonController)Element).SendPressed();
        }

        public void SendReleased(object sender, EventArgs e)
        {
            ((IButtonController)Element).SendReleased();
        }
        #endregion
    }
}