using System;
using System.Collections.Generic;
using UnityEngine;

public class PopupDictionary
{
    private Dictionary<Type, UIPopup> _popups = new Dictionary<Type, UIPopup>();

    public void RegisterPopup<T>(T popup) where T : UIPopup
    {
        Type popupType = typeof(T);
        if (!_popups.ContainsKey(popupType))
        {
            _popups.Add(popupType, popup);
        }
        else
        {
            Debug.LogWarning("Service of type " + popupType + " is already registered.");
        }
    }

    public T GetPopup<T>() where T : UIPopup
    {
        Type popupType = typeof(T);
        if (_popups.TryGetValue(popupType, out var popup))
        {
            return (T)popup;
        }
        else
        {
            Debug.LogError("Service of type " + popupType + " not found.");
            return default(T);
        }
    }

}
