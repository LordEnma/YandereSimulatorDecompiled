using System;
using UnityEngine;

// Token: 0x020004C3 RID: 1219
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06001FE2 RID: 8162 RVA: 0x001C5B7E File Offset: 0x001C3D7E
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06001FE3 RID: 8163 RVA: 0x001C5BC0 File Offset: 0x001C3DC0
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

	// Token: 0x04004323 RID: 17187
	public YandereScript Yandere;

	// Token: 0x04004324 RID: 17188
	public int Frame;

	// Token: 0x04004325 RID: 17189
	public int Limit;
}
