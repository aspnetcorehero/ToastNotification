using AspNetCoreHero.ToastNotification.Toastify.Models;
using System.Collections.Generic;

namespace AspNetCoreHero.ToastNotification.Abstractions
{
    public interface IToastifyService : IToastNotificationService
    {
        void Success(string message, int? durationInSeconds = null);
        void Error(string message, int? durationInSeconds = null);
        void Information(string message, int? durationInSeconds = null);
        void Warning(string message, int? durationInSeconds = null);
        void Custom(string message, int? durationInSeconds = null, string backgroundColor = "linear-gradient(to right, #00b09b, #96c93d)");
        IEnumerable<ToastifyNotification> GetNotifications();
        IEnumerable<ToastifyNotification> ReadAllNotifications();
        void RemoveAll();
    }
}
