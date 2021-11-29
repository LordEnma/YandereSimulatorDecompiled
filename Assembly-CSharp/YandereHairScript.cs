using System;
using UnityEngine;

// Token: 0x020004BE RID: 1214
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06001FC1 RID: 8129 RVA: 0x001C27E6 File Offset: 0x001C09E6
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06001FC2 RID: 8130 RVA: 0x001C2828 File Offset: 0x001C0A28
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

	// Token: 0x040042C0 RID: 17088
	public YandereScript Yandere;

	// Token: 0x040042C1 RID: 17089
	public int Frame;

	// Token: 0x040042C2 RID: 17090
	public int Limit;
}
