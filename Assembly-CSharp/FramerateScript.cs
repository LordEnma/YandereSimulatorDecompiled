using System;
using UnityEngine;

// Token: 0x020002D7 RID: 727
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014CB RID: 5323 RVA: 0x000CCCD3 File Offset: 0x000CAED3
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014CC RID: 5324 RVA: 0x000CCCE4 File Offset: 0x000CAEE4
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

	// Token: 0x040020AF RID: 8367
	public float updateInterval = 0.5f;

	// Token: 0x040020B0 RID: 8368
	private float accum;

	// Token: 0x040020B1 RID: 8369
	private int frames;

	// Token: 0x040020B2 RID: 8370
	private float timeleft;

	// Token: 0x040020B3 RID: 8371
	public float FpsAverage;

	// Token: 0x040020B4 RID: 8372
	public float FpsCurrent;

	// Token: 0x040020B5 RID: 8373
	public UILabel FPSLabel;
}
