using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;

public class PromptSwapScript : MonoBehaviour
{
	public InputDeviceScript InputDevice;

	public UISprite MySprite;

	public UILabel MyLetter;

	public string KeyboardLetter = string.Empty;

	public string KeyboardName = string.Empty;

	public string GamepadName = string.Empty;

	public string SonyName = string.Empty;

	public bool DisableButton;

	private void Awake()
	{
		if (SonyName == string.Empty)
		{
			if (GamepadName == "A")
			{
				SonyName = "CrossButton";
			}
			else if (GamepadName == "B")
			{
				SonyName = "CircleButton";
			}
			else if (GamepadName == "X")
			{
				SonyName = "SquareButton";
			}
			else if (GamepadName == "Y")
			{
				SonyName = "TriangleButton";
			}
		}
		if (InputDevice == null)
		{
			InputDevice = Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	public void UpdateSpriteType(InputDeviceType deviceType)
	{
		bool flag = false;
		string[] joystickNames = Input.GetJoystickNames();
		if (joystickNames.Length != 0)
		{
			for (int i = 0; i < joystickNames.Length; i++)
			{
				if (!joystickNames[i].ToLower().Contains("xbox") && (joystickNames[i].ToLower().Contains("dual") || joystickNames[i].ToLower().Contains("less")))
				{
					flag = true;
				}
			}
		}
		if (DisableButton)
		{
			MySprite.spriteName = "BlackCircle";
			if (MyLetter != null)
			{
				MyLetter.text = "";
			}
			return;
		}
		if (InputDevice == null)
		{
			InputDevice = Object.FindObjectOfType<InputDeviceScript>();
		}
		if (deviceType == InputDeviceType.Gamepad)
		{
			if ((Gamepad.current is DualShockGamepad && SonyName != "") || (flag && SonyName != ""))
			{
				MySprite.spriteName = SonyName;
			}
			else
			{
				MySprite.spriteName = GamepadName;
			}
			if (MyLetter != null)
			{
				MyLetter.text = "";
			}
		}
		else
		{
			MySprite.spriteName = KeyboardName;
			if (MyLetter != null)
			{
				MyLetter.text = KeyboardLetter;
			}
		}
	}
}
