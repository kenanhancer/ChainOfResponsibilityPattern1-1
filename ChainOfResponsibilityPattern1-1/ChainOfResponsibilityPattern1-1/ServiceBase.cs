using System.Collections.Generic;

public abstract class ServiceBase<TService> : Invocation<TService> where TService : class
{
    public ServiceBase(IList<IInvocation> aspects) : base(aspects)
    {
    }
}