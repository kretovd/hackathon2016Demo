﻿using System.Threading.Tasks;
using Android.Webkit;
using Feedback.Core.Services.Implementation;
using Microsoft.WindowsAzure.MobileServices;

namespace Feedback.UI.Droid.Services
{
    public class AuthenticationService : BaseAuthenticationService
    {
        protected override Task<MobileServiceUser> GetFacebookUserAsync()
        {
            return MobileService.LoginAsync(MainActivity.Instance, MobileServiceAuthenticationProvider.Facebook);
        }

        protected override void LogoutNative()
        {
            CookieManager.Instance.RemoveAllCookie();
        }
    }
}