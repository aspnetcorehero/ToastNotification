using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Containers;
using AspNetCoreHero.ToastNotification.Middlewares;
using AspNetCoreHero.ToastNotification.Notyf;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using AspNetCoreHero.ToastNotification.Services;
using AspNetCoreHero.ToastNotification.Toastify;
using AspNetCoreHero.ToastNotification.Toastify.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreHero.ToastNotification
{
    public static class ServiceCollectionExtensions
    {
        public static void AddToastify(this IServiceCollection services, Action<ToastifyConfig> toastifyConfiguration)
        {
            var config = new ToastifyConfig();
            toastifyConfiguration(config);
            var toastify = new ToastifyEntity(config.DurationInSeconds,config.Gravity,config.Position);
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddFrameworkServices();
            //Add TempDataWrapper for accessing and adding values to tempdata.
            services.AddSingleton<ITempDataService, TempDataService>();
            services.AddSingleton<IToastNotificationContainer<ToastifyNotification>, TempDataToastNotificationContainer<ToastifyNotification>>();
            //Add the ToastNotification implementation
            services.AddScoped<IToastifyService, ToastifyService>();
            services.AddSingleton(toastify);
           
        }
        private static void AddFrameworkServices(this IServiceCollection services)
        {
            #region Framework Services
            //Check if a TempDataProvider is already registered.
            var tempDataProvider = services.FirstOrDefault(d => d.ServiceType == typeof(ITempDataProvider));
            if (tempDataProvider == null)
            {
                //Add a tempdata provider when one is not already registered
                services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
            }
            //check if IHttpContextAccessor implementation is not registered. Add one if not.
            var httpContextAccessor = services.FirstOrDefault(d => d.ServiceType == typeof(IHttpContextAccessor));
            if (httpContextAccessor == null)
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            }
            #endregion
        }

        public static void AddNotyf(this IServiceCollection services, Action<NotyfConfig> configure)
        {
            var configurationValue = new NotyfConfig();
            configure(configurationValue);
            var options = new NotyfEntity(configurationValue.DurationInSeconds, configurationValue.Position, configurationValue.IsDismissable);
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddFrameworkServices();

            //Add TempDataWrapper for accessing and adding values to tempdata.
            services.AddSingleton<ITempDataService, TempDataService>();
            // Add MessageContainerFactory for creating MessageContainer instance
            services.AddSingleton<IMessageContainerFactory, MessageContainerFactory>();
            //services.AddSingleton<IToastNotificationContainer<NotyfNotification>, TempDataToastNotificationContainer<NotyfNotification>>();
            //services.AddSingleton<IToastNotificationContainer<NotyfNotification>, InMemoryNotificationContainer<NotyfNotification>>();
            //Add the ToastNotification implementation
            services.AddScoped<INotyfService, NotyfService>();
            //Middleware
            services.AddScoped<NotyfMiddleware>();
            services.AddSingleton(options);
            
        }
    }
}
