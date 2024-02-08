using AspNetCoreHero.ToastNotification.Enums;

namespace AspNetCoreHero.ToastNotification.Abstractions
{
    public class Notification
    {
        public Notification(ToastNotificationType type, string message, int? durationInSeconds)
        {
            Message = message;
            Type = type;
            Duration = durationInSeconds == null || durationInSeconds == 0 ? null : durationInSeconds * 1000;
        }
        public string Message { get; set; }
        public string BackgroundColor { get; set; }
        public ToastNotificationType Type { get; set; }
        public int? Duration { get; set; }
    }
}
