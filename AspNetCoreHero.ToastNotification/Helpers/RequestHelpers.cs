using System;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreHero.ToastNotification.Helpers
{ 
    public static class RequestHelpers
    {
        public static bool IsNotyfAjaxRequest(this HttpRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!string.IsNullOrWhiteSpace(request.Headers[Constants.RequestHeaderKey]))
            {
                return true;
            };
            if (!string.IsNullOrWhiteSpace(request.Headers[Constants.RequestHeaderKey.ToLower()]))
            {
                return true;
            }

            return false;
        }
    }
}
