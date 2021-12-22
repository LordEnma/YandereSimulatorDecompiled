using System;
using UnityEngine;

// Token: 0x020004C0 RID: 1216
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06001FD2 RID: 8146 RVA: 0x001C3F0E File Offset: 0x001C210E
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06001FD3 RID: 8147 RVA: 0x001C3F50 File Offset: 0x001C2150
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

	// Token: 0x040042FF RID: 17151
	public YandereScript Yandere;

	// Token: 0x04004300 RID: 17152
	public int Frame;

	// Token: 0x04004301 RID: 17153
	public int Limit;
}
