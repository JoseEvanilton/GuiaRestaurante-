﻿using GuiaRestaurante.SharedKernel.Events.Contracts;


namespace GuiaRestaurante.SharedKernel.Events
{
    public static class DomainEvent
    {
        public static IContainer Container { get; set; }
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            try
            {
                if (Container != null)
                {
                    var obj = Container.GetService(typeof(IHandler<T>));
                    ((IHandler<T>)obj).Handler(args);
                }
            }
            catch
            {
                //throw;
            }
        }
    }
}
