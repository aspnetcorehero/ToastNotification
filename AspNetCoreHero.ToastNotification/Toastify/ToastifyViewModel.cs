using AspNetCoreHero.ToastNotification.Toastify.Models;
using System.Collections.Generic;

namespace AspNetCoreHero.ToastNotification.Toastify
{
    public class ToastifyViewModel
    {
        public ToastifyEntity Configuration { get; set; }
        public IEnumerable<ToastifyNotification> Notifications { get; set; }
    }
}
