using System;
using UnityEngine;

// Token: 0x020002D2 RID: 722
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014AC RID: 5292 RVA: 0x000CAE57 File Offset: 0x000C9057
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014AD RID: 5293 RVA: 0x000CAE68 File Offset: 0x000C9068
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

	// Token: 0x04002068 RID: 8296
	public float updateInterval = 0.5f;

	// Token: 0x04002069 RID: 8297
	private float accum;

	// Token: 0x0400206A RID: 8298
	private int frames;

	// Token: 0x0400206B RID: 8299
	private float timeleft;

	// Token: 0x0400206C RID: 8300
	public float FpsAverage;

	// Token: 0x0400206D RID: 8301
	public float FpsCurrent;

	// Token: 0x0400206E RID: 8302
	public UILabel FPSLabel;
}
