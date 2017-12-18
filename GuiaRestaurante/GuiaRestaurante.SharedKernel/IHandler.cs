using GuiaRestaurante.SharedKernel.Events.Contracts;
using System;
using System.Collections.Generic;


namespace GuiaRestaurante.SharedKernel
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handler(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
    }
}
