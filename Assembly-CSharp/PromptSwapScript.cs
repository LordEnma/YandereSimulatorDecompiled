using System;
using UnityEngine;

// Token: 0x020003C2 RID: 962
public class PromptSwapScript : MonoBehaviour
{
	// Token: 0x06001B17 RID: 6935 RVA: 0x0012DEFD File Offset: 0x0012C0FD
	private void Awake()
	{
		if (this.InputDevice == null)
		{
			this.InputDevice = UnityEngine.Object.FindObjectOfType<InputDeviceScript>();
		}
	}

	// Token: 0x06001B18 RID: 6936 RVA: 0x0012DF18 File Offset: 0x0012C118
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

	// Token: 0x04002DFD RID: 11773
	public InputDeviceScript InputDevice;

	// Token: 0x04002DFE RID: 11774
	public UISprite MySprite;

	// Token: 0x04002DFF RID: 11775
	public UILabel MyLetter;

	// Token: 0x04002E00 RID: 11776
	public string KeyboardLetter = string.Empty;

	// Token: 0x04002E01 RID: 11777
	public string KeyboardName = string.Empty;

	// Token: 0x04002E02 RID: 11778
	public string GamepadName = string.Empty;
}
