using System;
using UnityEngine;

// Token: 0x020004CA RID: 1226
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06002016 RID: 8214 RVA: 0x001C9C32 File Offset: 0x001C7E32
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06002017 RID: 8215 RVA: 0x001C9C74 File Offset: 0x001C7E74
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

	// Token: 0x040043C6 RID: 17350
	public YandereScript Yandere;

	// Token: 0x040043C7 RID: 17351
	public int Frame;

	// Token: 0x040043C8 RID: 17352
	public int Limit;
}
