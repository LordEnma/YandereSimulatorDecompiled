using System;
using UnityEngine;

public class InputDeviceScript : MonoBehaviour
{
	public InputDeviceType Type = InputDeviceType.Gamepad;

	public Vector3 MousePrevious;

	public Vector3 MouseDelta;

	public float Horizontal;

	public float Vertical;

	public string[] joystickNames;

	public int PreviousLength;

	private void Start()
	{
		joystickNames = new string[20];
		for (int i = 0; i < 20; i++)
		{
			joystickNames[i] = "joystick 1 button " + i;
		}
	}

	private void Update()
	{
		MouseDelta = Input.mousePosition - MousePrevious;
		MousePrevious = Input.mousePosition;
		InputDeviceType type = Type;
		int num = Input.GetJoystickNames().Length;
		if ((num == 0 && Input.anyKey) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2) || MouseDelta != Vector3.zero)
		{
			Type = InputDeviceType.MouseAndKeyboard;
		}
		else
		{
			bool flag = false;
			for (int i = 0; i < 20; i++)
			{
				if (Input.GetKey(joystickNames[i]))
				{
					flag = true;
					break;
				}
			}
			bool flag2 = Math.Abs(Input.GetAxis("DpadX")) > 0.5f || Math.Abs(Input.GetAxis("DpadY")) > 0.5f;
			bool flag3 = Mathf.Abs(Input.GetAxis("Vertical")) == 1f || Mathf.Abs(Input.GetAxis("Horizontal")) == 1f;
			if (flag || flag2 || flag3)
			{
				Type = InputDeviceType.Gamepad;
			}
		}
		if (Type != type)
		{
			PromptSwapScript[] array = Resources.FindObjectsOfTypeAll<PromptSwapScript>();
			for (int j = 0; j < array.Length; j++)
			{
				array[j].UpdateSpriteType(Type);
			}
		}
		Horizontal = Input.GetAxis("Horizontal");
		Vertical = Input.GetAxis("Vertical");
		PreviousLength = num;
	}
}
