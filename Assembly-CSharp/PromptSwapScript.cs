using System;
using UnityEngine;

// Token: 0x020003BF RID: 959
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B06 RID: 6918 RVA: 0x0012CF81 File Offset: 0x0012B181
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B07 RID: 6919 RVA: 0x0012CF9C File Offset: 0x0012B19C
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

	// Token: 0x04002DE3 RID: 11747
	public InputDeviceScript InputDevice;

	// Token: 0x04002DE4 RID: 11748
	public UISprite MySprite;

	// Token: 0x04002DE5 RID: 11749
	public UILabel MyLetter;

	// Token: 0x04002DE6 RID: 11750
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002DE7 RID: 11751
	public string KeyboardName = string.Empty;

	// Token: 0x04002DE8 RID: 11752
	public string GamepadName = string.Empty;
}
