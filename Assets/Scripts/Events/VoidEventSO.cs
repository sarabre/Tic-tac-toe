using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "voidEvent", menuName = "Event/void")]

public class VoidEventSO : ScriptableObject
{
	public Action OnEventRaised;

	public void RaiseEvent()
	{
		OnEventRaised?.Invoke();
	}
}
