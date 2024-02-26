using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CellEvent", menuName = "Event/cell")]

public class CellEventSO : ScriptableObject
{
    public Action<Cell> OnEventRaised;

    public void RaiseEvent(Cell cell)
    {
        OnEventRaised?.Invoke(cell);
    }
}

