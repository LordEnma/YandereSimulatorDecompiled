using System;
using UnityEngine;

// Token: 0x020004B0 RID: 1200
[Serializable]
public class Timer
{
	// Token: 0x06001F7B RID: 8059 RVA: 0x001B9C19 File Offset: 0x001B7E19
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F7C RID: 8060 RVA: 0x001B9C33 File Offset: 0x001B7E33
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F7D RID: 8061 RVA: 0x001B9C3B File Offset: 0x001B7E3B
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001F7E RID: 8062 RVA: 0x001B9C43 File Offset: 0x001B7E43
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001F7F RID: 8063 RVA: 0x001B9C56 File Offset: 0x001B7E56
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F80 RID: 8064 RVA: 0x001B9C6A File Offset: 0x001B7E6A
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F81 RID: 8065 RVA: 0x001B9C77 File Offset: 0x001B7E77
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001F82 RID: 8066 RVA: 0x001B9C8C File Offset: 0x001B7E8C
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004185 RID: 16773
	[SerializeField]
	private float currentSeconds;

	// Token: 0x04004186 RID: 16774
	[SerializeField]
	private float targetSeconds;
}
