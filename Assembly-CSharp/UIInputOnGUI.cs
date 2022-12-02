using System;
using UnityEngine;

[RequireComponent(typeof(UIInput))]
public class UIInputOnGUI : MonoBehaviour
{
	[NonSerialized]
	private UIInput mInput;

	private void Awake()
	{
		mInput = GetComponent<UIInput>();
	}

	private void OnGUI()
	{
		if (Event.current.rawType == EventType.KeyDown)
		{
			mInput.ProcessEvent(Event.current);
		}
	}
}
