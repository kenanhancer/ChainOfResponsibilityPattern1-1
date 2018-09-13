using System;
using System.Diagnostics;
using System.Reflection;

public class ServiceTimingAspect : IInvocation
{
    public object Intercept(MethodInfo method, object[] args, Func<object> proceed)
    {
        Console.WriteLine($"ServiceTimingAspect: {method} method begins at {DateTime.Now}");

        object result = null;

        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();

        result = proceed.Invoke();

        stopwatch.Stop();

        Console.WriteLine($"ServiceTimingAspect: {method} method ends at {DateTime.Now}. Time elapsed is {stopwatch.Elapsed}");

        return result;
    }
}