using AspNetCoreHero.ToastNotification.Notyf.Models;
using System.Collections.Generic;

namespace AspNetCoreHero.ToastNotification.Notyf
{
    public class NotyfViewModel
    {
        public string Configuration { get; set; }
        public IEnumerable<NotyfNotification> Notifications { get; set; }
    }
}