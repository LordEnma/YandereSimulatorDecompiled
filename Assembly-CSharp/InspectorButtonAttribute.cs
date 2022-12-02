using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
	public static float kDefaultButtonWidth = 150f;

	public readonly string MethodName;

	private float _buttonWidth = kDefaultButtonWidth;

	public float ButtonWidth
	{
		get
		{
			return _buttonWidth;
		}
		set
		{
			_buttonWidth = value;
		}
	}

	public InspectorButtonAttribute(string MethodName)
	{
		this.MethodName = MethodName;
	}
}
