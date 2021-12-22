using System;
using UnityEngine;

// Token: 0x020004AC RID: 1196
[Serializable]
public class Timer
{
	// Token: 0x06001F5D RID: 8029 RVA: 0x001B7249 File Offset: 0x001B5449
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F5E RID: 8030 RVA: 0x001B7263 File Offset: 0x001B5463
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F5F RID: 8031 RVA: 0x001B726B File Offset: 0x001B546B
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F60 RID: 8032 RVA: 0x001B7273 File Offset: 0x001B5473
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F61 RID: 8033 RVA: 0x001B7286 File Offset: 0x001B5486
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F62 RID: 8034 RVA: 0x001B729A File Offset: 0x001B549A
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F63 RID: 8035 RVA: 0x001B72A7 File Offset: 0x001B54A7
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001F64 RID: 8036 RVA: 0x001B72BC File Offset: 0x001B54BC
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004149 RID: 16713
	[SerializeField]
	private float currentSeconds;

	// Token: 0x0400414A RID: 16714
	[SerializeField]
	private float targetSeconds;
}
