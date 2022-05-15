using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B48 RID: 6984 RVA: 0x001318B5 File Offset: 0x0012FAB5
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B49 RID: 6985 RVA: 0x001318D0 File Offset: 0x0012FAD0
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

	// Token: 0x04002E95 RID: 11925
	public InputDeviceScript InputDevice;

	// Token: 0x04002E96 RID: 11926
	public UISprite MySprite;

	// Token: 0x04002E97 RID: 11927
	public UILabel MyLetter;

	// Token: 0x04002E98 RID: 11928
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002E99 RID: 11929
	public string KeyboardName = string.Empty;

	// Token: 0x04002E9A RID: 11930
	public string GamepadName = string.Empty;
}
