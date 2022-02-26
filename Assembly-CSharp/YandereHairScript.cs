using System;
using UnityEngine;

// Token: 0x020004C5 RID: 1221
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06001FFA RID: 8186 RVA: 0x001C75C6 File Offset: 0x001C57C6
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06001FFB RID: 8187 RVA: 0x001C7608 File Offset: 0x001C5808
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

	// Token: 0x0400434E RID: 17230
	public YandereScript Yandere;

	// Token: 0x0400434F RID: 17231
	public int Frame;

	// Token: 0x04004350 RID: 17232
	public int Limit;
}
