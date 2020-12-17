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

using Plugin.CurrentActivity;
using Cross.DataVault.Services.DependencyServices;

namespace Cross.DataVault.Android.Services
{
    public class Dialogue : IDialogue
    {
        //Take Photos & Video
        public void ShowAlert_WithCameraOption(string Title, string Message, Action Photo, Action Video)
        {
            var dialogue = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity);
            dialogue.SetTitle(Title);
            dialogue.SetMessage(Message);

            dialogue.SetPositiveButton("Photo", (sender, e) =>
            {
                if (Photo != null)
                    Photo.Invoke();
            });

            dialogue.SetNegativeButton("Pick Photo", (sender, e) =>
            {
                if (Video != null)
                    Video.Invoke();
            });
            
            AlertDialog alertDialogue = dialogue.Create();
            alertDialogue.Show();
        }

        public void ShowAlert(string Title, string Message)
        {
            var dialogue = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity);
            dialogue.SetTitle(Title);
            dialogue.SetMessage(Message);

            dialogue.SetPositiveButton("Ok", (sender, e) =>
            {
                //Business Logic goes here
            });

            AlertDialog alertDialogue = dialogue.Create();
            alertDialogue.Show();
        }

        public void ShowAlert_WithAction(string Title, string Message, Action Action)
        {
            var dialogue = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity);
            dialogue.SetTitle(Title);
            dialogue.SetMessage(Message);

            dialogue.SetPositiveButton("Ok", (sender, e) =>
            {
                if (Action != null)
                    Action.Invoke();
            });

            AlertDialog alertDialogue = dialogue.Create();
            alertDialogue.Show();
        }

        public void ShowAlert_WithCancel(string Title, string Message, string Cancel)
        {
            var dialogue = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity);
            dialogue.SetTitle(Title);
            dialogue.SetMessage(Message);

            dialogue.SetPositiveButton("Ok", (sender, e) =>
            {
                //Business Logic goes here
            });

            string cancel = string.Empty;
            if (string.IsNullOrWhiteSpace(Cancel))
                cancel = "Later";
            else
                cancel = Cancel;

            dialogue.SetNegativeButton(cancel, (sender, e) =>
            {
                //Business Logic goes here

            });

            AlertDialog alertDialogue = dialogue.Create();
            alertDialogue.Show();
        }

        public void ShowAlert_WithCancelWithAction(string Title, string Message, string Cancel, Action Action)
        {
            var dialogue = new AlertDialog.Builder(CrossCurrentActivity.Current.Activity);
            dialogue.SetTitle(Title);
            dialogue.SetMessage(Message);

            dialogue.SetPositiveButton("Ok", (sender, e) =>
            {
                if (Action != null)
                    Action.Invoke();
            });

            string cancel = string.Empty;
            if (string.IsNullOrWhiteSpace(Cancel))
                cancel = "Later";
            else
                cancel = Cancel;

            dialogue.SetNegativeButton(cancel, (sender, e) =>
            {
                //Business Logic goes here

            });

            AlertDialog alertDialogue = dialogue.Create();
            alertDialogue.Show();
        }
    }
}