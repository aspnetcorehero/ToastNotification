using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Toastify;
using AspNetCoreHero.ToastNotification.Toastify.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreHero.ToastNotification.Views.Shared.Components.Toastify
{
    [ViewComponent(Name = "Toastify")]
    public class ToastifyViewComponent : ViewComponent
    {
        private readonly IToastifyService _service;

        public ToastifyViewComponent(IToastifyService service, ToastifyEntity options)
        {
            this._service = service;
            _options = options;
        }

        public ToastifyEntity _options { get; }

        public IViewComponentResult Invoke()
        {
            var model = new ToastifyViewModel
            {
                Configuration = _options,
                Notifications = _service.ReadAllNotifications()
            };
            return View("Default", model);
        }
    }
}
