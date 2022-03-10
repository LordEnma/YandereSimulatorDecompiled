using System;
using UnityEngine;

// Token: 0x020002D5 RID: 725
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014BF RID: 5311 RVA: 0x000CC51F File Offset: 0x000CA71F
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014C0 RID: 5312 RVA: 0x000CC530 File Offset: 0x000CA730
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

	// Token: 0x04002098 RID: 8344
	public float updateInterval = 0.5f;

	// Token: 0x04002099 RID: 8345
	private float accum;

	// Token: 0x0400209A RID: 8346
	private int frames;

	// Token: 0x0400209B RID: 8347
	private float timeleft;

	// Token: 0x0400209C RID: 8348
	public float FpsAverage;

	// Token: 0x0400209D RID: 8349
	public float FpsCurrent;

	// Token: 0x0400209E RID: 8350
	public UILabel FPSLabel;
}
