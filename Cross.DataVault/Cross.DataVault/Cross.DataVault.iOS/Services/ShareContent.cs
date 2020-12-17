using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Cross.DataVault.Services.DependencyServices;

namespace Cross.DataVault.iOS.Services
{
    public class ShareContent : IShareContent
    {
        public void OpenUp_ShareWindow()
        {
            UIActivityViewController ShareWindow = new UIActivityViewController(new NSObject[] { }, null);

            ShareWindow.ExcludedActivityTypes = null;
            if (UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController == null)
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(ShareWindow, true, null);
            else
            {
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController.DismissViewController(true, () =>
                {
                    UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(ShareWindow, true, null);
                });
            }
        }

        public void OpenUp_ShareWindowWithContent(object data)
        {
            UIActivityViewController ShareWindow = new UIActivityViewController(new NSObject[] { NSObject.FromObject(data) }, null);

            ShareWindow.ExcludedActivityTypes = null;
            if (UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController == null)
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(ShareWindow, true, null);
            else
            {
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController.DismissViewController(true, () =>
                {
                    UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(ShareWindow, true, null);
                });
            }
        }
    }
}