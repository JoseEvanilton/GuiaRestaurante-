using GuiaRestaurante.SharedKernel;
using GuiaRestaurantes.SharedKernel.Events;
using System.Collections.Generic;

namespace GuiaRestaurante.CrossCutting
{
    public class DomainNotificationHandler : IHandler<DomainNotification>
    {

        private List<DomainNotification> _notifications;

        public DomainNotificationHandler()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Handler(DomainNotification args)
        {
            _notifications.Add(args);
        }

        public IEnumerable<DomainNotification> Notify()
        {
            return GetValue();
        }

        private List<DomainNotification> GetValue()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return GetValue().Count > 0;
        }

        public void Dispose()
        {
            this._notifications = new List<DomainNotification>();
        }
    }
}
