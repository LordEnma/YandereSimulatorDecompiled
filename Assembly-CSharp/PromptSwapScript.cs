using System;
using UnityEngine;

// Token: 0x020003C1 RID: 961
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B0D RID: 6925 RVA: 0x0012D359 File Offset: 0x0012B559
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B0E RID: 6926 RVA: 0x0012D374 File Offset: 0x0012B574
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

	// Token: 0x04002DE9 RID: 11753
	public InputDeviceScript InputDevice;

	// Token: 0x04002DEA RID: 11754
	public UISprite MySprite;

	// Token: 0x04002DEB RID: 11755
	public UILabel MyLetter;

	// Token: 0x04002DEC RID: 11756
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002DED RID: 11757
	public string KeyboardName = string.Empty;

	// Token: 0x04002DEE RID: 11758
	public string GamepadName = string.Empty;
}
