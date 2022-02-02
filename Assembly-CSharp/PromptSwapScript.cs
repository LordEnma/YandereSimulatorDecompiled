using System;
using UnityEngine;

// Token: 0x020003C1 RID: 961
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B0E RID: 6926 RVA: 0x0012D959 File Offset: 0x0012BB59
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B0F RID: 6927 RVA: 0x0012D974 File Offset: 0x0012BB74
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

	// Token: 0x04002DF3 RID: 11763
	public InputDeviceScript InputDevice;

	// Token: 0x04002DF4 RID: 11764
	public UISprite MySprite;

	// Token: 0x04002DF5 RID: 11765
	public UILabel MyLetter;

	// Token: 0x04002DF6 RID: 11766
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002DF7 RID: 11767
	public string KeyboardName = string.Empty;

	// Token: 0x04002DF8 RID: 11768
	public string GamepadName = string.Empty;
}
