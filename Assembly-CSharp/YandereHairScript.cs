using System;
using UnityEngine;

// Token: 0x020004D1 RID: 1233
public class YandereHairScript : MonoBehaviour
{
	// Token: 0x06002046 RID: 8262 RVA: 0x001CF1D6 File Offset: 0x001CD3D6
	private void Start()
	{
		ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
		this.Limit = this.Yandere.Hairstyles.Length - 1;
	}

	// Token: 0x06002047 RID: 8263 RVA: 0x001CF218 File Offset: 0x001CD418
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

	// Token: 0x04004450 RID: 17488
	public YandereScript Yandere;

	// Token: 0x04004451 RID: 17489
	public int Frame;

	// Token: 0x04004452 RID: 17490
	public int Limit;
}
