using System;
using UnityEngine;

// Token: 0x020003C1 RID: 961
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B0D RID: 6925 RVA: 0x0012D4DD File Offset: 0x0012B6DD
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B0E RID: 6926 RVA: 0x0012D4F8 File Offset: 0x0012B6F8
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

	// Token: 0x04002DED RID: 11757
	public InputDeviceScript InputDevice;

	// Token: 0x04002DEE RID: 11758
	public UISprite MySprite;

	// Token: 0x04002DEF RID: 11759
	public UILabel MyLetter;

	// Token: 0x04002DF0 RID: 11760
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002DF1 RID: 11761
	public string KeyboardName = string.Empty;

	// Token: 0x04002DF2 RID: 11762
	public string GamepadName = string.Empty;
}
