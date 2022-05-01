using System;
using UnityEngine;

// Token: 0x020002D7 RID: 727
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014D1 RID: 5329 RVA: 0x000CD383 File Offset: 0x000CB583
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014D2 RID: 5330 RVA: 0x000CD394 File Offset: 0x000CB594
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

	// Token: 0x040020BA RID: 8378
	public float updateInterval = 0.5f;

	// Token: 0x040020BB RID: 8379
	private float accum;

	// Token: 0x040020BC RID: 8380
	private int frames;

	// Token: 0x040020BD RID: 8381
	private float timeleft;

	// Token: 0x040020BE RID: 8382
	public float FpsAverage;

	// Token: 0x040020BF RID: 8383
	public float FpsCurrent;

	// Token: 0x040020C0 RID: 8384
	public UILabel FPSLabel;
}
