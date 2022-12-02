using System;
using UnityEngine;

public class UIShowControlScheme : MonoBehaviour
{
	public GameObject target;

	public bool mouse;

	public bool touch;

	public bool controller = true;

	private void OnEnable()
	{
		UICamera.onSchemeChange = (UICamera.OnSchemeChange)Delegate.Combine(UICamera.onSchemeChange, new UICamera.OnSchemeChange(OnScheme));
		OnScheme();
	}

	private void OnDisable()
	{
		UICamera.onSchemeChange = (UICamera.OnSchemeChange)Delegate.Remove(UICamera.onSchemeChange, new UICamera.OnSchemeChange(OnScheme));
	}

	private void OnScheme()
	{
		if (target != null)
		{
			switch (UICamera.currentScheme)
			{
			case UICamera.ControlScheme.Mouse:
				target.SetActive(mouse);
				break;
			case UICamera.ControlScheme.Touch:
				target.SetActive(touch);
				break;
			case UICamera.ControlScheme.Controller:
				target.SetActive(controller);
				break;
			}
		}
	}
}
