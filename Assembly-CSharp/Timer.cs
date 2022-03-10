using System;
using UnityEngine;

// Token: 0x020004B1 RID: 1201
[Serializable]
public class Timer
{
	// Token: 0x06001F87 RID: 8071 RVA: 0x001BAF05 File Offset: 0x001B9105
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F88 RID: 8072 RVA: 0x001BAF1F File Offset: 0x001B911F
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F89 RID: 8073 RVA: 0x001BAF27 File Offset: 0x001B9127
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001F8A RID: 8074 RVA: 0x001BAF2F File Offset: 0x001B912F
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001F8B RID: 8075 RVA: 0x001BAF42 File Offset: 0x001B9142
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F8C RID: 8076 RVA: 0x001BAF56 File Offset: 0x001B9156
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F8D RID: 8077 RVA: 0x001BAF63 File Offset: 0x001B9163
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001F8E RID: 8078 RVA: 0x001BAF78 File Offset: 0x001B9178
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x040041AC RID: 16812
	[SerializeField]
	private float currentSeconds;

	// Token: 0x040041AD RID: 16813
	[SerializeField]
	private float targetSeconds;
}
