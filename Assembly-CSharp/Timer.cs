using System;
using UnityEngine;

// Token: 0x020004B9 RID: 1209
[Serializable]
public class Timer
{
	// Token: 0x06001FBA RID: 8122 RVA: 0x001BFEB1 File Offset: 0x001BE0B1
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001FBB RID: 8123 RVA: 0x001BFECB File Offset: 0x001BE0CB
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001FBC RID: 8124 RVA: 0x001BFED3 File Offset: 0x001BE0D3
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06001FBD RID: 8125 RVA: 0x001BFEDB File Offset: 0x001BE0DB
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C9 RID: 1225
	// (get) Token: 0x06001FBE RID: 8126 RVA: 0x001BFEEE File Offset: 0x001BE0EE
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001FBF RID: 8127 RVA: 0x001BFF02 File Offset: 0x001BE102
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001FC0 RID: 8128 RVA: 0x001BFF0F File Offset: 0x001BE10F
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001FC1 RID: 8129 RVA: 0x001BFF24 File Offset: 0x001BE124
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x0400424D RID: 16973
	[SerializeField]
	private float currentSeconds;

	// Token: 0x0400424E RID: 16974
	[SerializeField]
	private float targetSeconds;
}
