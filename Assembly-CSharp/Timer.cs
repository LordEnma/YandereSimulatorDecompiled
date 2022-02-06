using System;
using UnityEngine;

// Token: 0x020004AF RID: 1199
[Serializable]
public class Timer
{
	// Token: 0x06001F74 RID: 8052 RVA: 0x001B97C5 File Offset: 0x001B79C5
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F75 RID: 8053 RVA: 0x001B97DF File Offset: 0x001B79DF
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F76 RID: 8054 RVA: 0x001B97E7 File Offset: 0x001B79E7
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F77 RID: 8055 RVA: 0x001B97EF File Offset: 0x001B79EF
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001F78 RID: 8056 RVA: 0x001B9802 File Offset: 0x001B7A02
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F79 RID: 8057 RVA: 0x001B9816 File Offset: 0x001B7A16
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F7A RID: 8058 RVA: 0x001B9823 File Offset: 0x001B7A23
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001F7B RID: 8059 RVA: 0x001B9838 File Offset: 0x001B7A38
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x0400417C RID: 16764
	[SerializeField]
	private float currentSeconds;

	// Token: 0x0400417D RID: 16765
	[SerializeField]
	private float targetSeconds;
}
