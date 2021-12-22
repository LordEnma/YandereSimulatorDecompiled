using System;
using UnityEngine;

// Token: 0x020003BF RID: 959
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B04 RID: 6916 RVA: 0x0012CC31 File Offset: 0x0012AE31
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B05 RID: 6917 RVA: 0x0012CC4C File Offset: 0x0012AE4C
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

	// Token: 0x04002DDE RID: 11742
	public InputDeviceScript InputDevice;

	// Token: 0x04002DDF RID: 11743
	public UISprite MySprite;

	// Token: 0x04002DE0 RID: 11744
	public UILabel MyLetter;

	// Token: 0x04002DE1 RID: 11745
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002DE2 RID: 11746
	public string KeyboardName = string.Empty;

	// Token: 0x04002DE3 RID: 11747
	public string GamepadName = string.Empty;
}
