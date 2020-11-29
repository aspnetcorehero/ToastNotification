using AspNetCoreHero.ToastNotification.Abstractions;
using AspNetCoreHero.ToastNotification.Enums;
using AspNetCoreHero.ToastNotification.Notyf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCoreHero.ToastNotification.Notyf
{
    public class NotyfService : INotyfService
    {
        private readonly IToastNotificationContainer<NotyfNotification> _container;
        public NotyfService(IToastNotificationContainer<NotyfNotification> container)
        {
            _container = container;
        }
        public void Custom(string message, int? durationInSeconds = null, string backgroundColor = "black", string iconClassName = "home")
        {
            var toastMessage = new NotyfNotification(ToastNotificationType.Custom, message, durationInSeconds);
            toastMessage.Icon = iconClassName;
            toastMessage.BackgroundColor = backgroundColor;
            _container.Add(toastMessage);
        }

        public void Error(string message, int? durationInSeconds = null)
        {
            var toastMessage = new NotyfNotification(ToastNotificationType.Error, message, durationInSeconds);
            _container.Add(toastMessage);
        }

        public IEnumerable<NotyfNotification> GetNotifications()
        {
            return _container.GetAll();
        }

        public void Information(string message, int? durationInSeconds = null)
        {
            var toastMessage = new NotyfNotification(ToastNotificationType.Information, message, durationInSeconds);
            _container.Add(toastMessage);
        }

        public IEnumerable<NotyfNotification> ReadAllNotifications()
        {
            return _container.ReadAll();
        }

        public void RemoveAll()
        {
            _container.RemoveAll();
        }

        public void Success(string message, int? durationInSeconds = null)
        {
            var toastMessage = new NotyfNotification(ToastNotificationType.Success, message, durationInSeconds);
            _container.Add(toastMessage);
        }

        public void Warning(string message, int? durationInSeconds = null)
        {
            var toastMessage = new NotyfNotification(ToastNotificationType.Warning, message, durationInSeconds);
            _container.Add(toastMessage);
        }
    }
}
