using System;
using UnityEngine;

// Token: 0x020002B7 RID: 695
[Serializable]
public class WitnessMemory
{
	// Token: 0x06001467 RID: 5223 RVA: 0x000C7110 File Offset: 0x000C5310
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x06001468 RID: 5224 RVA: 0x000C716D File Offset: 0x000C536D
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x06001469 RID: 5225 RVA: 0x000C717F File Offset: 0x000C537F
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x000C7190 File Offset: 0x000C5390
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F6A RID: 8042
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F6B RID: 8043
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F6C RID: 8044
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F6D RID: 8045
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F6E RID: 8046
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F6F RID: 8047
	private const float VeryShortMemorySpan = 120f;
}
