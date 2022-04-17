using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06002031 RID: 8241 RVA: 0x001CC2B6 File Offset: 0x001CA4B6
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06002032 RID: 8242 RVA: 0x001CC2F8 File Offset: 0x001CA4F8
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

	// Token: 0x0400440B RID: 17419
	public YandereScript Yandere;

	// Token: 0x0400440C RID: 17420
	public int Frame;

	// Token: 0x0400440D RID: 17421
	public int Limit;
}
