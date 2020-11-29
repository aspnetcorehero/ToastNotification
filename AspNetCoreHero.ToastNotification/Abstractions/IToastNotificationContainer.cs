using System.Collections.Generic;

namespace AspNetCoreHero.ToastNotification.Abstractions
{
    public interface IToastNotificationContainer<TMessage> where TMessage : class
    {
        void Add(TMessage message);
        void RemoveAll();
        IList<TMessage> GetAll();
        IList<TMessage> ReadAll();
    }
}
