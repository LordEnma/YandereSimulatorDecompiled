using System;
using UnityEngine;

// Token: 0x020004B8 RID: 1208
[Serializable]
public class Timer
{
	// Token: 0x06001FB1 RID: 8113 RVA: 0x001BEAF5 File Offset: 0x001BCCF5
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001FB2 RID: 8114 RVA: 0x001BEB0F File Offset: 0x001BCD0F
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001FB3 RID: 8115 RVA: 0x001BEB17 File Offset: 0x001BCD17
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06001FB4 RID: 8116 RVA: 0x001BEB1F File Offset: 0x001BCD1F
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C9 RID: 1225
	// (get) Token: 0x06001FB5 RID: 8117 RVA: 0x001BEB32 File Offset: 0x001BCD32
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001FB6 RID: 8118 RVA: 0x001BEB46 File Offset: 0x001BCD46
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001FB7 RID: 8119 RVA: 0x001BEB53 File Offset: 0x001BCD53
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001FB8 RID: 8120 RVA: 0x001BEB68 File Offset: 0x001BCD68
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004237 RID: 16951
	[SerializeField]
	private float currentSeconds;

	// Token: 0x04004238 RID: 16952
	[SerializeField]
	private float targetSeconds;
}
