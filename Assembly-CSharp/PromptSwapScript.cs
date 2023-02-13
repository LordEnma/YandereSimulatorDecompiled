using UnityEngine;

public class PromptSwapScript : MonoBehaviour
{
	public InputDeviceScript InputDevice;

	public UISprite MySprite;

	public UILabel MyLetter;

	public string KeyboardLetter = string.Empty;

	public string KeyboardName = string.Empty;

	public string GamepadName = string.Empty;

	public bool DisableButton;

	private void Awake()
	{
		if (InputDevice == null)
		{
			InputDevice = Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	public void UpdateSpriteType(InputDeviceType deviceType)
	{
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
			MySprite.spriteName = GamepadName;
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
