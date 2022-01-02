using System;
using UnityEngine;

// Token: 0x020004C0 RID: 1216
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06001FD5 RID: 8149 RVA: 0x001C452E File Offset: 0x001C272E
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06001FD6 RID: 8150 RVA: 0x001C4570 File Offset: 0x001C2770
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

	// Token: 0x04004308 RID: 17160
	public YandereScript Yandere;

	// Token: 0x04004309 RID: 17161
	public int Frame;

	// Token: 0x0400430A RID: 17162
	public int Limit;
}
