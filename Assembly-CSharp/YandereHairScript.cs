using System;
using UnityEngine;

// Token: 0x020004D0 RID: 1232
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x0600203B RID: 8251 RVA: 0x001CD76E File Offset: 0x001CB96E
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x0600203C RID: 8252 RVA: 0x001CD7B0 File Offset: 0x001CB9B0
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

	// Token: 0x04004421 RID: 17441
	public YandereScript Yandere;

	// Token: 0x04004422 RID: 17442
	public int Frame;

	// Token: 0x04004423 RID: 17443
	public int Limit;
}
