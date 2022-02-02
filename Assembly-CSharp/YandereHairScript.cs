using System;
using UnityEngine;

// Token: 0x020004C3 RID: 1219
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06001FE5 RID: 8165 RVA: 0x001C60B6 File Offset: 0x001C42B6
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06001FE6 RID: 8166 RVA: 0x001C60F8 File Offset: 0x001C42F8
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

	// Token: 0x0400432C RID: 17196
	public YandereScript Yandere;

	// Token: 0x0400432D RID: 17197
	public int Frame;

	// Token: 0x0400432E RID: 17198
	public int Limit;
}
