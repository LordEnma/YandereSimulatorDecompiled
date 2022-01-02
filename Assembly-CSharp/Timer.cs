using System;
using UnityEngine;

// Token: 0x020004AC RID: 1196
[Serializable]
public class Timer
{
	// Token: 0x06001F60 RID: 8032 RVA: 0x001B7721 File Offset: 0x001B5921
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C2 RID: 1218
	// (get) Token: 0x06001F61 RID: 8033 RVA: 0x001B773B File Offset: 0x001B593B
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C3 RID: 1219
	// (get) Token: 0x06001F62 RID: 8034 RVA: 0x001B7743 File Offset: 0x001B5943
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C4 RID: 1220
	// (get) Token: 0x06001F63 RID: 8035 RVA: 0x001B774B File Offset: 0x001B594B
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C5 RID: 1221
	// (get) Token: 0x06001F64 RID: 8036 RVA: 0x001B775E File Offset: 0x001B595E
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001F65 RID: 8037 RVA: 0x001B7772 File Offset: 0x001B5972
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001F66 RID: 8038 RVA: 0x001B777F File Offset: 0x001B597F
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001F67 RID: 8039 RVA: 0x001B7794 File Offset: 0x001B5994
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x04004150 RID: 16720
	[SerializeField]
	private float currentSeconds;

	// Token: 0x04004151 RID: 16721
	[SerializeField]
	private float targetSeconds;
}
