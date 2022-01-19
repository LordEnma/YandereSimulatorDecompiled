using System;
using UnityEngine;

// Token: 0x020004AF RID: 1199
[Serializable]
public class Timer
{
	// Token: 0x06001F6D RID: 8045 RVA: 0x001B8D71 File Offset: 0x001B6F71
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F6E RID: 8046 RVA: 0x001B8D8B File Offset: 0x001B6F8B
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F6F RID: 8047 RVA: 0x001B8D93 File Offset: 0x001B6F93
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F70 RID: 8048 RVA: 0x001B8D9B File Offset: 0x001B6F9B
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F71 RID: 8049 RVA: 0x001B8DAE File Offset: 0x001B6FAE
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F72 RID: 8050 RVA: 0x001B8DC2 File Offset: 0x001B6FC2
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F73 RID: 8051 RVA: 0x001B8DCF File Offset: 0x001B6FCF
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001F74 RID: 8052 RVA: 0x001B8DE4 File Offset: 0x001B6FE4
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x0400416B RID: 16747
	[SerializeField]
	private float currentSeconds;

	// Token: 0x0400416C RID: 16748
	[SerializeField]
	private float targetSeconds;
}
