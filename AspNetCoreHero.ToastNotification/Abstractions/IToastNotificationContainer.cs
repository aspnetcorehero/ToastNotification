using System.Collections.Generic;

namespace AspNetCoreHero.ToastNotification.Abstractions
{
    public interface IToastNotificationContainer<TNotification>
    {
        void Add(TNotification notification);
        void RemoveAll();
        IList<TNotification> GetAll();
        IList<TNotification> ReadAll();
    }
}
