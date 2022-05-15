using System;
using UnityEngine;

// Token: 0x020002D8 RID: 728
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014D3 RID: 5331 RVA: 0x000CD64F File Offset: 0x000CB84F
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014D4 RID: 5332 RVA: 0x000CD660 File Offset: 0x000CB860
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

	// Token: 0x040020C3 RID: 8387
	public float updateInterval = 0.5f;

	// Token: 0x040020C4 RID: 8388
	private float accum;

	// Token: 0x040020C5 RID: 8389
	private int frames;

	// Token: 0x040020C6 RID: 8390
	private float timeleft;

	// Token: 0x040020C7 RID: 8391
	public float FpsAverage;

	// Token: 0x040020C8 RID: 8392
	public float FpsCurrent;

	// Token: 0x040020C9 RID: 8393
	public UILabel FPSLabel;
}
