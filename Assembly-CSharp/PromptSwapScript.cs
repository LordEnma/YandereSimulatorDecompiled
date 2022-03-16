using System;
using UnityEngine;

// Token: 0x020003C3 RID: 963
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B2B RID: 6955 RVA: 0x0012F9C5 File Offset: 0x0012DBC5
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B2C RID: 6956 RVA: 0x0012F9E0 File Offset: 0x0012DBE0
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

	// Token: 0x04002E50 RID: 11856
	public InputDeviceScript InputDevice;

	// Token: 0x04002E51 RID: 11857
	public UISprite MySprite;

	// Token: 0x04002E52 RID: 11858
	public UILabel MyLetter;

	// Token: 0x04002E53 RID: 11859
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002E54 RID: 11860
	public string KeyboardName = string.Empty;

	// Token: 0x04002E55 RID: 11861
	public string GamepadName = string.Empty;
}
