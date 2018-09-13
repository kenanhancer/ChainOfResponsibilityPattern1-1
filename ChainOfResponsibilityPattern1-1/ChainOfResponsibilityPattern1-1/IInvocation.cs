using System;
using System.Reflection;

public interface IInvocation
{
    object Intercept(MethodInfo method, object[] args, Func<object> proceed);
}