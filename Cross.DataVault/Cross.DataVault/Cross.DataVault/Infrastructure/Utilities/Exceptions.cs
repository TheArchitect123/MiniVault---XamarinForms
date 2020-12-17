using Caliburn.Micro;

//Helpers
using Cross.DataVault.Data.Mapper;
//Services
using Cross.DataVault.Services;

//Plugins
using Plugin.Toasts;
using Plugin.Toasts.Options;
using Plugin.LocalNotification;
using System;

using Xamarin.Forms;

namespace Cross.DataVault.Infrastructure.Utilities
{
    public class Exceptions : Exception
    {
        private ILogging logger;
        private string StackTrace;

        public Exceptions(string message) : base(message)
        {

        }

        public Exceptions(ILogging _logger, string message, string stackTrace) : this(message)
        {
            logger = _logger;
            StackTrace = stackTrace;
        }

        public void HandleException(Exception ex, object ologger)
        {
            string oMessage = this.Message;
            string oStackTrace = StackTrace;
            var mlogger = logger as ILogging;

            //Invoke Local Notification on Main Thread
            //Device.BeginInvokeOnMainThread(() =>
            //{
            //    var options = new LocalNotification();
            //    options.Title = "Issue Encountered";
            //    options.Description = Message;
            //    options.NotifyTime = DateTime.Now;
            //    options.NotificationId = 1;

            //    var notification = DependencyService.Get<ILocalNotificationService>();
            //    if (notification != null)
            //        notification.Show(options);
            //});

            //Write a log for client diagnostics
            if (mlogger != null)
                mlogger.AddLog(LocalMapper.Map_LogWithError(oMessage, oStackTrace, Guid.NewGuid().ToString(), Guid.NewGuid().ToString()));
        }
    }
}
