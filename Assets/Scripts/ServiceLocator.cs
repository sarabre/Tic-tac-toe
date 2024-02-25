using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator
{
    private static readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

    public static void RegisterService<T>(T service)
    {
        Type serviceType = typeof(T);
        if (!_services.ContainsKey(serviceType))
        {
            _services.Add(serviceType, service);
        }
        else
        {
            Debug.Log("Service of type " + serviceType + " is already registered.");
        }
    }

    public static T GetService<T>()
    {
        Type serviceType = typeof(T);
        if (_services.TryGetValue(serviceType, out var service))
        {
            return (T)service;
        }
        else
        {
            Debug.LogError("Service of type " + serviceType + " not found.");
            return default(T);
        }
    }
}
