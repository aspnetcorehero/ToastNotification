using AspNetCoreHero.ToastNotification.Notyf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreHero.ToastNotification.Notyf
{
    public class NotyfViewModel
    {
        public string Configuration { get; set; }
        public IEnumerable<NotyfNotification> Notifications { get; set; }
    }
}
