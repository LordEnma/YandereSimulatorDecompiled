using System;
using UnityEngine;

// Token: 0x020004B8 RID: 1208
[Serializable]
public class Timer
{
	// Token: 0x06001FAB RID: 8107 RVA: 0x001BE119 File Offset: 0x001BC319
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001FAC RID: 8108 RVA: 0x001BE133 File Offset: 0x001BC333
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001FAD RID: 8109 RVA: 0x001BE13B File Offset: 0x001BC33B
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001FAE RID: 8110 RVA: 0x001BE143 File Offset: 0x001BC343
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06001FAF RID: 8111 RVA: 0x001BE156 File Offset: 0x001BC356
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001FB0 RID: 8112 RVA: 0x001BE16A File Offset: 0x001BC36A
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001FB1 RID: 8113 RVA: 0x001BE177 File Offset: 0x001BC377
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001FB2 RID: 8114 RVA: 0x001BE18C File Offset: 0x001BC38C
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004227 RID: 16935
	[SerializeField]
	private float currentSeconds;

	// Token: 0x04004228 RID: 16936
	[SerializeField]
	private float targetSeconds;
}
