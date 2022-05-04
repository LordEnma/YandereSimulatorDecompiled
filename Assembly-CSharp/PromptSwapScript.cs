using System;
using UnityEngine;

// Token: 0x020003C7 RID: 967
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B42 RID: 6978 RVA: 0x00130CF1 File Offset: 0x0012EEF1
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B43 RID: 6979 RVA: 0x00130D0C File Offset: 0x0012EF0C
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

	// Token: 0x04002E80 RID: 11904
	public InputDeviceScript InputDevice;

	// Token: 0x04002E81 RID: 11905
	public UISprite MySprite;

	// Token: 0x04002E82 RID: 11906
	public UILabel MyLetter;

	// Token: 0x04002E83 RID: 11907
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002E84 RID: 11908
	public string KeyboardName = string.Empty;

	// Token: 0x04002E85 RID: 11909
	public string GamepadName = string.Empty;
}
