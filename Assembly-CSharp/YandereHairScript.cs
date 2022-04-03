using System;
using UnityEngine;

// Token: 0x020004CE RID: 1230
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06002023 RID: 8227 RVA: 0x001CB3BA File Offset: 0x001C95BA
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06002024 RID: 8228 RVA: 0x001CB3FC File Offset: 0x001C95FC
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

	// Token: 0x040043F7 RID: 17399
	public YandereScript Yandere;

	// Token: 0x040043F8 RID: 17400
	public int Frame;

	// Token: 0x040043F9 RID: 17401
	public int Limit;
}
