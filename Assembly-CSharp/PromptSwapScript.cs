using System;
using UnityEngine;

// Token: 0x020003C8 RID: 968
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B49 RID: 6985 RVA: 0x00131B31 File Offset: 0x0012FD31
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B4A RID: 6986 RVA: 0x00131B4C File Offset: 0x0012FD4C
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

	// Token: 0x04002E9D RID: 11933
	public InputDeviceScript InputDevice;

	// Token: 0x04002E9E RID: 11934
	public UISprite MySprite;

	// Token: 0x04002E9F RID: 11935
	public UILabel MyLetter;

	// Token: 0x04002EA0 RID: 11936
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002EA1 RID: 11937
	public string KeyboardName = string.Empty;

	// Token: 0x04002EA2 RID: 11938
	public string GamepadName = string.Empty;
}
