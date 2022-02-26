using System;
using UnityEngine;

// Token: 0x020004B1 RID: 1201
[Serializable]
public class Timer
{
	// Token: 0x06001F84 RID: 8068 RVA: 0x001BA765 File Offset: 0x001B8965
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F85 RID: 8069 RVA: 0x001BA77F File Offset: 0x001B897F
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F86 RID: 8070 RVA: 0x001BA787 File Offset: 0x001B8987
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001F87 RID: 8071 RVA: 0x001BA78F File Offset: 0x001B898F
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001F88 RID: 8072 RVA: 0x001BA7A2 File Offset: 0x001B89A2
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F89 RID: 8073 RVA: 0x001BA7B6 File Offset: 0x001B89B6
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F8A RID: 8074 RVA: 0x001BA7C3 File Offset: 0x001B89C3
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001F8B RID: 8075 RVA: 0x001BA7D8 File Offset: 0x001B89D8
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004195 RID: 16789
	[SerializeField]
	private float currentSeconds;

	// Token: 0x04004196 RID: 16790
	[SerializeField]
	private float targetSeconds;
}
