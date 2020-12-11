using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Helpers;
using AspNetCoreHero.ToastNotification.Notyf;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCoreHero.ToastNotification.Middlewares
{
    internal class NotyfMiddleware
        : IMiddleware
    {
        public NotyfEntity _options { get; }
        private readonly INotyfService _toastNotification;
        private readonly ILogger<NotyfMiddleware> _logger;
        private const string AccessControlExposeHeadersKey = "Access-Control-Expose-Headers";
        public NotyfMiddleware(INotyfService toastNotification, ILogger<NotyfMiddleware> logger, NotyfEntity options)
        {
            _toastNotification = toastNotification;
            _logger = logger;
            _options = options;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            context.Response.OnStarting(Callback, context);
            await next(context);
        }

        private Task Callback(object context)
        {
            var httpContext = (HttpContext)context;
            if (httpContext.Request.IsNotyfAjaxRequest())
            {
                var messages = new NotyfViewModel
                {
                    Configuration = _options.ToJson(),
                    Notifications = _toastNotification.ReadAllNotifications()
                };
                if (messages.Notifications != null && messages.Notifications.Any())
                {
                    var accessControlExposeHeaders = $"{GetControlExposeHeaders(httpContext.Response.Headers)}";
                    httpContext.Response.Headers.Add(AccessControlExposeHeadersKey, accessControlExposeHeaders);

                    var notificationsJson = messages.Notifications.ToJson();
                    httpContext.Response.Headers.Add(Constants.NotyfResponseHeaderKey, WebUtility.UrlEncode(notificationsJson));

                }
            }
            return Task.FromResult(0);
        }

        private object GetControlExposeHeaders(IHeaderDictionary headers)
        {
            var existingHeaders = headers[AccessControlExposeHeadersKey];
            if (string.IsNullOrEmpty(existingHeaders))
            {
                return Constants.NotyfResponseHeaderKey;
            }
            else
            {
                return $"{existingHeaders}, {Constants.NotyfResponseHeaderKey}";
            }
        }
    }
}
