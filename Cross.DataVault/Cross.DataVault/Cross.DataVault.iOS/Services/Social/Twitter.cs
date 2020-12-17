using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Auth;
using Xamarin.Auth.Presenters;
using Xamarin.Auth.OAuth2;

using Cross.DataVault.Services.DependencyServices.Social;
using Cross.DataVault.ModelObjects;

namespace Cross.DataVault.iOS.Services.Social
{
    public class Twitter : ITwitter
    {
        public LoggedIn_SiteUser Login()
        {
            OAuth2Authenticator authenticator = new OAuth2Authenticator("", string.Empty, null, null, null, null);

            return null;
        }
    }
}