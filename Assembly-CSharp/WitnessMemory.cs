using System;
using UnityEngine;

// Token: 0x020002B7 RID: 695
[Serializable]
public class WitnessMemory
{
	// Token: 0x06001463 RID: 5219 RVA: 0x000C6AD0 File Offset: 0x000C4CD0
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x06001464 RID: 5220 RVA: 0x000C6B2D File Offset: 0x000C4D2D
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x000C6B3F File Offset: 0x000C4D3F
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x06001466 RID: 5222 RVA: 0x000C6B50 File Offset: 0x000C4D50
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F5F RID: 8031
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F60 RID: 8032
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F61 RID: 8033
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F62 RID: 8034
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F63 RID: 8035
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F64 RID: 8036
	private const float VeryShortMemorySpan = 120f;
}
