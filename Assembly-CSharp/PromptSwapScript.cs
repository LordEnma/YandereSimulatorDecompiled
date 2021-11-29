using System;
using UnityEngine;

// Token: 0x020003BE RID: 958
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001AFC RID: 6908 RVA: 0x0012C3DD File Offset: 0x0012A5DD
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001AFD RID: 6909 RVA: 0x0012C3F8 File Offset: 0x0012A5F8
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

	// Token: 0x04002DB4 RID: 11700
	public InputDeviceScript InputDevice;

	// Token: 0x04002DB5 RID: 11701
	public UISprite MySprite;

	// Token: 0x04002DB6 RID: 11702
	public UILabel MyLetter;

	// Token: 0x04002DB7 RID: 11703
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002DB8 RID: 11704
	public string KeyboardName = string.Empty;

	// Token: 0x04002DB9 RID: 11705
	public string GamepadName = string.Empty;
}
