using System;
using UnityEngine;

// Token: 0x020004B9 RID: 1209
[Serializable]
public class Timer
{
	// Token: 0x06001FBB RID: 8123 RVA: 0x001BFFAD File Offset: 0x001BE1AD
	public Timer(float targetSeconds)
	{
		this.currentSeconds = 0f;
		this.targetSeconds = targetSeconds;
	}

	// Token: 0x170004C6 RID: 1222
	// (get) Token: 0x06001FBC RID: 8124 RVA: 0x001BFFC7 File Offset: 0x001BE1C7
	public float CurrentSeconds
	{
		get
		{
			return this.currentSeconds;
		}
	}

	// Token: 0x170004C7 RID: 1223
	// (get) Token: 0x06001FBD RID: 8125 RVA: 0x001BFFCF File Offset: 0x001BE1CF
	public float TargetSeconds
	{
		get
		{
			return this.targetSeconds;
		}
	}

	// Token: 0x170004C8 RID: 1224
	// (get) Token: 0x06001FBE RID: 8126 RVA: 0x001BFFD7 File Offset: 0x001BE1D7
	public bool IsDone
	{
		get
		{
			return this.currentSeconds >= this.targetSeconds;
		}
	}

	// Token: 0x170004C9 RID: 1225
	// (get) Token: 0x06001FBF RID: 8127 RVA: 0x001BFFEA File Offset: 0x001BE1EA
	public float Progress
	{
		get
		{
			return Mathf.Clamp01(this.currentSeconds / this.targetSeconds);
		}
	}

	// Token: 0x06001FC0 RID: 8128 RVA: 0x001BFFFE File Offset: 0x001BE1FE
	public void Reset()
	{
		this.currentSeconds = 0f;
	}

	// Token: 0x06001FC1 RID: 8129 RVA: 0x001C000B File Offset: 0x001BE20B
	public void SubtractTarget()
	{
		this.currentSeconds -= this.targetSeconds;
	}

	// Token: 0x06001FC2 RID: 8130 RVA: 0x001C0020 File Offset: 0x001BE220
	public void Tick(float dt)
	{
		this.currentSeconds += dt;
	}

	// Token: 0x0400424D RID: 16973
	[SerializeField]
	private float currentSeconds;

	// Token: 0x0400424E RID: 16974
	[SerializeField]
	private float targetSeconds;
}
