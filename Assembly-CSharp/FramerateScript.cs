using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014AC RID: 5292 RVA: 0x000CB09F File Offset: 0x000C929F
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014AD RID: 5293 RVA: 0x000CB0B0 File Offset: 0x000C92B0
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

	// Token: 0x0400206B RID: 8299
	public float updateInterval = 0.5f;

	// Token: 0x0400206C RID: 8300
	private float accum;

	// Token: 0x0400206D RID: 8301
	private int frames;

	// Token: 0x0400206E RID: 8302
	private float timeleft;

	// Token: 0x0400206F RID: 8303
	public float FpsAverage;

	// Token: 0x04002070 RID: 8304
	public float FpsCurrent;

	// Token: 0x04002071 RID: 8305
	public UILabel FPSLabel;
}
