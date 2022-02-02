using System;
using UnityEngine;

// Token: 0x020004AF RID: 1199
[Serializable]
public class Timer
{
	// Token: 0x06001F6F RID: 8047 RVA: 0x001B9299 File Offset: 0x001B7499
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F70 RID: 8048 RVA: 0x001B92B3 File Offset: 0x001B74B3
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F71 RID: 8049 RVA: 0x001B92BB File Offset: 0x001B74BB
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F72 RID: 8050 RVA: 0x001B92C3 File Offset: 0x001B74C3
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F73 RID: 8051 RVA: 0x001B92D6 File Offset: 0x001B74D6
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F74 RID: 8052 RVA: 0x001B92EA File Offset: 0x001B74EA
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F75 RID: 8053 RVA: 0x001B92F7 File Offset: 0x001B74F7
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001F76 RID: 8054 RVA: 0x001B930C File Offset: 0x001B750C
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004173 RID: 16755
	[SerializeField]
	private float currentSeconds;

	// Token: 0x04004174 RID: 16756
	[SerializeField]
	private float targetSeconds;
}
