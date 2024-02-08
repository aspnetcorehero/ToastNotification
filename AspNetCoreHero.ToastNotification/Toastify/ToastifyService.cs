using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Enums;
using AspNetCoreHero.ToastNotification.Toastify.Models;
using System.Collections.Generic;

namespace AspNetCoreHero.ToastNotification.Toastify
{
    public class ToastifyService : IToastifyService
    {
        private readonly IToastNotificationContainer<ToastifyNotification> _container;
        public ToastifyService(IToastNotificationContainer<ToastifyNotification> container)
        {
            _container = container;
        }
        public void Custom(string message, int? durationInSeconds = null, string backgroundColor = "linear-gradient(to right, #00b09b, #96c93d)")
        {
            var toastMessage = new ToastifyNotification(ToastNotificationType.Custom, message, durationInSeconds);
            toastMessage.BackgroundColor = backgroundColor;
            _container.Add(toastMessage);
        }

        public void Error(string message, int? durationInSeconds = null)
        {
            var toastMessage = new ToastifyNotification(ToastNotificationType.Error, message, durationInSeconds);
            _container.Add(toastMessage);
        }


        public IEnumerable<ToastifyNotification> GetNotifications()
        {
            return _container.GetAll();
        }

        public void Information(string message, int? durationInSeconds = null)
        {
            var toastMessage = new ToastifyNotification(ToastNotificationType.Information, message, durationInSeconds);
            _container.Add(toastMessage);
        }

        public IEnumerable<ToastifyNotification> ReadAllNotifications()
        {
            return _container.ReadAll();
        }

        public void RemoveAll()
        {
            _container.RemoveAll();
        }

        public void Success(string message, int? durationInSeconds = null)
        {
            var toastMessage = new ToastifyNotification(ToastNotificationType.Success, message, durationInSeconds);
            _container.Add(toastMessage);
        }

        public void Warning(string message, int? durationInSeconds = null)
        {
            var toastMessage = new ToastifyNotification(ToastNotificationType.Warning, message, durationInSeconds);
            _container.Add(toastMessage);
        }
    }
}
