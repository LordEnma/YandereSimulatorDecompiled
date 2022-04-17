using System;
using UnityEngine;

// Token: 0x020002B7 RID: 695
[Serializable]
public class WitnessMemory
{
	// Token: 0x06001463 RID: 5219 RVA: 0x000C6C7C File Offset: 0x000C4E7C
	public WitnessMemory()
	{
		this.memories = new float[Enum.GetValues(typeof(WitnessMemoryType)).Length];
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] = float.PositiveInfinity;
		}
		this.memorySpan = 1800f;
	}

	// Token: 0x06001464 RID: 5220 RVA: 0x000C6CD9 File Offset: 0x000C4ED9
	public bool Remembers(WitnessMemoryType type)
	{
		return this.memories[(int)type] < this.memorySpan;
	}

	// Token: 0x06001465 RID: 5221 RVA: 0x000C6CEB File Offset: 0x000C4EEB
	public void Refresh(WitnessMemoryType type)
	{
		this.memories[(int)type] = 0f;
	}

	// Token: 0x06001466 RID: 5222 RVA: 0x000C6CFC File Offset: 0x000C4EFC
	public void Tick(float dt)
	{
		for (int i = 0; i < this.memories.Length; i++)
		{
			this.memories[i] += dt;
		}
	}

	// Token: 0x04001F61 RID: 8033
	[SerializeField]
	private float[] memories;

	// Token: 0x04001F62 RID: 8034
	[SerializeField]
	private float memorySpan;

	// Token: 0x04001F63 RID: 8035
	private const float LongMemorySpan = 28800f;

	// Token: 0x04001F64 RID: 8036
	private const float MediumMemorySpan = 7200f;

	// Token: 0x04001F65 RID: 8037
	private const float ShortMemorySpan = 1800f;

	// Token: 0x04001F66 RID: 8038
	private const float VeryShortMemorySpan = 120f;
}
