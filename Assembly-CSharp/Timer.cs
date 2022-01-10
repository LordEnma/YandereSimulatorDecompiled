using System;
using UnityEngine;

// Token: 0x020004AE RID: 1198
[Serializable]
public class Timer
{
	// Token: 0x06001F6B RID: 8043 RVA: 0x001B80A1 File Offset: 0x001B62A1
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F6C RID: 8044 RVA: 0x001B80BB File Offset: 0x001B62BB
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F6D RID: 8045 RVA: 0x001B80C3 File Offset: 0x001B62C3
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F6E RID: 8046 RVA: 0x001B80CB File Offset: 0x001B62CB
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F6F RID: 8047 RVA: 0x001B80DE File Offset: 0x001B62DE
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F70 RID: 8048 RVA: 0x001B80F2 File Offset: 0x001B62F2
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F71 RID: 8049 RVA: 0x001B80FF File Offset: 0x001B62FF
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001F72 RID: 8050 RVA: 0x001B8114 File Offset: 0x001B6314
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004164 RID: 16740
	[SerializeField]
	private float currentSeconds;

	// Token: 0x04004165 RID: 16741
	[SerializeField]
	private float targetSeconds;
}
