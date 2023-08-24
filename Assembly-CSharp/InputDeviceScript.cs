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
		joystickNames = new string[20];
		joystickNames[0] = "A";
		joystickNames[1] = "B";
		joystickNames[2] = "X";
		joystickNames[3] = "Y";
		joystickNames[4] = "LB";
		joystickNames[5] = "RB";
		joystickNames[6] = "LS";
		joystickNames[7] = "RS";
		joystickNames[8] = "Start";
		joystickNames[9] = "Select";
		joystickNames[10] = "Sony A";
		joystickNames[11] = "Sony B";
		joystickNames[12] = "Sony X";
		joystickNames[13] = "Sony Y";
		joystickNames[14] = "Sony LB";
		joystickNames[15] = "Sony RB";
		joystickNames[16] = "Sony LS";
		joystickNames[17] = "Sony RS";
		joystickNames[18] = "Sony Start";
		joystickNames[19] = "Sony Select";
	}

	private void Update()
	{
		MouseDelta = Input.mousePosition - MousePrevious;
		MousePrevious = Input.mousePosition;
		InputDeviceType type = Type;
		if ((Input.GetJoystickNames().Length == 0 && Input.anyKey) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.F) || Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.T) || Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4) || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2) || MouseDelta != Vector3.zero)
		{
			Type = InputDeviceType.MouseAndKeyboard;
		}
		else
		{
			bool flag = false;
			for (int i = 0; i < 20; i++)
			{
				if (Input.GetButtonDown(joystickNames[i]))
				{
					flag = true;
					break;
				}
			}
			bool flag2 = Math.Abs(Input.GetAxis(InputNames.Xbox_DpadX)) > 0.5f || Math.Abs(Input.GetAxis(InputNames.Xbox_DpadX)) < -0.5f || Math.Abs(Input.GetAxis(InputNames.Xbox_DpadY)) > 0.5f || Math.Abs(Input.GetAxis(InputNames.Xbox_DpadY)) < -0.5f;
			if (InputManager != null && (InputManager.DPadUp || InputManager.DPadDown || InputManager.DPadLeft || InputManager.DPadRight))
			{
				flag2 = true;
			}
			bool flag3 = Mathf.Abs(Input.GetAxis("Vertical")) == 1f || Mathf.Abs(Input.GetAxis("Horizontal")) == 1f;
			if (!flag3 && (Mathf.Abs(Input.GetAxis(InputNames.Xbox_JoyX)) == 1f || Mathf.Abs(Input.GetAxis(InputNames.Xbox_JoyY)) == 1f))
			{
				flag3 = true;
			}
			bool flag4 = Math.Abs(Input.GetAxis("LT")) > 0.5f || Math.Abs(Input.GetAxis("RT")) > 0.5f;
			if (flag || flag2 || flag3 || flag4)
			{
				Type = InputDeviceType.Gamepad;
			}
		}
		bool flag5 = false;
		if (Gamepad.current != null && Gamepad.current.GetType() != LastGamepadType)
		{
			flag5 = true;
			LastGamepadType = Gamepad.current.GetType();
		}
		if (Type != type || flag5)
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
