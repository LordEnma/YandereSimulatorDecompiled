using System;
using UnityEngine;

// Token: 0x020004B4 RID: 1204
[Serializable]
public class Timer
{
	// Token: 0x06001F99 RID: 8089 RVA: 0x001BC685 File Offset: 0x001BA885
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F9A RID: 8090 RVA: 0x001BC69F File Offset: 0x001BA89F
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001F9B RID: 8091 RVA: 0x001BC6A7 File Offset: 0x001BA8A7
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001F9C RID: 8092 RVA: 0x001BC6AF File Offset: 0x001BA8AF
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06001F9D RID: 8093 RVA: 0x001BC6C2 File Offset: 0x001BA8C2
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F9E RID: 8094 RVA: 0x001BC6D6 File Offset: 0x001BA8D6
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F9F RID: 8095 RVA: 0x001BC6E3 File Offset: 0x001BA8E3
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001FA0 RID: 8096 RVA: 0x001BC6F8 File Offset: 0x001BA8F8
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x040041F7 RID: 16887
	[SerializeField]
	private float currentSeconds;

	// Token: 0x040041F8 RID: 16888
	[SerializeField]
	private float targetSeconds;
}
