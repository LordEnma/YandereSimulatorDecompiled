using System;
using UnityEngine;

// Token: 0x020003C3 RID: 963
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B20 RID: 6944 RVA: 0x0012E93D File Offset: 0x0012CB3D
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B21 RID: 6945 RVA: 0x0012E958 File Offset: 0x0012CB58
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

	// Token: 0x04002E0D RID: 11789
	public InputDeviceScript InputDevice;

	// Token: 0x04002E0E RID: 11790
	public UISprite MySprite;

	// Token: 0x04002E0F RID: 11791
	public UILabel MyLetter;

	// Token: 0x04002E10 RID: 11792
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002E11 RID: 11793
	public string KeyboardName = string.Empty;

	// Token: 0x04002E12 RID: 11794
	public string GamepadName = string.Empty;
}
