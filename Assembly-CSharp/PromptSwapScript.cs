using System;
using UnityEngine;

// Token: 0x020003C6 RID: 966
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B34 RID: 6964 RVA: 0x00130155 File Offset: 0x0012E355
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B35 RID: 6965 RVA: 0x00130170 File Offset: 0x0012E370
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

	// Token: 0x04002E69 RID: 11881
	public InputDeviceScript InputDevice;

	// Token: 0x04002E6A RID: 11882
	public UISprite MySprite;

	// Token: 0x04002E6B RID: 11883
	public UILabel MyLetter;

	// Token: 0x04002E6C RID: 11884
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002E6D RID: 11885
	public string KeyboardName = string.Empty;

	// Token: 0x04002E6E RID: 11886
	public string GamepadName = string.Empty;
}
