using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Caliburn.Micro;
using Cross.DataVault.Services;
using Cross.DataVault.Data.Mapper;
using Cross.DataVault.Infrastructure.Utilities;

namespace Cross.DataVault.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            try
            {
                UIApplication.Main(args, null, "AppDelegate");
            }
            catch (Exception ex)
            {
                string Message = "";
                string StackTrace = "";

                if (ex.InnerException != null)
                {
                    Message = ex.InnerException.Message;
                    StackTrace = ex.InnerException.StackTrace;
                }
                else
                {
                    Message = ex.Message;
                    StackTrace = ex.StackTrace;
                }

                var logging = IoC.Get<ILogging>();
                var pEx = new Exceptions(logging, Message, StackTrace);
                if (pEx != null)
                    pEx.HandleException(pEx, logging);
            }
        }
    }
}
