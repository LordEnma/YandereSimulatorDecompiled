using System;
using UnityEngine;

// Token: 0x020004AF RID: 1199
[Serializable]
public class Timer
{
	// Token: 0x06001F71 RID: 8049 RVA: 0x001B95A5 File Offset: 0x001B77A5
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F72 RID: 8050 RVA: 0x001B95BF File Offset: 0x001B77BF
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F73 RID: 8051 RVA: 0x001B95C7 File Offset: 0x001B77C7
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F74 RID: 8052 RVA: 0x001B95CF File Offset: 0x001B77CF
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F75 RID: 8053 RVA: 0x001B95E2 File Offset: 0x001B77E2
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F76 RID: 8054 RVA: 0x001B95F6 File Offset: 0x001B77F6
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F77 RID: 8055 RVA: 0x001B9603 File Offset: 0x001B7803
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001F78 RID: 8056 RVA: 0x001B9618 File Offset: 0x001B7818
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004179 RID: 16761
	[SerializeField]
	private float currentSeconds;

	// Token: 0x0400417A RID: 16762
	[SerializeField]
	private float targetSeconds;
}
