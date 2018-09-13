using System;
using System.Reflection;

public class ServiceLogAspect : IInvocation
{
    public object Intercept(MethodInfo method, object[] args, Func<object> proceed)
    {
        Console.WriteLine($"ServiceLogAspect: {method} method with ({String.Join(',', args)}) values begins at {DateTime.Now}");

        object result = proceed.Invoke();

        Console.WriteLine($"ServiceLogAspect: {method} method ends at {DateTime.Now}");

        return result;
    }
}