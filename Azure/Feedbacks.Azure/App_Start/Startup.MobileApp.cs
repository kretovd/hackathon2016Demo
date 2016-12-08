﻿using Feedbacks.Azure.DataObjects;
using Feedbacks.Azure.Models;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Owin;
using System;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;

namespace Feedbacks.Azure
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new MobileServiceInitializer());

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    // This middleware is intended to be used locally for debugging. By default, HostName will
                    // only have a value when running in an App Service application.
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }

            app.UseWebApi(config);
        }
    }

    public class MobileServiceInitializer : CreateDatabaseIfNotExists<MobileServiceContext>
    {
        protected override void Seed(MobileServiceContext context)
        {
            var placeItem = new PlaceItem
                            {
                                Id = Guid.NewGuid().ToString(),
                                BeaconUUID = new Guid("6BF6DBA4-6D12-4C42-AE68-5344159683E3"),
                                BeaconMajor = 1,
                                BeaconMinor = 8
                            };

            var feedbackItem = new FeedbackItem
                               {
                                   Id = Guid.NewGuid().ToString(),
                                   Text = "First item",
                                   CreationDate = DateTime.Now,
                                   PlaceId = placeItem.Id
                               };

            context.Set<FeedbackItem>().Add(feedbackItem);


            base.Seed(context);
        }
    }
}
