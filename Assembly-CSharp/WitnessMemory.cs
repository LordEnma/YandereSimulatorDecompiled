using System;
using UnityEngine;

// Token: 0x020002B8 RID: 696
[Serializable]
public class WitnessMemory
{
	// Token: 0x06001469 RID: 5225 RVA: 0x000C7498 File Offset: 0x000C5698
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x0600146A RID: 5226 RVA: 0x000C74F5 File Offset: 0x000C56F5
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x0600146B RID: 5227 RVA: 0x000C7507 File Offset: 0x000C5707
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x0600146C RID: 5228 RVA: 0x000C7518 File Offset: 0x000C5718
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F71 RID: 8049
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F72 RID: 8050
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F73 RID: 8051
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F74 RID: 8052
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F75 RID: 8053
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F76 RID: 8054
	private const float VeryShortMemorySpan = 120f;
}
