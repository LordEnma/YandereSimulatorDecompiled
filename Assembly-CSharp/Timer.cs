using System;
using UnityEngine;

// Token: 0x020004BA RID: 1210
[Serializable]
public class Timer
{
	// Token: 0x06001FC4 RID: 8132 RVA: 0x001C1145 File Offset: 0x001BF345
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001FC5 RID: 8133 RVA: 0x001C115F File Offset: 0x001BF35F
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06001FC6 RID: 8134 RVA: 0x001C1167 File Offset: 0x001BF367
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C9 RID: 1225
	// (get) Token: 0x06001FC7 RID: 8135 RVA: 0x001C116F File Offset: 0x001BF36F
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004CA RID: 1226
	// (get) Token: 0x06001FC8 RID: 8136 RVA: 0x001C1182 File Offset: 0x001BF382
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001FC9 RID: 8137 RVA: 0x001C1196 File Offset: 0x001BF396
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001FCA RID: 8138 RVA: 0x001C11A3 File Offset: 0x001BF3A3
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001FCB RID: 8139 RVA: 0x001C11B8 File Offset: 0x001BF3B8
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x0400426B RID: 17003
	[SerializeField]
	private float currentSeconds;

	// Token: 0x0400426C RID: 17004
	[SerializeField]
	private float targetSeconds;
}
