using System;
using UnityEngine;

// Token: 0x020004B7 RID: 1207
[Serializable]
public class Timer
{
	// Token: 0x06001FA3 RID: 8099 RVA: 0x001BDC11 File Offset: 0x001BBE11
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001FA4 RID: 8100 RVA: 0x001BDC2B File Offset: 0x001BBE2B
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001FA5 RID: 8101 RVA: 0x001BDC33 File Offset: 0x001BBE33
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001FA6 RID: 8102 RVA: 0x001BDC3B File Offset: 0x001BBE3B
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06001FA7 RID: 8103 RVA: 0x001BDC4E File Offset: 0x001BBE4E
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001FA8 RID: 8104 RVA: 0x001BDC62 File Offset: 0x001BBE62
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001FA9 RID: 8105 RVA: 0x001BDC6F File Offset: 0x001BBE6F
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001FAA RID: 8106 RVA: 0x001BDC84 File Offset: 0x001BBE84
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004224 RID: 16932
	[SerializeField]
	private float currentSeconds;

	// Token: 0x04004225 RID: 16933
	[SerializeField]
	private float targetSeconds;
}
