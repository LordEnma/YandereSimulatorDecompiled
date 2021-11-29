using System;
using UnityEngine;

// Token: 0x020004AB RID: 1195
[Serializable]
public class Timer
{
	// Token: 0x06001F53 RID: 8019 RVA: 0x001B648D File Offset: 0x001B468D
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C1 RID: 1217
	// (get) Token: 0x06001F54 RID: 8020 RVA: 0x001B64A7 File Offset: 0x001B46A7
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F55 RID: 8021 RVA: 0x001B64AF File Offset: 0x001B46AF
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F56 RID: 8022 RVA: 0x001B64B7 File Offset: 0x001B46B7
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F57 RID: 8023 RVA: 0x001B64CA File Offset: 0x001B46CA
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F58 RID: 8024 RVA: 0x001B64DE File Offset: 0x001B46DE
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F59 RID: 8025 RVA: 0x001B64EB File Offset: 0x001B46EB
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001F5A RID: 8026 RVA: 0x001B6500 File Offset: 0x001B4700
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004119 RID: 16665
	[SerializeField]
	private float currentSeconds;

	// Token: 0x0400411A RID: 16666
	[SerializeField]
	private float targetSeconds;
}
