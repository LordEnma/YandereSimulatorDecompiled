using System;
using UnityEngine;

// Token: 0x020002B6 RID: 694
[Serializable]
public class WitnessMemory
{
	// Token: 0x0600145D RID: 5213 RVA: 0x000C69C8 File Offset: 0x000C4BC8
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x0600145E RID: 5214 RVA: 0x000C6A25 File Offset: 0x000C4C25
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x0600145F RID: 5215 RVA: 0x000C6A37 File Offset: 0x000C4C37
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x000C6A48 File Offset: 0x000C4C48
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F5D RID: 8029
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F5E RID: 8030
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F5F RID: 8031
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F60 RID: 8032
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F61 RID: 8033
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F62 RID: 8034
	private const float VeryShortMemorySpan = 120f;
}
