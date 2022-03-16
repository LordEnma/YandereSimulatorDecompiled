using System;
using UnityEngine;

// Token: 0x020002D5 RID: 725
public class FramerateScript : MonoBehaviour
{
	// Token: 0x060014C2 RID: 5314 RVA: 0x000CC98F File Offset: 0x000CAB8F
	private void Start()
	{
		this.timeleft = this.updateInterval;
	}

	// Token: 0x060014C3 RID: 5315 RVA: 0x000CC9A0 File Offset: 0x000CABA0
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

	// Token: 0x040020A8 RID: 8360
	public float updateInterval = 0.5f;

	// Token: 0x040020A9 RID: 8361
	private float accum;

	// Token: 0x040020AA RID: 8362
	private int frames;

	// Token: 0x040020AB RID: 8363
	private float timeleft;

	// Token: 0x040020AC RID: 8364
	public float FpsAverage;

	// Token: 0x040020AD RID: 8365
	public float FpsCurrent;

	// Token: 0x040020AE RID: 8366
	public UILabel FPSLabel;
}
