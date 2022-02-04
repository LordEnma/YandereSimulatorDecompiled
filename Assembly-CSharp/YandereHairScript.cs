using System;
using UnityEngine;

// Token: 0x020004C3 RID: 1219
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06001FE7 RID: 8167 RVA: 0x001C63CE File Offset: 0x001C45CE
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06001FE8 RID: 8168 RVA: 0x001C6410 File Offset: 0x001C4610
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

	// Token: 0x04004332 RID: 17202
	public YandereScript Yandere;

	// Token: 0x04004333 RID: 17203
	public int Frame;

	// Token: 0x04004334 RID: 17204
	public int Limit;
}
