﻿using System.Threading.Tasks;
using Feedback.Core.Services.Implementation;
using Foundation;
using Microsoft.WindowsAzure.MobileServices;
using UIKit;

namespace Feedback.iOS.Services
{
    public class AuthenticationService : BaseAuthenticationService
    {
        protected override async Task<MobileServiceUser> GetFacebookUserAsync()
        {
            return await MobileService.LoginAsync(UIApplication.SharedApplication.KeyWindow.RootViewController, MobileServiceAuthenticationProvider.Facebook);
        }

        protected override void LogoutNative()
        {
            foreach(var cookie in NSHttpCookieStorage.SharedStorage.Cookies)
            {
                NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
            }
        }
    }
}