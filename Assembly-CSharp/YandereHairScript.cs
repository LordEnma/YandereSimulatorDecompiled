using System;
using UnityEngine;

// Token: 0x020004C6 RID: 1222
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06002000 RID: 8192 RVA: 0x001C7EE6 File Offset: 0x001C60E6
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06002001 RID: 8193 RVA: 0x001C7F28 File Offset: 0x001C6128
	private void Update()
	{
		if (this.Yandere.Hairstyle < this.Limit)
		{
			this.Frame++;
			if (this.Frame == 1)
			{
				this.Yandere.Hairstyle++;
				this.Yandere.UpdateHair();
			}
			if (this.Frame == 2)
			{
				ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
				this.Frame = 0;
			}
		}
	}

	// Token: 0x0400436B RID: 17259
	public YandereScript Yandere;

	// Token: 0x0400436C RID: 17260
	public int Frame;

	// Token: 0x0400436D RID: 17261
	public int Limit;
}
