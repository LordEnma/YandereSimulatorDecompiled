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
		if (Gamepad.current == null)
		{
			return;
		}
		if (Gamepad.current.GetType() != LastGamepadType)
		{
			Debug.Log("We just switched gamepads!");
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
		if (Gamepad.current is DualShockGamepad)
		{
			Debug.Log("Input.GetButton(InputNames.Xbox_A) is: " + Input.GetButton(InputNames.Xbox_A));
			Debug.Log("Input.GetButton(InputNames.Xbox_B) is: " + Input.GetButton(InputNames.Xbox_B));
			Debug.Log("Input.GetButton(InputNames.Xbox_X) is: " + Input.GetButton(InputNames.Xbox_X));
			Debug.Log("Input.GetButton(InputNames.Xbox_Y) is: " + Input.GetButton(InputNames.Xbox_Y));
			Debug.Log("Input.GetButton(InputNames.Xbox_LB) is: " + Input.GetButton(InputNames.Xbox_LB));
			Debug.Log("Input.GetButton(InputNames.Xbox_RB) is: " + Input.GetButton(InputNames.Xbox_RB));
			Debug.Log("Input.GetButton(InputNames.Xbox_Start) is: " + Input.GetButton(InputNames.Xbox_Start));
			Debug.Log("Input.GetButton(InputNames.Xbox_Back) is: " + Input.GetButton(InputNames.Xbox_Back));
			Debug.Log("Input.GetAxis(InputNames.Xbox_LS) is: " + Input.GetAxis(InputNames.Xbox_LS));
			Debug.Log("Input.GetAxis(InputNames.Xbox_RS) is: " + Input.GetAxis(InputNames.Xbox_RS));
			Debug.Log("Input.GetAxis(InputNames.Xbox_LT) is: " + Input.GetAxis(InputNames.Xbox_LT));
			Debug.Log("Input.GetAxis(InputNames.Xbox_RT) is: " + Input.GetAxis(InputNames.Xbox_RT));
			Debug.Log("Input.GetAxis(InputNames.DpadX) is: " + Input.GetAxis(InputNames.Xbox_DpadX));
			Debug.Log("Input.GetAxis(InputNames.DpadY) is: " + Input.GetAxis(InputNames.Xbox_DpadY));
			Debug.Log("Horizontal is: " + Input.GetAxis("Horizontal"));
			Debug.Log("Vertical is: " + Input.GetAxis("Vertical"));
			Debug.Log("''Mouse X'' (Joystick axis 4) is: " + Input.GetAxis("Mouse X"));
			Debug.Log("''Mouse Y''(Joystick axis 5) is: " + Input.GetAxis("Mouse Y"));
		}
	}

	private void UseSonyInputs()
	{
		Debug.Log("This is the frame on which we would switch to Sony input.");
	}

	private void UseXboxInputs()
	{
		Debug.Log("This is the frame on which we would switch to Xbox input.");
		InputNames.Xbox_A = "A";
		InputNames.Xbox_B = "B";
		InputNames.Xbox_X = "X";
		InputNames.Xbox_Y = "Y";
		InputNames.Xbox_LB = "LB";
		InputNames.Xbox_RB = "RB";
		InputNames.Xbox_LT = "LT";
		InputNames.Xbox_RT = "RT";
		InputNames.Xbox_LS = "LS";
		InputNames.Xbox_RS = "RS";
		InputNames.Xbox_Start = "Start";
		InputNames.Xbox_Back = "Back";
	}
}
