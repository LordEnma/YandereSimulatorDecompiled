using System;
using UnityEngine;

// Token: 0x020002D3 RID: 723
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014B0 RID: 5296 RVA: 0x000CB46B File Offset: 0x000C966B
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014B1 RID: 5297 RVA: 0x000CB47C File Offset: 0x000C967C
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

	// Token: 0x04002072 RID: 8306
	public float updateInterval = 0.5f;

	// Token: 0x04002073 RID: 8307
	private float accum;

	// Token: 0x04002074 RID: 8308
	private int frames;

	// Token: 0x04002075 RID: 8309
	private float timeleft;

	// Token: 0x04002076 RID: 8310
	public float FpsAverage;

	// Token: 0x04002077 RID: 8311
	public float FpsCurrent;

	// Token: 0x04002078 RID: 8312
	public UILabel FPSLabel;
}
