using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class UIPopup : MonoBehaviour, IPopup
{
    public Action OnActive;

    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponentInParent<Canvas>(true);
        Register();
    }


    public virtual void Open()
    {
        _canvas.enabled = true;
        OnActive?.Invoke();
    }

    public virtual void Close()
    {
        _canvas.enabled = false;
    }

    public abstract void Register();

}
