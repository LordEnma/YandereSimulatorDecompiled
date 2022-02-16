using System;
using UnityEngine;

// Token: 0x020002B5 RID: 693
[Serializable]
public class WitnessMemory
{
	// Token: 0x06001450 RID: 5200 RVA: 0x000C59F4 File Offset: 0x000C3BF4
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x06001451 RID: 5201 RVA: 0x000C5A51 File Offset: 0x000C3C51
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x06001452 RID: 5202 RVA: 0x000C5A63 File Offset: 0x000C3C63
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x06001453 RID: 5203 RVA: 0x000C5A74 File Offset: 0x000C3C74
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F32 RID: 7986
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F33 RID: 7987
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F34 RID: 7988
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F35 RID: 7989
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F36 RID: 7990
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F37 RID: 7991
	private const float VeryShortMemorySpan = 120f;
}
