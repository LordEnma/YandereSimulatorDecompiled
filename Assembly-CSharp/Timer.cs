using System;
using UnityEngine;

// Token: 0x020004BA RID: 1210
[Serializable]
public class Timer
{
	// Token: 0x06001FC5 RID: 8133 RVA: 0x001C15C1 File Offset: 0x001BF7C1
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001FC6 RID: 8134 RVA: 0x001C15DB File Offset: 0x001BF7DB
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06001FC7 RID: 8135 RVA: 0x001C15E3 File Offset: 0x001BF7E3
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C9 RID: 1225
	// (get) Token: 0x06001FC8 RID: 8136 RVA: 0x001C15EB File Offset: 0x001BF7EB
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004CA RID: 1226
	// (get) Token: 0x06001FC9 RID: 8137 RVA: 0x001C15FE File Offset: 0x001BF7FE
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001FCA RID: 8138 RVA: 0x001C1612 File Offset: 0x001BF812
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001FCB RID: 8139 RVA: 0x001C161F File Offset: 0x001BF81F
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001FCC RID: 8140 RVA: 0x001C1634 File Offset: 0x001BF834
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004274 RID: 17012
	[SerializeField]
	private float currentSeconds;

	// Token: 0x04004275 RID: 17013
	[SerializeField]
	private float targetSeconds;
}
