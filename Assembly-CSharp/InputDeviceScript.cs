using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputDeviceScript : MonoBehaviour
{
	public InputDeviceType Type = InputDeviceType.Gamepad;

	public InputManagerScript InputManager;

	public Vector3 MousePrevious;

	public Vector3 MouseDelta;

	public float Horizontal;

	public float Vertical;

	public string[] joystickNames;

	public int PreviousLength;

	public Type LastGamepadType;

	private void Start()
	{
		joystickNames = new string[16];
		joystickNames[0] = "A";
		joystickNames[1] = "B";
		joystickNames[2] = "X";
		joystickNames[3] = "Y";
		joystickNames[4] = "LB";
		joystickNames[5] = "RB";
		joystickNames[6] = "Start";
		joystickNames[7] = "Select";
		joystickNames[8] = "Sony A";
		joystickNames[9] = "Sony B";
		joystickNames[10] = "Sony X";
		joystickNames[11] = "Sony Y";
		joystickNames[12] = "Sony LB";
		joystickNames[13] = "Sony RB";
		joystickNames[14] = "Sony Start";
		joystickNames[15] = "Sony Select";
	}

	private void Update()
	{
		MouseDelta = Input.mousePosition - MousePrevious;
		MousePrevious = Input.mousePosition;
		InputDeviceType type = Type;
		if ((Input.GetJoystickNames().Length == 0 && Input.anyKey) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2) || MouseDelta != Vector3.zero)
		{
			Type = InputDeviceType.MouseAndKeyboard;
		}
		else
		{
			bool flag = false;
			for (int i = 0; i < 16; i++)
			{
				if (Input.GetButtonDown(joystickNames[i]))
				{
					flag = true;
					break;
				}
			}
			bool flag2 = Math.Abs(Input.GetAxis("DpadX")) > 0.5f || Math.Abs(Input.GetAxis("DpadX")) < -0.5f || Math.Abs(Input.GetAxis("DpadY")) > 0.5f || Math.Abs(Input.GetAxis("DpadY")) < -0.5f;
			if (InputManager != null && (InputManager.DPadUp || InputManager.DPadDown))
			{
				flag2 = true;
			}
			bool flag3 = Mathf.Abs(Input.GetAxis("Vertical")) == 1f || Mathf.Abs(Input.GetAxis("Horizontal")) == 1f;
			if (!flag3 && (Mathf.Abs(Input.GetAxis(InputNames.Xbox_JoyX)) == 1f || Mathf.Abs(Input.GetAxis(InputNames.Xbox_JoyY)) == 1f))
			{
				flag3 = true;
			}
			if (flag || flag2 || flag3)
			{
				Type = InputDeviceType.Gamepad;
			}
		}
		bool flag4 = false;
		if (Gamepad.current != null && Gamepad.current.GetType() != LastGamepadType)
		{
			flag4 = true;
			LastGamepadType = Gamepad.current.GetType();
		}
		if (Type != type || flag4)
		{
			UpdateAllButtons();
		}
		Horizontal = Input.GetAxis("Horizontal");
		Vertical = Input.GetAxis("Vertical");
	}

	public void UpdateAllButtons()
	{
		PromptSwapScript[] array = Resources.FindObjectsOfTypeAll<PromptSwapScript>();
		for (int i = 0; i < array.Length; i++)
		{
			array[i].UpdateSpriteType(Type);
		}
	}
}
