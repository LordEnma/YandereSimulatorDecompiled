using System;
using UnityEngine;

// Token: 0x020003C1 RID: 961
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B10 RID: 6928 RVA: 0x0012DBF5 File Offset: 0x0012BDF5
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B11 RID: 6929 RVA: 0x0012DC10 File Offset: 0x0012BE10
	public void UpdateSpriteType(InputDeviceType deviceType)
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
		if (deviceType == InputDeviceType.Gamepad)
		{
			this.MySprite.spriteName = this.GamepadName;
			if (this.MyLetter != null)
			{
				this.MyLetter.text = "";
				return;
			}
		}
		else
		{
			this.MySprite.spriteName = this.KeyboardName;
			if (this.MyLetter != null)
			{
				this.MyLetter.text = this.KeyboardLetter;
			}
		}
	}

	// Token: 0x04002DF7 RID: 11767
	public InputDeviceScript InputDevice;

	// Token: 0x04002DF8 RID: 11768
	public UISprite MySprite;

	// Token: 0x04002DF9 RID: 11769
	public UILabel MyLetter;

	// Token: 0x04002DFA RID: 11770
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002DFB RID: 11771
	public string KeyboardName = string.Empty;

	// Token: 0x04002DFC RID: 11772
	public string GamepadName = string.Empty;
}
