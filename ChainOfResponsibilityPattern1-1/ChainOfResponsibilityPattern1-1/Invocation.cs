using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public abstract class Invocation<TService> : IInvocation where TService : class
{
    private readonly IList<IInvocation> _invocations;

    private readonly MethodInfo[] _methods;

    public Invocation(IList<IInvocation> invocations)
    {
        _invocations = invocations;

        Type serviceType = typeof(TService);

        _methods = serviceType.GetMethods();
    }

    public virtual void Intercept(string method, object[] args, Action proceed)
    {
        MethodInfo mi = _methods.FirstOrDefault(f => f.Name == method);

        Intercept(0, mi, args, () => { proceed(); return null; });
    }

    public virtual TResult Intercept<TResult>(string method, object[] args, Func<TResult> proceed)
    {
        MethodInfo mi = _methods.FirstOrDefault(f => f.Name == method);

        return (TResult)Intercept(0, mi, args, () => proceed());
    }

    public object Intercept(MethodInfo method, object[] args, Func<object> proceed)
    {
        return Intercept(0, method, args, proceed);
    }

    private object Intercept(int i, MethodInfo method, object[] args, Func<object> proceed)
    {
        IInvocation invocation = _invocations.ElementAtOrDefault(i);

        if (invocation == null)
        {
            return proceed();
        }

        return invocation.Intercept(method, args, () => Intercept(++i, method, args, proceed));
    }
}