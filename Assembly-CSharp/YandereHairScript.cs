using System;
using UnityEngine;

// Token: 0x020004C3 RID: 1219
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06001FEA RID: 8170 RVA: 0x001C65D2 File Offset: 0x001C47D2
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06001FEB RID: 8171 RVA: 0x001C6614 File Offset: 0x001C4814
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

	// Token: 0x04004335 RID: 17205
	public YandereScript Yandere;

	// Token: 0x04004336 RID: 17206
	public int Frame;

	// Token: 0x04004337 RID: 17207
	public int Limit;
}
