using AspNetCoreHero.ToastNotification.Toastify.Enums;
using System;

namespace AspNetCoreHero.ToastNotification.Toastify.Models
{
    public class ToastifyEntity
    {
        public ToastifyEntity()
        {

        }
        public string text { get; set; }
        public int duration { get; set; }
        public Uri destination { get; set; }
        public bool newWindow { get; set; }
        public bool close { get; set; }
        public Gravity gravity { get; set; }
        public string backgroundColor { get; set; }
        public bool stopOnFocus { get; set; }
        public Position position { get; set; }
        public Uri avatar { get; set; }
        public string className { get; set; }
       
    }
}
