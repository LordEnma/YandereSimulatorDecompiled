using System;
using UnityEngine;

// Token: 0x020002B4 RID: 692
[Serializable]
public class WitnessMemory
{
	// Token: 0x0600144A RID: 5194 RVA: 0x000C55B8 File Offset: 0x000C37B8
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x0600144B RID: 5195 RVA: 0x000C5615 File Offset: 0x000C3815
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x0600144C RID: 5196 RVA: 0x000C5627 File Offset: 0x000C3827
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x0600144D RID: 5197 RVA: 0x000C5638 File Offset: 0x000C3838
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F26 RID: 7974
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F27 RID: 7975
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F28 RID: 7976
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F29 RID: 7977
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F2A RID: 7978
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F2B RID: 7979
	private const float VeryShortMemorySpan = 120f;
}
