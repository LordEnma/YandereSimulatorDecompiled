using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06002045 RID: 8261 RVA: 0x001CECC2 File Offset: 0x001CCEC2
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06002046 RID: 8262 RVA: 0x001CED04 File Offset: 0x001CCF04
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

	// Token: 0x04004447 RID: 17479
	public YandereScript Yandere;

	// Token: 0x04004448 RID: 17480
	public int Frame;

	// Token: 0x04004449 RID: 17481
	public int Limit;
}
