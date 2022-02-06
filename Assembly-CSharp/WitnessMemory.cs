using System;
using UnityEngine;

// Token: 0x020002B4 RID: 692
[Serializable]
public class WitnessMemory
{
	// Token: 0x0600144B RID: 5195 RVA: 0x000C5900 File Offset: 0x000C3B00
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x0600144C RID: 5196 RVA: 0x000C595D File Offset: 0x000C3B5D
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x0600144D RID: 5197 RVA: 0x000C596F File Offset: 0x000C3B6F
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x0600144E RID: 5198 RVA: 0x000C5980 File Offset: 0x000C3B80
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F2D RID: 7981
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F2E RID: 7982
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F2F RID: 7983
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F30 RID: 7984
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F31 RID: 7985
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F32 RID: 7986
	private const float VeryShortMemorySpan = 120f;
}
