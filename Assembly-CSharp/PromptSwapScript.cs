using System;
using UnityEngine;

// Token: 0x020003C7 RID: 967
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B3A RID: 6970 RVA: 0x00130301 File Offset: 0x0012E501
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B3B RID: 6971 RVA: 0x0013031C File Offset: 0x0012E51C
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

	// Token: 0x04002E6C RID: 11884
	public InputDeviceScript InputDevice;

	// Token: 0x04002E6D RID: 11885
	public UISprite MySprite;

	// Token: 0x04002E6E RID: 11886
	public UILabel MyLetter;

	// Token: 0x04002E6F RID: 11887
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002E70 RID: 11888
	public string KeyboardName = string.Empty;

	// Token: 0x04002E71 RID: 11889
	public string GamepadName = string.Empty;
}
