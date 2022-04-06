using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x0600202B RID: 8235 RVA: 0x001CB8DA File Offset: 0x001C9ADA
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x0600202C RID: 8236 RVA: 0x001CB91C File Offset: 0x001C9B1C
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

	// Token: 0x040043FB RID: 17403
	public YandereScript Yandere;

	// Token: 0x040043FC RID: 17404
	public int Frame;

	// Token: 0x040043FD RID: 17405
	public int Limit;
}
