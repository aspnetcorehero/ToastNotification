using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Helpers;
using AspNetCoreHero.ToastNotification.Notyf;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreHero.ToastNotification.Views.Shared.Components.Notyf
{
    [ViewComponent(Name = "Notyf")]
    public class NotyfViewComponent : ViewComponent
    {
        private readonly INotyfService _service;

        public NotyfViewComponent(INotyfService service, NotyfEntity options)
        {
            _service = service;
            _options = options;
        }

        public NotyfEntity _options { get; }

        public IViewComponentResult Invoke()
        {
            var model = new NotyfViewModel
            {
                Configuration = _options.ToJson(),
                Notifications = _service.ReadAllNotifications()
            };
            return View("Default", model);
        }
    }
}
