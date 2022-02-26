using System;
using UnityEngine;

// Token: 0x020002D5 RID: 725
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014BF RID: 5311 RVA: 0x000CC3A3 File Offset: 0x000CA5A3
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014C0 RID: 5312 RVA: 0x000CC3B4 File Offset: 0x000CA5B4
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

	// Token: 0x0400208E RID: 8334
	public float updateInterval = 0.5f;

	// Token: 0x0400208F RID: 8335
	private float accum;

	// Token: 0x04002090 RID: 8336
	private int frames;

	// Token: 0x04002091 RID: 8337
	private float timeleft;

	// Token: 0x04002092 RID: 8338
	public float FpsAverage;

	// Token: 0x04002093 RID: 8339
	public float FpsCurrent;

	// Token: 0x04002094 RID: 8340
	public UILabel FPSLabel;
}
