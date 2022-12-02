using System;
using UnityEngine;

[RequireComponent(typeof(UIWidget))]
public class SetColorPickerColor : MonoBehaviour
{
	[NonSerialized]
	private UIWidget mWidget;

	public void SetToCurrent()
	{
		if (mWidget == null)
		{
			mWidget = GetComponent<UIWidget>();
		}
		if (UIColorPicker.current != null)
		{
			mWidget.color = UIColorPicker.current.value;
		}
	}
}
