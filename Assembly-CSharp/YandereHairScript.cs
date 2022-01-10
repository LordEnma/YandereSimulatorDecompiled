using System;
using UnityEngine;

// Token: 0x020004C2 RID: 1218
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06001FE0 RID: 8160 RVA: 0x001C4EAE File Offset: 0x001C30AE
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06001FE1 RID: 8161 RVA: 0x001C4EF0 File Offset: 0x001C30F0
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

	// Token: 0x0400431C RID: 17180
	public YandereScript Yandere;

	// Token: 0x0400431D RID: 17181
	public int Frame;

	// Token: 0x0400431E RID: 17182
	public int Limit;
}
