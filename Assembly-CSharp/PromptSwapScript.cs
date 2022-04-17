using System;
using UnityEngine;

// Token: 0x020003C7 RID: 967
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B3E RID: 6974 RVA: 0x00130711 File Offset: 0x0012E911
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B3F RID: 6975 RVA: 0x0013072C File Offset: 0x0012E92C
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

	// Token: 0x04002E77 RID: 11895
	public InputDeviceScript InputDevice;

	// Token: 0x04002E78 RID: 11896
	public UISprite MySprite;

	// Token: 0x04002E79 RID: 11897
	public UILabel MyLetter;

	// Token: 0x04002E7A RID: 11898
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002E7B RID: 11899
	public string KeyboardName = string.Empty;

	// Token: 0x04002E7C RID: 11900
	public string GamepadName = string.Empty;
}
