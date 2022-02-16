using System;
using UnityEngine;

// Token: 0x020002D4 RID: 724
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014B6 RID: 5302 RVA: 0x000CBABF File Offset: 0x000C9CBF
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014B7 RID: 5303 RVA: 0x000CBAD0 File Offset: 0x000C9CD0
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

	// Token: 0x0400207F RID: 8319
	public float updateInterval = 0.5f;

	// Token: 0x04002080 RID: 8320
	private float accum;

	// Token: 0x04002081 RID: 8321
	private int frames;

	// Token: 0x04002082 RID: 8322
	private float timeleft;

	// Token: 0x04002083 RID: 8323
	public float FpsAverage;

	// Token: 0x04002084 RID: 8324
	public float FpsCurrent;

	// Token: 0x04002085 RID: 8325
	public UILabel FPSLabel;
}
