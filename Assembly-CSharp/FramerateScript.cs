using System;
using UnityEngine;

// Token: 0x020002D1 RID: 721
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014A5 RID: 5285 RVA: 0x000CA6B3 File Offset: 0x000C88B3
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014A6 RID: 5286 RVA: 0x000CA6C4 File Offset: 0x000C88C4
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

	// Token: 0x04002048 RID: 8264
	public float updateInterval = 0.5f;

	// Token: 0x04002049 RID: 8265
	private float accum;

	// Token: 0x0400204A RID: 8266
	private int frames;

	// Token: 0x0400204B RID: 8267
	private float timeleft;

	// Token: 0x0400204C RID: 8268
	public float FpsAverage;

	// Token: 0x0400204D RID: 8269
	public float FpsCurrent;

	// Token: 0x0400204E RID: 8270
	public UILabel FPSLabel;
}
