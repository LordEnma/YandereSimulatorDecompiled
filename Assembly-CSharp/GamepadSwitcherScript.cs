using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class GamepadSwitcherScript : MonoBehaviour
{
	private static GamepadSwitcherScript instance;

	public Type LastGamepadType;

	private void Start()
	{
		if (instance != null)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		instance = this;
	}

	private void Update()
	{
		if (Gamepad.current != null && Gamepad.current.GetType() != LastGamepadType)
		{
			if (Gamepad.current is DualShockGamepad)
			{
				UseSonyInputs();
			}
			else
			{
				UseXboxInputs();
			}
			LastGamepadType = Gamepad.current.GetType();
		}
	}

	private void UseSonyInputs()
	{
		InputNames.Xbox_JoyX = "Sony Joystick X";
		InputNames.Xbox_JoyY = "Sony Joystick Y";
		InputNames.Xbox_A = "Sony A";
		InputNames.Xbox_B = "Sony B";
		InputNames.Xbox_X = "Sony X";
		InputNames.Xbox_Y = "Sony Y";
		InputNames.Xbox_LB = "Sony LB";
		InputNames.Xbox_RB = "Sony RB";
		InputNames.Xbox_Start = "Sony Start";
		InputNames.Xbox_Back = "Sony Select";
		InputNames.Xbox_LS = "Sony LS";
		InputNames.Xbox_RS = "Sony RS";
		InputNames.Xbox_LT = "Sony LT";
		InputNames.Xbox_RT = "Sony RT";
		InputNames.Xbox_DpadX = "Sony DpadX";
		InputNames.Xbox_DpadY = "Sony DpadY";
	}

	private void UseXboxInputs()
	{
		InputNames.Xbox_JoyX = "Joystick X";
		InputNames.Xbox_JoyY = "Joystick Y";
		InputNames.Xbox_A = "A";
		InputNames.Xbox_B = "B";
		InputNames.Xbox_X = "X";
		InputNames.Xbox_Y = "Y";
		InputNames.Xbox_LB = "LB";
		InputNames.Xbox_RB = "RB";
		InputNames.Xbox_Start = "Start";
		InputNames.Xbox_Back = "Select";
		InputNames.Xbox_LS = "LS";
		InputNames.Xbox_RS = "RS";
		InputNames.Xbox_LT = "LT";
		InputNames.Xbox_RT = "RT";
		InputNames.Xbox_DpadX = "DpadX";
		InputNames.Xbox_DpadY = "DpadY";
	}
}
