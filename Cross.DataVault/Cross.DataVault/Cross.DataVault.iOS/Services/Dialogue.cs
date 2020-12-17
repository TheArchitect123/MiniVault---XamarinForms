using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Cross.DataVault.Services.DependencyServices;

namespace Cross.DataVault.iOS.Services
{
    public class Dialogue : IDialogue
    {
        //Take Photos & Videos
        public void ShowAlert_WithCameraOption(string Title, string Message, Action Photo, Action Video)
        {
            UIAlertController Alert = UIAlertController.Create(Title, Message, UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Photo", UIAlertActionStyle.Default, (e) => {
                if (Photo != null)
                    Photo.Invoke();
            }));

            Alert.AddAction(UIAlertAction.Create("Pick Photo", UIAlertActionStyle.Default, (e) => {
                if (Photo != null)
                    Video.Invoke();
            }));


            if (UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController == null)
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(Alert, true, null);
            else
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController.DismissViewController(true, () =>
                {
                    UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(Alert, true, null);
                });
        }

        public void ShowAlert(string Title, string Message)
        {
            UIAlertController Alert = UIAlertController.Create(Title, Message, UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (e) => { }));

            if (UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController == null)
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(Alert, true, null);
            else
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController.DismissViewController(true, () =>
                {
                    UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(Alert, true, null);
                });
        }

        public void ShowAlert_WithAction(string Title, string Message, Action Action)
        {
            UIAlertController Alert = UIAlertController.Create(Title, Message, UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (e) =>
            {
                if (Action != null)
                    Action.Invoke();
            }));

            if (UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController == null)
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(Alert, true, null);
            else
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController.DismissViewController(true, () =>
                {
                    UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(Alert, true, null);
                });
        }

        public void ShowAlert_WithCancel(string Title, string Message, string Cancel)
        {
            UIAlertController Alert = UIAlertController.Create(Title, Message, UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (e) =>
            {
            }));

            Alert.AddAction(UIAlertAction.Create(Cancel, UIAlertActionStyle.Cancel, (e) =>
            {
            }));

            if (UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController == null)
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(Alert, true, null);
            else
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController.DismissViewController(true, () =>
                {
                    UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(Alert, true, null);
                });
        }

        public void ShowAlert_WithCancelWithAction(string Title, string Message, string Cancel, Action Action)
        {
            UIAlertController Alert = UIAlertController.Create(Title, Message, UIAlertControllerStyle.Alert);
            Alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, (e) =>
            {
                if (Action != null)
                    Action.Invoke();
            }));

            Alert.AddAction(UIAlertAction.Create(Cancel, UIAlertActionStyle.Cancel, (e) =>
            {
            }));

            if (UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController == null)
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(Alert, true, null);
            else
                UIApplication.SharedApplication.KeyWindow.RootViewController.PresentedViewController.DismissViewController(true, () =>
                {
                    UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(Alert, true, null);
                });
        }
    }
}