using System;
using UnityEngine;

// Token: 0x020002D7 RID: 727
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014CD RID: 5325 RVA: 0x000CCEBB File Offset: 0x000CB0BB
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014CE RID: 5326 RVA: 0x000CCECC File Offset: 0x000CB0CC
	private void Update()
	{
		this.FpsCurrent = 1f / Time.unscaledDeltaTime;
		this.timeleft -= Time.unscaledDeltaTime;
		this.accum += this.FpsCurrent;
		this.frames++;
		if (this.timeleft <= 0f)
		{
			this.FpsAverage = this.accum / (float)this.frames;
			this.timeleft = this.updateInterval;
			this.accum = 0f;
			this.frames = 0;
			int num = Mathf.Clamp((int)this.FpsAverage, 0, Application.targetFrameRate);
			Mathf.Clamp((int)this.FpsCurrent, 0, Application.targetFrameRate);
			this.FPSLabel.text = "FPS: " + num.ToString();
		}
	}

	// Token: 0x040020B1 RID: 8369
	public float updateInterval = 0.5f;

	// Token: 0x040020B2 RID: 8370
	private float accum;

	// Token: 0x040020B3 RID: 8371
	private int frames;

	// Token: 0x040020B4 RID: 8372
	private float timeleft;

	// Token: 0x040020B5 RID: 8373
	public float FpsAverage;

	// Token: 0x040020B6 RID: 8374
	public float FpsCurrent;

	// Token: 0x040020B7 RID: 8375
	public UILabel FPSLabel;
}
