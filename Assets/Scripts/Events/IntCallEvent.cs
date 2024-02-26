using System;
using UnityEngine;

[CreateAssetMenu(fileName = "IntEvent", menuName = "Event/int")]

public class IntCallEvent : ScriptableObject
{
    public Action<int> OnEventRaised;

    public void RaiseEvent(int value)
    {
        OnEventRaised?.Invoke(value);
    }
}
