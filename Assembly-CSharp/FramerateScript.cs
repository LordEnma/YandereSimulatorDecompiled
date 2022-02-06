using System;
using UnityEngine;

// Token: 0x020002D3 RID: 723
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014B1 RID: 5297 RVA: 0x000CB9CB File Offset: 0x000C9BCB
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014B2 RID: 5298 RVA: 0x000CB9DC File Offset: 0x000C9BDC
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

	// Token: 0x0400207A RID: 8314
	public float updateInterval = 0.5f;

	// Token: 0x0400207B RID: 8315
	private float accum;

	// Token: 0x0400207C RID: 8316
	private int frames;

	// Token: 0x0400207D RID: 8317
	private float timeleft;

	// Token: 0x0400207E RID: 8318
	public float FpsAverage;

	// Token: 0x0400207F RID: 8319
	public float FpsCurrent;

	// Token: 0x04002080 RID: 8320
	public UILabel FPSLabel;
}
