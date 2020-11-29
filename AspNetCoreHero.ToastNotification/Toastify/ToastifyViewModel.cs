using AspNetCoreHero.ToastNotification.Toastify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreHero.ToastNotification.Toastify
{
    public class ToastifyViewModel
    {
        public ToastifyEntity Configuration { get; set; }
        public IEnumerable<ToastifyNotification> Notifications { get; set; }
    }
}
