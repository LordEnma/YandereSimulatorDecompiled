using System;
using UnityEngine;

// Token: 0x020003C3 RID: 963
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B21 RID: 6945 RVA: 0x0012ED15 File Offset: 0x0012CF15
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B22 RID: 6946 RVA: 0x0012ED30 File Offset: 0x0012CF30
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

	// Token: 0x04002E23 RID: 11811
	public InputDeviceScript InputDevice;

	// Token: 0x04002E24 RID: 11812
	public UISprite MySprite;

	// Token: 0x04002E25 RID: 11813
	public UILabel MyLetter;

	// Token: 0x04002E26 RID: 11814
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002E27 RID: 11815
	public string KeyboardName = string.Empty;

	// Token: 0x04002E28 RID: 11816
	public string GamepadName = string.Empty;
}
