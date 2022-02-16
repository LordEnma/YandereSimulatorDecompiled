using System;
using UnityEngine;

// Token: 0x020004C4 RID: 1220
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06001FF1 RID: 8177 RVA: 0x001C6A3A File Offset: 0x001C4C3A
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06001FF2 RID: 8178 RVA: 0x001C6A7C File Offset: 0x001C4C7C
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

	// Token: 0x0400433E RID: 17214
	public YandereScript Yandere;

	// Token: 0x0400433F RID: 17215
	public int Frame;

	// Token: 0x04004340 RID: 17216
	public int Limit;
}
